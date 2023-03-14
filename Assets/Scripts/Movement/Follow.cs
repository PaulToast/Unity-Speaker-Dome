// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Follow : MonoBehaviour
{

    public Transform[] Waypoints;
    public int Speed;
    private int WaypointIndex;
    private float Dist;
    private bool PlayerThere = false;
    public Transform Player;
    public float DistanceToPlayer;


    void Start()
    {
        WaypointIndex = 0;
        transform.LookAt(Waypoints[WaypointIndex].position);
    }

    void Update()
    {
       
        float dist = Vector3.Distance(Player.position, transform.position);
        if (dist < DistanceToPlayer)
        {
           
            if (PlayerThere == false)
            {
                PlayerThere = true;
            }
        }
        if (dist > DistanceToPlayer)
        {

            if (PlayerThere == true)
            {
                PlayerThere = false;
            }
        }
        Dist = Vector3.Distance(transform.position, Waypoints[WaypointIndex].position);
        if (Dist < 10f)
        {
            if (PlayerThere == true)
            {
                Speed = 300;
                IncreaseIndex();
            }
            else 
            {
                Speed = 0;
            }
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
