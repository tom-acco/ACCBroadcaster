﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ksBroadcastingNetwork;

namespace ACCBroadcaster.Classes
{
    public static class ACCService
    {
        public static ACCUdpRemoteClient Client;
        public static int CustomReplayLength = 5;
    }
}
