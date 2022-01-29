using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Quitte le jeu dans la version compilée");
        Application.Quit();
    }
}
