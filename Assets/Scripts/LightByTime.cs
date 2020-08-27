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

    bool day = true;

    Light lightDay;
    GameObject lightGODay;

    Light lightNight;
    GameObject lightGONight;

    float timeInSecForGameDay = 12.0f;
    float currentTimeOfDayInSec = 0.0f;

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
        lightGONight.transform.position = new Vector3(sceneSizeX/2, 0.0f, offset*-1);
        lightGONight.transform.Rotate(0.0f, 30, 0);
        lightNight.intensity = 0;
        lightNight.color = new Color(217.0f/255f, 241.0f/255f, 255.0f/255f);

        InvokeRepeating("movement", 1.0f, 1.0f);
    }

    void movement(){
        //rotation der lichtrichtung
        float omega = 180.0f / timeInSecForGameDay * -1;
        Vector3 middle = new Vector3(sceneSizeX/2, 0, (sceneSizeZ+(offset/2))/2 );
        lightGODay.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);
        lightGONight.transform.RotateAround( middle, new Vector3(1.0f, 0, 0), omega);

        currentTimeOfDayInSec++;
        if (currentTimeOfDayInSec >= timeInSecForGameDay) {
            currentTimeOfDayInSec = 0.0f;
            if (day){
                lightDay.intensity = 0;
                lightNight.intensity = 0.8f;
                day = false;
            } else {
                lightDay.intensity = 1.0f;
                lightNight.intensity = 0;
                day = true;
            }
        } 
    }  
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
