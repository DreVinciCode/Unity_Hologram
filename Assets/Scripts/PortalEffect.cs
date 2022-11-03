using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
    public class PortalEffect : MonoBehaviour
    {
        public float scale;
        public float sparkSpinSpeed, ringSpinSpeed, scaleSpeed;


        public int sparkAmount;
        public GameObject sparkFX;

        Transform sparkSpinControl, ringSpinControl;

        private Vector3 _initialScale;

        private void Start()
        {
            sparkSpinControl = transform.Find("SparkSpinControl");
            ringSpinControl = transform.Find("RingSpinControl");
            CreateSparkAroundPoint();
        }

        private void Update()
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(scale, scale, scale), scaleSpeed * Time.deltaTime);
            sparkSpinControl.Rotate(transform.forward, sparkSpinSpeed * Time.deltaTime);
            ringSpinControl.Rotate(transform.forward, ringSpinSpeed * Time.deltaTime);
        }


        private void CreateSparkAroundPoint()
        {
            for (int i = 0; i < sparkAmount; i++)
            {
                var radians = 2 * Mathf.PI / sparkAmount * i;

                var vertical = Mathf.Sin(radians);
                var horizontal = Mathf.Cos(radians);
                var spawnDirection = new Vector3(horizontal, vertical, 0);
                var spawnPosition = transform.position + spawnDirection;

                var enemy = Instantiate(sparkFX, sparkSpinControl);
                enemy.transform.position = spawnPosition;

                Vector3 relativePosition = enemy.transform.position - transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePosition, Vector3.forward);

                enemy.transform.rotation = rotation;
            }
        }

    }
}
