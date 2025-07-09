using System;
using UnityEngine;

namespace Tejas
{
    public class GestureInput : MonoBehaviour
    {
        [SerializeField] private GestureFingerProvider fingerProvider;
        [SerializeField] private GestureFingerData fingerData;

        private GestureController _gestureController;

        private void Awake()
        {
            _gestureController = new GestureController(fingerProvider, fingerData);
            
            _gestureController.PinchDownCallback += OnPinchDown;
            _gestureController.PinchReleaseCallback += OnPinchRelease;
            _gestureController.PalmUpCallback += OnPalmUp;
            _gestureController.LShapeCreatedCallack += OnLShapeCreated;
        }

        private void OnDestroy()
        {
            if (_gestureController != null)
            {
                _gestureController.PinchDownCallback -= OnPinchDown;
                _gestureController.PinchReleaseCallback -= OnPinchRelease;
                _gestureController.PalmUpCallback -= OnPalmUp;
                _gestureController.LShapeCreatedCallack -= OnLShapeCreated;
            }
        }

        private void Update()
        {
            _gestureController.RefreshGestureFrame();
        }

        private void OnPinchDown(OVRInput.Handedness handedness)
        {
            Debug.Log("Pinched down");
        }
        
        private void OnPinchRelease(OVRInput.Handedness handedness)
        {
            Debug.Log("Pinch released");
        }

        private void OnPalmUp(OVRInput.Handedness handedness)
        {
            Debug.Log("Palm up");
        }

        private void OnLShapeCreated(OVRInput.Handedness handedness)
        {
            Debug.Log("L shape created");
        }
    }
}