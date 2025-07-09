using System;
using UnityEngine;

namespace Tejas.Snap
{
    public class LookAtTransform : MonoBehaviour
    {
        [SerializeField] private Transform transformToLookAt;

        private void Update()
        {
            transform.LookAt(transformToLookAt);
        }
    }
}