using UnityEngine;
using System.Collections.Generic;
using System;

public class RandomiseWaypoints : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform waypoint in waypoints)
        {
            waypoint.position = new Vector3(UnityEngine.Random.Range(-49, 49), 0, UnityEngine.Random.Range(-49, 49));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
