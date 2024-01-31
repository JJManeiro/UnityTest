using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerCopy : MonoBehaviour
{
    public Transform player;
    public float offsetAngle = 180f;
    private Vector3 offset;
    public float rotationSpeed = 5f;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset; 
        //gira la cámara junto con el jugador.
        //transform.rotation = Quaternion.LookRotation(player.forward, Vector3.up) * Quaternion.Euler(0, offsetAngle, 0);
        //PRIMERA PERSONA
        //transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
        float hinput = 0f;
        if (Input.GetKeyDown(KeyCode.J))
        {
            hinput = -1.0f;
            
            Debug.Log("me muevo a la derecha?");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            hinput = -1.0f;
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
            if (Mathf.Abs(hinput)>0.1f){
            Quaternion rotation = Quaternion.AngleAxis (hinput*rotationSpeed,Vector3.up);
            transform.rotation = rotation * transform.rotation; 
            }
        }
    }
}
