using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tejas
{
    [RequireComponent(typeof(OVRSkeleton))]
    public class GestureFingerProvider : MonoBehaviour
    {
        [SerializeField] private OVRSkeleton ovrSkeleton;
        
        public Transform Palm { get; private set; }
        public Transform ThumbTip { get; private set; }
        public Transform IndexTip { get; private set; }
        public Transform MiddleTip { get; private set; }
        public Transform RingTip { get; private set; }
        public Transform PinkyTip { get; private set; }
        
        private const string PalmName = "Hand_WristRoot";
        private const string ThumbTipName = "Hand_ThumbTip";
        private const string IndexTipName = "Hand_IndexTip";
        private const string MiddleTipName = "Hand_MiddleTip";
        private const string RingTipName = "Hand_RingTip";
        private const string PinkyTipName = "Hand_PinkyTip";

        private bool _isInitialized;
        private IList<OVRBone> _bones;
        
        private void Update()
        {
            if (_isInitialized)
            {
                return;
            }
            
            if (ovrSkeleton.IsInitialized)
            {
                Initialize();
            }
        }

        private void Initialize()
        {
            _bones = ovrSkeleton.Bones;
            foreach (var bone in _bones)
            {
                Debug.Log($"Initialized bone: {bone.Id} -- {bone.Transform.name}");
            }
            
            Palm = GetTransformFromBone(_bones, PalmName);
            ThumbTip = GetTransformFromBone(_bones, ThumbTipName);
            IndexTip = GetTransformFromBone(_bones, IndexTipName);
            MiddleTip = GetTransformFromBone(_bones, MiddleTipName);
            RingTip = GetTransformFromBone(_bones, RingTipName);
            PinkyTip = GetTransformFromBone(_bones, PinkyTipName);

            _isInitialized = true;
        }

        private Transform GetTransformFromBone(IList<OVRBone> bones, string nameToFind)
        {
            return bones.First(b => b.Transform.name == nameToFind).Transform;
        }
    }
}