using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        mouseSensitivity = StaticSettings.mouseSensitivity;
    }

    public void onMouseMove(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        inputVector = inputVector*mouseSensitivity*Time.deltaTime;
        xRotation -= inputVector.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotation haut/bas -> juste sur la camera
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        //rotation gauche/droite -> sur le player
        playerBody.Rotate(Vector3.up * inputVector.x);
    }
}
