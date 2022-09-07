using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public CharacterController Controller;
    public bool grounded = false;
    Vector3 Velocity;
    public float Gravity = -10f;
    void FixedUpdate()
    {
        
        Velocity.y += Gravity * Time.deltaTime;
        
        
        if (grounded)
        {
            Velocity.y = 0;
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Velocity.y = 6;
        }


        Controller.Move(Velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name + " Tag: " +  other.tag);
        if (other.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
