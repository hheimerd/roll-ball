using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ramp : MonoBehaviour
{
    private static Queue<Ramp> _ramps = new Queue<Ramp>();
    private const int RampsLimit = 7;

    [SerializeField] private Ramp[] availableRamps;
    
    [SerializeField] private Transform leftConnection = null;
    [SerializeField] private Transform forwardConnection = null;
    [SerializeField] private Transform rightConnection = null;
    [SerializeField] private Transform backConnection = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            SpawnAllAvailable();
        }
    }


    public void SpawnRandomRampLeft() => SpawnRandomRamp(SpawnSide.Left);
    public void SpawnRandomRampRight() => SpawnRandomRamp(SpawnSide.Right);
    public void SpawnRandomRampForward() => SpawnRandomRamp(SpawnSide.Forward);
    public void SpawnRandomRampBack() => SpawnRandomRamp(SpawnSide.Back);

    public void SpawnAllAvailable()
    {
        SpawnRandomRampLeft();
        SpawnRandomRampRight();
        SpawnRandomRampForward();
    }

    public void SpawnRandomRamp(SpawnSide side)
    {
        var targetConnection = GetConnection(side);
        if (targetConnection == null)
        {
            return;
        }
        
        var ramp = availableRamps[Random.Range(0, availableRamps.Length)];
        _ramps.Enqueue(Instantiate(ramp, targetConnection.position, targetConnection.rotation));
        while (_ramps.Count > RampsLimit)
        {
            var rampToRemove = _ramps.Dequeue();
            Destroy(rampToRemove.gameObject);
        }
    }

    [CanBeNull]
    private Transform GetConnection(SpawnSide side)
    {
        return side switch
        {
            SpawnSide.Left => leftConnection,
            SpawnSide.Right => rightConnection,
            SpawnSide.Forward => forwardConnection,
            SpawnSide.Back => backConnection,
            _ => null
        };
        
    }
    
    [Serializable]
    public enum SpawnSide
    {
        Left,
        Right,
        Forward,
        Back
    }

    public static void Clear()
    {
        while (_ramps.Count > 0)
        {
            Destroy(_ramps.Dequeue().gameObject);
        }
    }
}


