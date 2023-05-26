using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_look : MonoBehaviour
{

    public float mouseSensitivity =100f;
    public Transform playerBody;
    float xRotation =0f;
    // Start is called before the first frame update
    void Start()
    {  
        // making sure my mouse dose not leave the window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX=Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY=Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -=mouseY;
        // ,aking sure we only look 90 degree up and down
        xRotation = Mathf.Clamp(xRotation,-90f, 90f);

        transform.localRotation =Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
       
    }
}
