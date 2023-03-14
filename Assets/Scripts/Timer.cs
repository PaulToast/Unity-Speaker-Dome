using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    //public string Path = "";
    /*void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(Path, GetComponent<Transform>().position);
    }*/
    void Update()
    {
        timer -= 5 * Time.deltaTime;
        if (timer <= 0)
            Destroy(this.gameObject, 3);
    }

    void DestroyCOL()
    {
        Destroy(this.gameObject);
    }

}
     

