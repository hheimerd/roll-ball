using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirectionTrigger : MonoBehaviour
{
    [SerializeField] private float rotationAngle;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent<PlayerController>(out PlayerController playerController))
            return;

        playerController.RotateMovement(rotationAngle);

    }
    
}
