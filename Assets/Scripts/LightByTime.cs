using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    6 UHR IST DIE DEFAULT STARTZEIT
*/
public class LightByTime : MonoBehaviour {

    public bool showLight;

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

    bool secondRound = false;

    // Start is called before the first frame update
    void Start () {
        if (showLight) {
            //Debug.Log ("init");
            lightGODay = new GameObject ("Sun");
            lightDay = lightGODay.AddComponent<Light> ();
            lightDay.type = LightType.Directional;
            lightGODay.transform.position = new Vector3 (sceneSizeX / 2, 0.0f, sceneSizeZ + offset);
            lightGODay.transform.Rotate (180.0f, 30, 0);
            lightDay.color = new Color (255.0f / 255f, 244.0f / 255f, 214.0f / 255f);

            lightGONight = new GameObject ("Moon");
            lightNight = lightGONight.AddComponent<Light> ();
            lightNight.type = LightType.Directional;
            lightGONight.transform.position = new Vector3 (sceneSizeX / 2, 0.0f, (sceneSizeZ / 2) * -1);
            lightGONight.transform.Rotate (0.0f, -30, 0);
            lightNight.intensity = 0;
            lightNight.color = new Color (62.0f / 255f, 85.0f / 255f, 99.0f / 255f);
        }

        InvokeRepeating ("movement", 1.0f, timeInSecForGameDay / 12f);
    }

    void manualInit () {
        if (GameObject.Find("Sun") == null){
            lightGODay = new GameObject ("Sun");
            lightDay = lightGODay.AddComponent<Light> ();
            lightDay.type = LightType.Directional;
            lightGODay.transform.position = new Vector3 (sceneSizeX / 2, 0.0f, sceneSizeZ + offset);
            lightGODay.transform.Rotate (180.0f, 30, 0);
            lightDay.color = new Color (255.0f / 255f, 244.0f / 255f, 214.0f / 255f);
        }
        if (GameObject.Find("Moon") == null){
            lightGONight = new GameObject ("Moon");
            lightNight = lightGONight.AddComponent<Light> ();
            lightNight.type = LightType.Directional;
            lightGONight.transform.position = new Vector3 (sceneSizeX / 2, 0.0f, (sceneSizeZ / 2) * -1);
            lightGONight.transform.Rotate (0.0f, -30, 0);
            lightNight.intensity = 0;
            lightNight.color = new Color (62.0f / 255f, 85.0f / 255f, 99.0f / 255f);
        }

        
    }

    void movement () {
        //rotation der lichtrichtung
        float omega = 180.0f / timeInSecForGameDay * -1;
        Vector3 middle = new Vector3 (sceneSizeX / 2, 0, sceneSizeZ / 2);
        //Debug.Log("Time: " + currentTimeOfDayInHours +  " day: " + lightDay.intensity +  " night: " + lightNight.intensity);
        //Debug.Log("Log: " + currentTimeOfDayInHours +  " Time: " + getTime());

        if (showLight) {
            if (currentTimeOfDayInHours == 10f && day && !secondRound || currentTimeOfDayInHours == 9f && day && secondRound) {
                lightGONight.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightGONight.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightNight.intensity = 0.8f;
            } else if (currentTimeOfDayInHours == 11f && day && !secondRound || currentTimeOfDayInHours == 10f && day && secondRound) {
                lightGODay.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightGODay.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightGODay.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightGONight.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightDay.intensity = 0;
                currentTimeOfDayInHours = -1;
                day = false;
            } else if (currentTimeOfDayInHours == 10f && !day && !secondRound || currentTimeOfDayInHours == 9f && !day && secondRound) {
                lightGODay.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightGODay.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightDay.intensity = 1f;
            } else if (currentTimeOfDayInHours == 11f && !day && !secondRound || currentTimeOfDayInHours == 10f && !day && secondRound) {
                lightGONight.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightGONight.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightGONight.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightGODay.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightNight.intensity = 0;
                currentTimeOfDayInHours = -1;
                day = true;
                secondRound = true;
            } else {
                lightGODay.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
                lightGONight.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
            }
        } else {
            if (currentTimeOfDayInHours == 11f || currentTimeOfDayInHours == 10f && secondRound) {
                day = day ? false : true;
                currentTimeOfDayInHours = -1;
            }
        }

        currentTimeOfDayInHours++;
    }

    //Zeit muss zwischen 0 und 23 uebergeben werden
    public void setTime (float time) {
        if (time >= 6 && time < 18) {
            day = true;
            currentTimeOfDayInHours = time - 6;
        } else if (time < 6) {
            day = false;
            currentTimeOfDayInHours = time + 6;
        } else {
            day = false;
            currentTimeOfDayInHours = time - 18;
        }
        if (showLight) {
            manualInit();
            int amount = day ? (int) currentTimeOfDayInHours : (int) currentTimeOfDayInHours + 12;
            for (int i = 0; i < amount; i++) {
                rotateSunByGivenTime ();
                rotateMoonByGivenTime ();
            }

            if (day && currentTimeOfDayInHours == 10) {
                rotateMoonByGivenTime ();
            } else if (day && currentTimeOfDayInHours == 11) {
                rotateSunByGivenTime ();
                rotateSunByGivenTime ();
                currentTimeOfDayInHours = -1;
                day = false;
                secondRound = true;
            } else if (!day && currentTimeOfDayInHours == 10) {
                rotateSunByGivenTime ();
            } else if (!day && currentTimeOfDayInHours == 11) {
                rotateMoonByGivenTime ();
                rotateMoonByGivenTime ();
                currentTimeOfDayInHours = -1;
                day = true;
                secondRound = true;
            }

            //Debug.Log ("Time: " + time + " day: " + day + " current: " + currentTimeOfDayInHours + " show: " + showLight);
            if (day && showLight) {
                lightNight.intensity = 0;
                lightDay.intensity = 1f;
            } else if (!day && showLight) {
                lightNight.intensity = 1f;
                lightDay.intensity = 0;
            }
        }

    }

    void rotateSunByGivenTime () {
        float omega = 180.0f / timeInSecForGameDay * -1;
        Vector3 middle = new Vector3 (sceneSizeX / 2, 0, sceneSizeZ / 2);
        lightGODay.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
    }

    void rotateMoonByGivenTime () {
        float omega = 180.0f / timeInSecForGameDay * -1;
        Vector3 middle = new Vector3 (sceneSizeX / 2, 0, sceneSizeZ / 2);
        lightGONight.transform.RotateAround (middle, new Vector3 (1.0f, 0, 0), omega);
    }

    public string getTime () {
        string result = "";
        if (day) {
            //6-18Uhr
            int time = (int) currentTimeOfDayInHours + 6;
            result = time.ToString () + ":00 Uhr";
        } else if (!day && currentTimeOfDayInHours > 5) {
            //1-5 Uhr
            int time = (int) currentTimeOfDayInHours - 6;
            result = time.ToString () + ":00 Uhr";
        } else if (!day) {
            //19-0 Uhr
            int time = (int) currentTimeOfDayInHours + 18;
            result = time.ToString () + ":00 Uhr";
        }
        return result;
    }

    public string getTimeHour () {
        string result = "";
        if (day) {
            //6-18Uhr
            int time = (int) currentTimeOfDayInHours + 6;
            result += time.ToString ();
        } else if (!day && currentTimeOfDayInHours > 5) {
            //1-5 Uhr
            int time = (int) currentTimeOfDayInHours - 6;
            result += time.ToString ();
        } else if (!day) {
            //19-0 Uhr
            int time = (int) currentTimeOfDayInHours + 18;
            result += time.ToString ();
        }
        return result;
    }
}