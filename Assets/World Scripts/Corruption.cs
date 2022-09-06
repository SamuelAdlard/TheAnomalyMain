using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corruption : MonoBehaviour
{
    public LightingManager lightingManager;
    public int day = 0;
    public bool night = false;
    public int corruption = 0;
    float delay = 3;
    float next = 0;
    public float ExposureLevel = 0;
    void Update()
    {
        if (lightingManager.TimeOfDay > lightingManager.dayLength - 3f && next < Time.time)
        {
            day++;
            next = Time.time + delay;
        }

        if (lightingManager.TimeOfDay < 110 || lightingManager.TimeOfDay > 370)
        {
            night = true;
        }
        else
        {
            night = false;
        }
        
    }
}
