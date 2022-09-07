using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    // Video up to 
    [SerializeField]private Light DirectionalLight;
    [SerializeField]private LightingPreset Preset;
    public float dayLength = 240;
    [SerializeField, Range(0, 480)] public float TimeOfDay;
    float offset = 360f;
    
    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= dayLength; //clamp between 0-24
            UpdateLighting(TimeOfDay / dayLength);
            //print(TimeOfDay);
        }
        else
        {
            UpdateLighting(TimeOfDay / dayLength);
        }
    }
    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * offset) - 90f, 170, 0));
        }
    }

    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        if(RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                } 
            }
        }
    }
}
