using UnityEngine;
using System.Collections;

namespace RosSharp.RosBridgeClient
{
    public class CameraProjector : MonoBehaviour
    {
        public GameObject CameraPanel;
        public Material InvisibleMaterial;
        private MeshRenderer _meshRenderer;
        private Material CustomMaterial;
        private Texture RobotCameraImage;
        private bool isMessageReceived;

        private bool _waitcheck = false;

        private byte[] _data;

        private void Start()
        {
            _meshRenderer = CameraPanel.GetComponent<MeshRenderer>();
            CustomMaterial = _meshRenderer.sharedMaterial;
            CustomMaterial.color = Color.clear;
            StartCoroutine(WaitAndPrint(2));
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
            _meshRenderer.material = InvisibleMaterial;

            Texture2D texture = new Texture2D(1, 1);
            texture.name = "newTexture";
            texture.LoadImage(_data);
            texture.Apply();
            RobotCameraImage = texture;

            CustomMaterial.mainTexture = RobotCameraImage;
            //CustomMaterial.mainTextureScale = Vector2.one;
            CustomMaterial.color = Color.white;

            //_meshRenderer.material = CustomMaterial;
            _meshRenderer.material.EnableKeyword ("_MAINTEX");

            CustomMaterial.SetTexture("_MainTex", texture);
            
            if (_waitcheck)
            {
                _meshRenderer.material = CustomMaterial;

            }
            //_meshRenderer.material.
            //CustomMaterial.SetPass(1);
            isMessageReceived = false;
        }

        IEnumerator WaitAndPrint(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            _waitcheck = true;
        }
    }
}