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
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            if(hit.transform.CompareTag("Ground"))
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }
        else
        {
            grounded = false;
        }
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

   
}
