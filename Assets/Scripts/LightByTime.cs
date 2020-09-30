using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightByTime : MonoBehaviour
{

    //positivster z-Punkt der Welt: Osten
    //negativster x-Punkt der Welt: Norden

    float sceneSizeX = 200.0f;
    float sceneSizeY = 100.0f;
    float sceneSizeZ = 200.0f;

    float offset = 100.0f;

    public bool day = true;

    Light lightDay;
    GameObject lightGODay;

    Light lightNight;
    GameObject lightGONight;

    float timeInSecForGameDay = 12.0f;
    float currentTimeOfDayInHours = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        lightGODay = new GameObject("Sun");
        lightDay = lightGODay.AddComponent<Light>();
        lightDay.type = LightType.Directional;
        lightGODay.transform.position = new Vector3(sceneSizeX/2, 0.0f, sceneSizeZ+offset);
        lightGODay.transform.Rotate(180.0f, 30, 0);
        lightDay.color = new Color(255.0f/255f, 244.0f/255f, 214.0f/255f);

        lightGONight = new GameObject("Moon");
        lightNight = lightGONight.AddComponent<Light>();
        lightNight.type = LightType.Directional;
        lightGONight.transform.position = new Vector3(sceneSizeX/2, 0.0f, (sceneSizeZ/2) * -1);
        lightGONight.transform.Rotate(0.0f, -30, 0);
        lightNight.intensity = 0;
        lightNight.color = new Color(62.0f/255f, 85.0f/255f, 99.0f/255f);

        InvokeRepeating("movement", 1.0f, timeInSecForGameDay/12f);
    }

    void movement(){
        //rotation der lichtrichtung
        float omega = 180.0f / timeInSecForGameDay * -1;
        Vector3 middle = new Vector3(sceneSizeX/2, 0, sceneSizeZ/2 );
        //Debug.Log("Time: " + currentTimeOfDayInHours +  " day: " + lightDay.intensity +  " night: " + lightNight.intensity);
        
        if (currentTimeOfDayInHours == 11f && day){ 
            lightGONight.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightGONight.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightNight.intensity = 0.8f;
        } else if (currentTimeOfDayInHours == 12f && day){       
            lightGODay.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightGODay.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightGODay.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightGONight.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightDay.intensity = 0;
            currentTimeOfDayInHours = 1;
            day = false;
        } else if (currentTimeOfDayInHours == 11f && !day){
            lightGODay.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightGODay.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightDay.intensity = 1f;
        } else if (currentTimeOfDayInHours == 12f && !day){
            lightGONight.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightGONight.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightGONight.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightGODay.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightNight.intensity = 0;
            currentTimeOfDayInHours = 1;
            day = true;
        } else {
            lightGODay.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
            lightGONight.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
        }

        currentTimeOfDayInHours++;
    }  
}
