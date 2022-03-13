using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public Text lands;
    public Text air;
    public Text water;

    GameObjectFinder GameObjectFinder;

    int scoreland;
    int scoreair;
    int scorewater;
    
    public void Start()
    {
        GameObjectFinder = FindObjectOfType<GameObjectFinder>();
        scoreland = GameObjectFinder.landPollution.Length;
        scoreair = GameObjectFinder.airPollution.Length;
        scorewater = GameObjectFinder.waterPollution.Length;
    }

    public void Update()
    {
        lands.text = "There were " + scoreland.ToString() + " Sources of Land Pollution";
        air.text = "There were " + scoreair.ToString() + " Sources of Air Pollution";
        water.text = "There were " + scorewater.ToString() + " Sources of Water Pollution";
    }

}
