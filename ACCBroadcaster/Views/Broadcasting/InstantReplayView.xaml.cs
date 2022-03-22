﻿using ACCBroadcaster.Classes;
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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ACCBroadcaster.Views.Broadcasting
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InstantReplayView : Page
    {
        private float CurrentSessionTime = 0;
        public InstantReplayView()
        {
            ACCService.Client.MessageHandler.OnRealtimeUpdate += OnRealtimeUpdate;
            this.InitializeComponent();
        }

        private void StartInstantReplay(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            float length = 0;
            if (button.CommandParameter == null)
            {
                length = (float)CustomLengthNumberBox.Value;
            } else
            {
                length = (float)Convert.ToDouble(button.CommandParameter);
            }
            float requestedStartTime = CurrentSessionTime - (length * 1000);
            ACCService.Client.MessageHandler.RequestInstantReplay(requestedStartTime, length * 1000.0f);
        }

        private void OnRealtimeUpdate(string sender, RealtimeUpdate update)
        {
            CurrentSessionTime = Convert.ToInt32(update.SessionTime.TotalMilliseconds);
        }
    }
}