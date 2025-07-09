using UnityEngine;

namespace Tejas
{
    [CreateAssetMenu(menuName = "Tejas Project/Gesture Finger Data", fileName = "Gesture Finger Data")]
    public class GestureFingerData : ScriptableObject
    {
        public float pinchDistanceThreshold;
        [Range(-1, 0)] public float palmDownThreshold;
        [Range(0, 1)] public float palmUpThreshold;
        [Range(0, 1)] public float lShapeThreshold;
    }
}

