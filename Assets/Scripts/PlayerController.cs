using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY; 
    public float speed;
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        Debug.Log("Hola.Comencemos el juego!");
    }
    void OnMove (InputValue movementValue)
   {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y;  
   }
    void OnJump ()
    {
        rb.AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
    }
    // Update is called once per frame
    void FixedUpdate()
    {  
        if (Input.GetKeyDown(KeyCode.Space)){
            OnJump();
        }
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    void OnTriggerEnter (Collider other){
        if (other.gameObject.CompareTag("Coin")) 
       {
            other.gameObject.SetActive(false);
       }
        
    }
}
