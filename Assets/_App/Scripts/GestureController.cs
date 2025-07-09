using System;
using UnityEngine;

namespace Tejas
{
    public class GestureController
    {
        public event Action<OVRHand, Vector3> PinchDownCallback;
        public event Action<OVRHand> PinchReleaseCallback;
        public event Action<OVRHand> PalmUpCallback;
        public event Action<OVRHand> PalmDownCallback;
        public event Action<OVRHand> LShapeCreatedCallack;
        
        private readonly GestureFingerProvider _fingerProvider;
        private readonly GestureFingerData _fingerData;

        private OVRHand Hand => _fingerProvider.Hand;
        
        private bool _isPinching;
        private bool _isPalmUp;
        private bool _isMakingLShape;
        
        public GestureController(GestureFingerProvider fingerProvider, GestureFingerData fingerData)
        {
            _fingerProvider = fingerProvider;
            _fingerData = fingerData;
        }

        public void RefreshGestureFrame()
        {
            CheckPinch();
            CheckPalmOrientation();
            CheckLShape();
        }

        private void CheckPinch()
        {
            var thumbTip = _fingerProvider.ThumbTip;
            var indexTip = _fingerProvider.IndexTip;

            if (VectorMathUtils.GetVectorPointDistance(thumbTip.position, indexTip.position) <
                _fingerData.pinchDistanceThreshold )
            {
                if (!_isPinching)
                {
                    PinchDownCallback?.Invoke(Hand, indexTip.position);
                }
                
                _isPinching = true;
            }
            else
            {
                if (_isPinching)
                {
                    PinchReleaseCallback?.Invoke(Hand);
                }
                
                _isPinching = false;
            }
        }

        private void CheckPalmOrientation()
        {
            var palm = _fingerProvider.Palm;

            if (Vector3.Dot(-palm.up, Vector3.up) > _fingerData.palmUpThreshold)
            {
                if (!_isPalmUp)
                {
                    PalmUpCallback?.Invoke(_fingerProvider.Hand);
                }
                
                _isPalmUp = true;
            }
            else
            {
                _isPalmUp = false;
            }
        }

        private void CheckLShape()
        {
            var thumbTip = _fingerProvider.ThumbTip;
            var indexTip = _fingerProvider.IndexTip;

            if (Vector3.Dot(thumbTip.right, indexTip.right) < _fingerData.lShapeThreshold)
            {
                if (!_isMakingLShape)
                {
                    LShapeCreatedCallack?.Invoke(Hand);
                    _isMakingLShape = true;
                }
            }
            else
            {
                _isMakingLShape = false;
            }
        }
        
        // Understand when index + thumb are in close proximity

        // Understand when Index and thumb make 'L' or right angle

        // Understand when palm is up
    }
}

