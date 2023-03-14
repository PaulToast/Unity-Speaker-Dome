using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController m_charCont;

    bool playerismoving;
    [SerializeField] private float RayDistance = 500f;
    [SerializeField] private Transform playerTransform;
    private float Material;
    float m_horizontal;
    float m_vertical;
    float m_rotation;
    public float Movespeed;
    private float DistanceTravelled;
    private float TimeTakenSinceStep;
    [SerializeField] private float StepDistance = 25.0f;                                                 
    private Vector3 PrevPos;

    void Start()
    {
        m_charCont = GetComponent<CharacterController>();
        GetComponent<FMODoutput>().setASIODriver();
    }

    void Update()
    {
        // ROTATION
        if (Input.GetAxis("Rotation") >= 0.2f || Input.GetAxis("Rotation") <= -0.2f)
        {
            m_rotation = Input.GetAxis("Rotation") * 0.5f;
        }
        else
        {
            m_rotation = 0f;
        }
        playerTransform.rotation = playerTransform.rotation * Quaternion.AngleAxis(m_rotation, Vector3.down);

        // MOVEMENT
        if (Input.GetAxis("Vertical") >= 0.2f || Input.GetAxis("Horizontal") >= 0.2f || Input.GetAxis("Vertical") <= -0.2f || Input.GetAxis("Horizontal") <= -0.2f)
        {
            playerismoving = true;
            m_horizontal = Input.GetAxis("Horizontal");
            m_vertical = Input.GetAxis("Vertical");
        }
        else
        {
            playerismoving = false;
            m_horizontal = 0f;
            m_vertical = 0f;
        }
        Vector3 m_playerMovement = new Vector3(m_horizontal, 0f, m_vertical) * Movespeed;
        m_playerMovement = playerTransform.rotation * m_playerMovement;
        Debug.DrawRay(transform.position, Vector3.down * RayDistance, Color.blue);
        m_charCont.Move(m_playerMovement);

        // SCENES
        if (Input.GetButtonDown("Switch Scene"))
        {
            var currentScene = SceneManager.GetActiveScene();

            if (currentScene.name == "Scene Yoshimi")
            {
                SceneManager.LoadScene("Scene Paul");
                SceneManager.UnloadSceneAsync("Scene Yoshimi");
            }
            else if (currentScene.name == "Scene Paul")
            {
                SceneManager.LoadScene("Scene Jakob");
                SceneManager.UnloadSceneAsync("Scene Paul");
            }
            else if (currentScene.name == "Scene Jakob")
            {
                SceneManager.LoadScene("Scene Yoshimi");
                SceneManager.UnloadSceneAsync("Scene Jakob");
            }
        }

        // FOOTSTEPS
        MaterialCheck();
        TimeTakenSinceStep += Time.deltaTime;                                 
        DistanceTravelled += (transform.position - PrevPos).magnitude;       
        if (DistanceTravelled >= StepDistance)                  
        {
            MaterialCheck();      
            PlayFootstepsEvent();                                                                           
            DistanceTravelled = 0f;
            Debug.Log(Material);
        }
        PrevPos = transform.position;

    }
    
    // FMOD
    void CallFootsteps() 
    {
        if (playerismoving == true)
        {
             FMODUnity.RuntimeManager.PlayOneShot("event:/Footsteps", GetComponent<Transform>().position);
        }
    }
    void PlayFootstepsEvent()
    {
        FMOD.Studio.EventInstance Footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Footsteps, GetComponent<Transform>(), GetComponent<Rigidbody>());
        Footsteps.setParameterByName("Material", Material);
        Footsteps.start();
        Footsteps.release();
    }

    void MaterialCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Concrete"))
            {
                Material = 0f;
            }
           else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Dirt"))
            {
                Material = 1f;
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("WaterL"))
            {
                Material = 2f;
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("WaterH"))
            {
                Material = 3f;
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Metal"))
            {
                Material = 4f;
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Layer 6"))
            {
                Material = 5f;
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Layer 7"))
            {
                Material = 6f;
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Layer 8"))
            {
                Material = 7f;
            }
            else
            {
                Material = 0f;
            }
        }

    }
}