using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFinder : MonoBehaviour
{
    public static GameObject[] landPollution;
    public static GameObject[] waterPollution;
    public static GameObject[] airPollution;

    void Start()
    {
        landPollution = GameObject.FindGameObjectsWithTag("Litter");  //returns GameObject[]
        waterPollution = GameObject.FindGameObjectsWithTag("Toxic Water");  //returns GameObject[]
        airPollution = GameObject.FindGameObjectsWithTag("Toxic Air");  //returns GameObject[]

        LandObjectFinder();
        AirObjectFinder();
        WaterObjectFinder();
    }
    
    public void LandObjectFinder()
    {
        /*foreach(GameObject landPollution in landPollution)
        {
            slandPollution = landPollution.ToString();
            Debug.Log(slandPollution);
        }*/
        Debug.Log(landPollution.Length);
    }

    void AirObjectFinder()
    {
        /*foreach (GameObject waterPollution in waterPollution)
        {
            Debug.Log(waterPollution);
        }*/
        Debug.Log(waterPollution.Length);
    }

    void WaterObjectFinder()
    {
        /*foreach (GameObject airPollution in airPollution)
        {
            Debug.Log(airPollution);
        }*/
        Debug.Log(airPollution.Length);
    }

}
