using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class PointCloudProjector : MonoBehaviour
    {
        private bool isMessageReceived;
        private int _totalParticles;
        private int _pc_width;
        private int _pc_height;
        private int _rowStep;
        private int _pointStep;
        private int _pointSize;

        private Vector3[] pcl;
        private Color[] pcl_color;

        private byte[] _data;
        private ParticleSystem.Particle[] _particles;
        private ParticleSystem _particleSystem;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }

        public void Write(MessageTypes.Sensor.PointCloud2 message)
        {
            _data = message.data;
            _pointSize = _data.GetLength(0) / _pointStep;
            _particles = new ParticleSystem.Particle[_totalParticles];

            isMessageReceived = true;

            Debug.Log("Herrer");
        }

        private void FixedUpdate()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        private void ProcessMessage()
        {
            Debug.Log("He3333r");

            Debug.Log("Total points: " + _pointSize );

            isMessageReceived = false;

            /*
            for (int i = 0; i < _totalParticles; i++)
            {
                var particle = _data[i];
                //particles[i].position = new Vector3(particle., message.points[i].y, message.points[i].z);
                
            }*/


        }
    }
}
