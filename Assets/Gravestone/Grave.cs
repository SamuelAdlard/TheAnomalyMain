using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{
    public int health = 100;
    public Corruption corruptionScript;
    private void Start()
    {
        corruptionScript = GameObject.Find("World Manager").GetComponent<Corruption>();

    }
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
            Destroy(gameObject);
            DestroyGrave();

        }
    }

    

    void DestroyGrave()
    {
        
        print("Destroyed");
        corruptionScript.corruption++;

    }
}
