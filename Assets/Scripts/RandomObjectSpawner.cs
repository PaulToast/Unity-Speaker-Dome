
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{

    public GameObject[] myObjects;

    //public string Path = "";
    public float MaxTime = 0f;
    public float MinTime = 0f;
    public float MaxX = 0f;
    public float MinX = 0f;
    public float MaxY = 0f;
    public float MinY = 0f;
    public float MaxZ = 0f;
    public float MinZ = 0f;
    
   
    void Start()
    {
        Invoke("SpawnBall", Random.Range(MinTime, MaxTime));
    }
    void Update()
    {

    }
    void SpawnBall()
    {
        int randomIndex = Random.Range(0, myObjects.Length);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), Random.Range(MinZ, MaxZ));

        Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
        //FMODUnity.RuntimeManager.PlayOneShot(Path, GetComponent<Transform>().position);
        Invoke("SpawnBall", Random.Range(MinTime, MaxTime));

    }

}


