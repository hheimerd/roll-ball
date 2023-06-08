using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public float scoreDistance { get; private set; }
  
    [SerializeField] private float rotationAngle = 0;
    [SerializeField] private float maxVelocity = 1;
    [SerializeField] private float maxAcceleration = 100;
    [SerializeField, Range(1, 90)] private float rotationSpeed = 45f;
    
    private Rigidbody _rigidbody;
    private Vector3 _velocity;
    private Vector2 _input;
    
    private void Awake()
    {
        Destroy(Instance);
        Instance = this;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var hor = Input.GetAxis("Horizontal");
        if (_input != Vector2.zero)
            hor = _input.x;

        
        var angleAffect = hor * rotationSpeed;
        var currentVelocity = _rigidbody.velocity.magnitude;
        var velocityChange = maxVelocity - currentVelocity;


        var accelerationForce = velocityChange / Time.fixedDeltaTime;
        accelerationForce = Mathf.Clamp(accelerationForce, -maxAcceleration, maxAcceleration);
        
        var force = new Vector3(0, 0, accelerationForce);
        var rotatedForce = Quaternion.AngleAxis(rotationAngle + angleAffect, Vector3.up) * force;
        _rigidbody.AddForce(rotatedForce, ForceMode.Acceleration);

        scoreDistance += _rigidbody.velocity.magnitude * Time.fixedDeltaTime;
        _velocity = _rigidbody.velocity;
        
        
        
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     _rigidbody.velocity = _velocity;
    // }

    public void RotateMovement(float angle)
    {
        rotationAngle += angle;
    }

    public void OnJoystickMove(Vector2 input)
    {
        _input = input.normalized;
    }
}
