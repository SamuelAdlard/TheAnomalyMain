using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    public string type = "TEST";
    public bool inCart = false;
    public bool carried = false;
    Rigidbody rb;
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    public void PickedUp()
    {
        if (carried)
        {
            inCart = false;
            transform.parent = null;
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Platform") && !carried)
        {
            inCart = true;
            rb.isKinematic = true;
            transform.parent = collision.transform;
        }
    }


}
