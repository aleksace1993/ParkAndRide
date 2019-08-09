﻿using RawRabbit.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkAndRide.Common.RabbitMq
{
    public class RabbitMqOptions : RawRabbitConfiguration
    {
        public string Namespace { get; set; }
        public int Retries { get; set; }
        public int RetryInterval { get; set; }
    }
}
