using System;
using Tejas.Snap;
using UnityEngine;

public class CameraSwing : MonoBehaviour
{
    [SerializeField] private float degreeFactor = 90;
    [SerializeField] private float swingSpeed = 3F;
    [SerializeField] private float startingYRotation = 45;

    private void Start()
    {
        transform.Rotate(Vector3.up, startingYRotation);
    }

    private void Update()
    {
        // Swing
        var additiveDegrees = Mathf.PingPong(Time.time * swingSpeed, degreeFactor);
        
        // Add the swing
        var aggregateRotation = startingYRotation + additiveDegrees;
        Debug.Log(aggregateRotation);
        
        // Swinging
        var newRotationEuler = new Vector3(0, aggregateRotation, 0);
        var rotation = Quaternion.Euler(newRotationEuler);

        transform.rotation = rotation;
    }
}