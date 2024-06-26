﻿using ksBroadcastingNetwork;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCBroadcaster.Classes
{
    internal class Car : INotifyPropertyChanged
    {
        public int Index { get; set; }
        private int _Position;

        public int Position 
        {
            get { return _Position; }
            set
            {
                _Position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        public int RaceNumber { get; set; }

        private string _DriverName;
        public string DriverName
        {
            get { return _DriverName; }
            set
            {
                _DriverName = value;
                OnPropertyChanged(nameof(DriverName));
            }
        }

        private string _ShortName;
        public string ShortName
        {
            get { return _ShortName; }
            set
            {
                _ShortName = value;
                OnPropertyChanged(nameof(ShortName));
            }
        }

        private CarLocationEnum _Location;
        public CarLocationEnum Location
        {
            get { return _Location; }
            set
            {
                _Location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        private string _LapDelta;
        public string LapDelta
        {
            get { return _LapDelta; }
            set
            {
                _LapDelta = value;
                OnPropertyChanged(nameof(LapDelta));
            }
        }

        private string _Interval;
        public string Interval
        {
            get { return _Interval; }
            set
            {
                _Interval = value;
                OnPropertyChanged(nameof(Interval));
            }
        }

        private string _CurrentLap;
        public string CurrentLap
        {
            get { return _CurrentLap; }
            set
            {
                _CurrentLap = value;
                OnPropertyChanged(nameof(CurrentLap));
            }
        }

        private string _LastLap;
        public string LastLap
        {
            get { return _LastLap; }
            set
            {
                _LastLap = value;
                OnPropertyChanged(nameof(LastLap));
            }
        }

        public int BestLapMS = 0;

        private string _BestLap;
        public string BestLap
        {
            get { return _BestLap; }
            set
            {
                _BestLap = value;
                OnPropertyChanged(nameof(BestLap));
            }
        }

        public int Kmh;

        public int Lap;

        private SolidColorBrush _BackgroundBrush;
        public SolidColorBrush BackgroundBrush
        {
            get { return _BackgroundBrush; }
            set
            {
                _BackgroundBrush = value;
                OnPropertyChanged(nameof(BackgroundBrush));
            }
        }

        private SolidColorBrush _DeltaBrush;
        public SolidColorBrush DeltaBrush
        {
            get { return _DeltaBrush; }
            set
            {
                _DeltaBrush = value;
                OnPropertyChanged(nameof(DeltaBrush));
            }
        }

        private SolidColorBrush _CurrentLapBrush;
        public SolidColorBrush CurrentLapBrush
        {
            get { return _CurrentLapBrush; }
            set
            {
                _CurrentLapBrush = value;
                OnPropertyChanged(nameof(CurrentLapBrush));
            }
        }

        private bool _IsFocused = false;
        public bool IsFocused
        {
            get { return _IsFocused; }
            set
            {
                _IsFocused = value;
                OnPropertyChanged(nameof(IsFocused));
            }
        }

        private float _SplinePosition;
        public float SplinePosition
        {
            get { return _SplinePosition; }
            set
            {
                _SplinePosition = value;
                OnPropertyChanged(nameof(SplinePosition));
            }
        }

        public DateTime LastUpdated;

        public bool IsConnected = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DestroyPropertyChanged()
        {
            PropertyChanged = null;
        }

        public string LapTimeMsToReadable(int? laptimeMs)
        {
            if (laptimeMs == null)
                return "--";
            else
                return $"{TimeSpan.FromMilliseconds((double)laptimeMs):mm\\:ss\\.fff}";
        }

        public void SetLapDelta(int deltaMs)
        {
            string posOrNeg;
            if (deltaMs < 0)
            {
                posOrNeg = "-";
                this.DeltaBrush = new SolidColorBrush(Colors.DarkGreen);
            }
            else
            {
                posOrNeg = "+";
                this.DeltaBrush = new SolidColorBrush(Colors.Red);
            }
            this.LapDelta = (posOrNeg + $"{TimeSpan.FromMilliseconds(deltaMs):s\\,fff}");
        }

        public void SetInterval(int deltaMs)
        {
            this.Interval = $"+{TimeSpan.FromMilliseconds(deltaMs):s\\,fff}";
        }

        public void SetAsFocusedCar(bool isFocused)
        {
            IsFocused = isFocused;
            if (isFocused)
            {
                BackgroundBrush = new SolidColorBrush(Colors.DodgerBlue);
            } else
            {
                BackgroundBrush = null;
            }
        }
    }
}
