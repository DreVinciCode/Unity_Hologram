using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class PointCloudSubscriber : UnitySubscriber<MessageTypes.Sensor.PointCloud2>
    {
        public PointCloudProjector PointCloudProjector;

        protected override void Start()
        {
            base.Start();
        }

        protected override void ReceiveMessage(MessageTypes.Sensor.PointCloud2 message)
        {
            PointCloudProjector.Write(message);
        }
    }
}