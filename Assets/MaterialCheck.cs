using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCheck : MonoBehaviour
{
    private float Material;
    int floor1;
    int floor2;
    int floor3; 

    // Start is called before the first frame update
    void Start()
    {
        floor1 = LayerMask.NameToLayer("Concrete");
        floor2 = LayerMask.NameToLayer("Dirt");
        floor3 = LayerMask.NameToLayer("WaterL");
    }

    // Update is called once per frame
    void Update()
    {
        MaterialChecks();
    }

    void MaterialChecks()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {

            if (hit.collider.gameObject.layer == floor1)
            {
                Material = 0f;
                Debug.Log("Concrete");
            }
            else if (hit.collider.gameObject.layer == floor2)
            {
                Material = 1f;
                Debug.Log("Dirt");
            }
        }
        Debug.DrawRay(transform.position, Vector3.down * 100f, Color.red);
        Debug.Log(Material);
    }
}
