using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickUpRange = 6;
    public Transform pickUpPoint;
    public Rigidbody item;
    public LineRenderer lineRenderer;
    public bool holding = false;
    public float holdStrength = 5;
    bool justheld = false;
    float normalSpeed;
    public float cartSpeed = 2;

    private void Start()
    {
        normalSpeed = transform.parent.GetComponent<PlayerMovement>().Speed;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && holding)
        {
            holding = false;
            justheld = true;
            lineRenderer.enabled = false;
            item.GetComponent<Item>().carried = false;
            transform.parent.GetComponent<PlayerMovement>().Speed = normalSpeed;
        }

        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position,transform.forward, out hit, pickUpRange) && !holding && !justheld)
        {
            
            if (hit.transform.GetComponent<Item>())
            {
                
                item = hit.transform.GetComponent<Rigidbody>();
                holding = true;
                item.GetComponent<Item>().carried = true;
                item.GetComponent<Item>().PickedUp();
            }

            
        }
        justheld = false;



        if (holding && item.GetComponent<Item>().type != "Cart")
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, pickUpPoint.position);
            lineRenderer.SetPosition(1, item.position);
            Vector3 targetVector = pickUpPoint.position - item.position;
            item.AddForce(targetVector * Time.deltaTime * holdStrength);
        }
        else if(holding && item.GetComponent<Item>().type == "Cart")
        {
            Vector3 targetVector = transform.parent.position - item.position;
            item.AddForce(targetVector * Time.deltaTime * holdStrength);
            transform.parent.GetComponent<PlayerMovement>().Speed = cartSpeed;
        }
        
    }
}
