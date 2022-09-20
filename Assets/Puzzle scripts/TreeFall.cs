using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{

    public int health = 50;


    private void OnCollisionEnter(Collision collision)
    {
        float velocity = Mathf.Pow(collision.relativeVelocity.x + collision.relativeVelocity.z, 2) / 2;
        if (collision.transform.CompareTag("Axe") && velocity > 2)
        {
            health -= Mathf.RoundToInt(velocity) / 5;
            print("Done: " + Mathf.RoundToInt(velocity) / 5);

        }


        if (health <= 0)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Item>().enabled = true;
            

        }
    }
}
