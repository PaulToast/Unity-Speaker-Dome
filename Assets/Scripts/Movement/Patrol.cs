// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    public Transform[] Waypoints;
    public int Speed;
    private int WaypointIndex;
    private float Dist;


    void Start()
    {
        WaypointIndex = 0;
        transform.LookAt(Waypoints[WaypointIndex].position);
    }

    void Update()
    {
        Dist = Vector3.Distance(transform.position, Waypoints[WaypointIndex].position);
        if(Dist < 10f)
        {
            IncreaseIndex();
        }
        Patroller();
    }
    void Patroller()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        WaypointIndex++;
        if(WaypointIndex >= Waypoints.Length)
        {
            WaypointIndex = 0;
        }
        transform.LookAt(Waypoints[WaypointIndex].position);
    }


}
