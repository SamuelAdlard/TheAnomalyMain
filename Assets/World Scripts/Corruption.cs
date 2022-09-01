using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corruption : MonoBehaviour
{
    public LightingManager lightingManager;
    public int day = 0;
    public int corruption = 0;
    float delay = 1;
    float next = 0;
    void Update()
    {
        if (lightingManager.TimeOfDay > 23.5f && next < Time.time)
        {
            day++;
            next = Time.time + delay;
        }
    }
}
