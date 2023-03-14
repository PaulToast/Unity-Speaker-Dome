using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    float CamOffsetZ;
    void Start()
    {
        CamOffsetZ = gameObject.transform.position.y;
    }


    void Update()
    {
        Vector3 m_cameraPos = new Vector3(Player.position.x, Player.position.y + CamOffsetZ, Player.position.z);

        gameObject.transform.position = m_cameraPos;
    }
}
