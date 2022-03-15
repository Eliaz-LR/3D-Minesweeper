using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pointer : MonoBehaviour
{
    public float range = 10f;

    public void OnFlagKey(InputAction.CallbackContext context)
    {
        RayRecever cible = GetObjPointe();
        if (cible!=null)
        {
            cible.flag();
        }
    }
    public void OnFireKey(InputAction.CallbackContext context)
    {
        RayRecever cible = GetObjPointe();
        if (cible!=null)
        {
            if (cible.flagged==false)
            {
                cible.Activate();
            }
        }
    }

    private RayRecever GetObjPointe()
    {
        RaycastHit hit_info;
        if (Physics.Raycast(transform.position,transform.forward,out hit_info, range))
        {
            return hit_info.transform.GetComponent<RayRecever>();
        }
        else
        {
            return null;
        }
    }
}
