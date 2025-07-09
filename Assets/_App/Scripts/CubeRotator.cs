using UnityEngine;

namespace Tejas
{
    public class CubeRotator : MonoBehaviour
    {
        [SerializeField] private float rotationFactor;
        
        public void IncrementalRotate(float angleIncrement)
        {
            transform.Rotate(Vector3.up, angleIncrement * rotationFactor, Space.Self);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}