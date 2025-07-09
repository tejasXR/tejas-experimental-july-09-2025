using System;
using UnityEngine;

namespace Tejas
{
    public class GestureInput : MonoBehaviour
    {
        [SerializeField] private GestureFingerProvider fingerProvider;
        [SerializeField] private GestureFingerData fingerData;
        [SerializeField] private CubeRotator cubeRotator;

        private GestureController _gestureController;
        private Vector3? _pinchPoint;

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

            if (_pinchPoint.HasValue)
            {
                var pinchDirectionalVector = fingerProvider.IndexTip.position - _pinchPoint.Value;
                var projectedVector = Vector3.ProjectOnPlane(pinchDirectionalVector, Vector3.up);
                
                Debug.DrawLine(_pinchPoint.Value, projectedVector + _pinchPoint.Value, Color.blue);

                var pullLength = projectedVector.magnitude;
                var crossResult = Vector3.Cross(Vector3.forward, projectedVector);
                
                var pinchPullDirection = crossResult.y > 0 ? -1 : 1;
                cubeRotator.IncrementalRotate(pullLength * pinchPullDirection);
            }
        }

        private void OnPinchDown(OVRHand hand, Vector3 pinchPosition)
        {
            _pinchPoint = pinchPosition;
            Debug.Log("Pinched down");
        }
        
        private void OnPinchRelease(OVRHand hand)
        {
            _pinchPoint = null;
            Debug.Log("Pinch released");
        }

        private void OnPalmUp(OVRHand hand)
        {
            Debug.Log("Palm up");
        }

        private void OnLShapeCreated(OVRHand hand)
        {
            Debug.Log("L shape created");
        }
    }
}