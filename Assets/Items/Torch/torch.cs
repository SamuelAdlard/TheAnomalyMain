using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    public bool IsOn = false;
    public GameObject Light;
    public int FuelTime = 300;
    public int MaxFuel = 300;
    public Item item;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && item.carried)
        {
            IsOn = !IsOn;
        }
        if (IsOn && item.carried)
        {
            Light.SetActive(true);
        }
        else
        {
            Light.SetActive(false);
        }

    }
    private void Start()
    {
        InvokeRepeating("Timer", 0f, 0.1f);
    }

    private void Timer()
    {
        if (IsOn && FuelTime > 0)
        {
            FuelTime -= 1;
        }
        //else if (!IsOn && FuelTime < 300)
        //{
        //    FuelTime += 1;
        //}
        
        if(FuelTime == 0)
        {
            IsOn = false;
        }
        
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("TorchRefuel") && FuelTime < MaxFuel)
        {
            FuelTime += 1;
        }
    }
}
