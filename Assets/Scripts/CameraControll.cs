using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private float cameraSpeed = 10f;

    private Vector3 _velocity;
    
    private Vector3 _offset;
    

    void Start()
    {
        _offset = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var target = player.transform.position - _offset;
        transform.position = Vector3.MoveTowards(transform.position, target, cameraSpeed);
    }
}
