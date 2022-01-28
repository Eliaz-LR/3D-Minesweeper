using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float range = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Pointe();
        }
    }

    void Pointe()
    {
        RaycastHit hit_info;
        if (Physics.Raycast(transform.position,transform.forward,out hit_info, range))
        {
            RayRecever cible = hit_info.transform.GetComponent<RayRecever>();
            if (cible != null)
            {
                cible.Activate();
            }
        }
    }
}
