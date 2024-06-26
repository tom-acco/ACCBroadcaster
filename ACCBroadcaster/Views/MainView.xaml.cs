﻿using ACCBroadcaster.Classes;
using ACCBroadcaster.Views.Broadcasting;
using ksBroadcastingNetwork;
using ksBroadcastingNetwork.Structs;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using ACCBroadcaster.Properties;
using System.Reflection;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ACCBroadcaster.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView : Page
    {
        public MainView()
        {
            this.InitializeComponent();
            if (Settings.Default.LoginRemembered)
            {
                IP.Text = Settings.Default.IP;
                Port.Value = Settings.Default.Port;
                DisplayName.Text = Settings.Default.DisplayName;
                ConnectionPW.Password = Settings.Default.ConnectionPw;
                CommandPW.Password = Settings.Default.CommandPw;
                UpdateInterval.Value = Settings.Default.UpdateInterval;
                RememberLogin.IsChecked = true;
            }
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            VersionText.Text = $"Version {version.Major}.{version.Minor}.{version.Build}";
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            string ip = IP.Text;
            int port = (int)Port.Value;
            string displayName = DisplayName.Text;
            string connectionPw = ConnectionPW.Password;
            string commandPw = CommandPW.Password;
            int updateInterval = (int)UpdateInterval.Value;
            if ((bool)RememberLogin.IsChecked)
            {
                Settings.Default.IP = ip;
                Settings.Default.Port = port;
                Settings.Default.DisplayName = displayName;
                Settings.Default.ConnectionPw = connectionPw;
                Settings.Default.CommandPw = commandPw;
                Settings.Default.UpdateInterval = updateInterval;
                Settings.Default.LoginRemembered = true;
                Settings.Default.Save();
            }
            ACCService.Client = new ACCUdpRemoteClient(ip, port, displayName, connectionPw, commandPw, updateInterval);
            ACCService.Client.MessageHandler.OnConnectionStateChanged += OnConnect;
            ACCService.Client.MessageHandler.OnDisconnect += OnDisconnect;
        }

        private void OnConnect(int connectionId, bool connectionSuccess, bool isReadonly, string error)
        {
            if (connectionSuccess)
            {
                Frame.Navigate(typeof(BroadcastingView));
            } else
            {
                ErrorTextBlock.Text = error;
            }
        }

        private void OnDisconnect()
        {
            Frame.Navigate(typeof(MainView));
        }
    }
}
