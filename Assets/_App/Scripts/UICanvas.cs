using System;
using UnityEngine;

namespace Tejas.Snap
{
    public class UICanvas : MonoBehaviour
    {
        [SerializeField] private bool enableBillboard = true;
        [SerializeField] private float rotationalDegreesBuffer = 24;

        private Camera _mainCam;

        private void Awake()
        {
            _mainCam = Camera.main;
        }

        private void Update()
        {
            if (enableBillboard)
            {
                LookAtCameraOnYAxis();
            }
        }

        private void LookAtCameraOnYAxis()
        {
            var targetDirection = _mainCam.transform.position - transform.position;

            if (Vector3.Angle(transform.forward, targetDirection) > rotationalDegreesBuffer)
            {
                var rotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                transform.rotation = rotation;
            }
        }
    }
}