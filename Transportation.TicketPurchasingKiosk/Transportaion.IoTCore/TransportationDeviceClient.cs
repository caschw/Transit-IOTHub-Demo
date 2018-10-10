﻿using Microsoft.Azure.Devices.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transportation.IoTCore
{
    public class TransportationDeviceClient
    {
        private DeviceClient deviceClient;
        public TransportationDeviceClient(string connectionString)
        {
            deviceClient = DeviceClient.CreateFromConnectionString(connectionString);
        }

        public async Task SendMessageAsync(string msg)
        {
            var message = new Message(msg.GetBytes());
            deviceClient.SendEventAsync(message);
        }

        public async Task SendMessageBatchAsync(IEnumerable<string> msgs)
        {
            var messages = msgs.ForEach((x) => { return new Message(x.GetBytes()); });
            deviceClient.SendEventBatchAsync(messages);
        }
        
        public async Task<Message> ReceiveMessageAsync()
        {
            var message = await deviceClient.ReceiveAsync(TimeSpan.FromSeconds(60 * 1));
            return message;
        }
        
    }
}
