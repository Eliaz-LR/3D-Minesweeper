using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    //xRotation est la rotation autour de l'axe X
    float xRotation = 85f;

    // Start is called before the first frame update
    void Start()
    {
        //On cache la souris
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotation haut/bas -> juste sur la camera
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        //rotation gauche/droite -> sur le player
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
