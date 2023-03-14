using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    [SerializeField] private float RayDistance = 1.2f;
    private float MaterialNPC;
    private float DistanceTravelled;
    private float TimeTakenSinceStep;
    [SerializeField] private float StepDistance = 25.0f;                                                 
    private Vector3 PrevPos;




    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * RayDistance, Color.blue);
        MaterialCheck();

        TimeTakenSinceStep += Time.deltaTime;                                 
        DistanceTravelled += (transform.position - PrevPos).magnitude;       
        if (DistanceTravelled >= StepDistance)                  
        {
            MaterialCheck();      
            PlayFootstepsEvent();                                                                           
            DistanceTravelled = 0f;                                          
        }
        PrevPos = transform.position;

    }
   //FMOD
   /* void CallFootsteps() 
    {


        if (playerismoving == true)
        {
 
             FMODUnity.RuntimeManager.PlayOneShot("event:/FootstepsNPC", GetComponent<Transform>().position);

        }
    }
    //FMOD*/
   void PlayFootstepsEvent()
    {
        FMOD.Studio.EventInstance FootstepsNPC = FMODUnity.RuntimeManager.CreateInstance("event:/FootstepsNPC");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(FootstepsNPC, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FootstepsNPC.setParameterByName("MaterialNPC", MaterialNPC );
        FootstepsNPC.start();
        FootstepsNPC.release();
    }

    void MaterialCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1000.0f))
        {

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Grass"))
            {
                MaterialNPC = 0f;
                Debug.Log("Grass");
            }
           else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Concrete"))
            {
                MaterialNPC = 1f;
                Debug.Log("Concrete");
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("MetalHard"))
            {
                MaterialNPC = 2f;
                Debug.Log("MetalHard");
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("MetalFence"))
            {
                MaterialNPC = 3f;
                Debug.Log("MetalFence");
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Water"))
            {
                MaterialNPC = 4f;
                Debug.Log("Water");
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Layer 6"))
            {
                MaterialNPC = 5f;
                Debug.Log("Material 4 ");
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Layer 7"))
            {
                MaterialNPC = 6f;
                Debug.Log("Material 4 ");
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Layer 8"))
            {
                MaterialNPC = 7f;
                Debug.Log("Material 4 ");
            }
            else
            {
                MaterialNPC = 0f;
            }
        }
        Debug.DrawRay(transform.position, Vector3.down , Color.green);

    }


}

