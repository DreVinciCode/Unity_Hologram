using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class CameraProjector : MonoBehaviour
    {
        public GameObject CameraPanel;

        private Material CustomMaterial;
        public Texture RobotCameraImage;
        public Canvas CameraDisplayCanvas;
        private bool isMessageReceived;
        private byte[] _data;

        private void Start()
        {
            //CustomMaterial.mainTexture = RobotCameraImage;
            CustomMaterial = CameraPanel.GetComponent<MeshRenderer>().sharedMaterial;
            CustomMaterial.mainTexture = RobotCameraImage;
            CustomMaterial.color = Color.white;
        }


        private void Update()
        {
            if (isMessageReceived)
                ProcessMessage();
        }

        public void WriteCameraImage(MessageTypes.Sensor.CompressedImage message)
        {
            _data = message.data;
            isMessageReceived = true;
        }

        private void ProcessMessage()
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(_data);
            texture.Apply();
            RobotCameraImage = texture;
            CustomMaterial.mainTexture = RobotCameraImage;
            CustomMaterial.color = Color.white;


            //CameraDisplayCanvas.enabled = true;
            isMessageReceived = false;
        }
    }
}