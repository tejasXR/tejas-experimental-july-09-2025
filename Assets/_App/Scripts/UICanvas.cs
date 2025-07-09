using UnityEngine;

namespace Tejas.Snap
{
    public class UICanvas : MonoBehaviour
    {
        [SerializeField] private bool enableBillboard = true;
        [SerializeField] private float rotationalDegreesBuffer = 24;
        [SerializeField] private bool enableEasing = false;
        [SerializeField] private float easingSmoothing = 5F;
        [SerializeField] private float rotationalStep;

        private Camera _mainCam;
        private Quaternion _destinationRotation;

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
            var step = rotationalStep * Time.deltaTime;
            
            if (Vector3.Angle(transform.forward, targetDirection) > rotationalDegreesBuffer)
            {
                _destinationRotation = Quaternion.RotateTowards(_destinationRotation, 
                    Quaternion.LookRotation(targetDirection), step);
            }

            var easedRotation = Quaternion.Lerp(transform.rotation, _destinationRotation,
                Time.deltaTime * easingSmoothing);
            
            transform.rotation = enableEasing ? easedRotation : _destinationRotation;
        }
    }
}