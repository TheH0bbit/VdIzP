using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField] float flowerThreshhold = 1f;
    [SerializeField] FloatVariable RechenStats;
    private float oldRechenStats;
    private int rechenFlowers = 0;

    [SerializeField] FloatVariable BrainPower;
    private float oldBrainPower;
    private int brainFlowers = 0;

   [SerializeField] GameObject [] FlowersBlue;
   [SerializeField] GameObject [] FlowersRed;
   [SerializeField] BooleanVariable firstTimeLoaded;


    private void Start() {
        if(true)
        {
            for(int i = 0; i < FlowersBlue.Length; i++)
            {
            FlowersBlue[i].GetComponent<SpriteRenderer>().enabled = false;
            }
            for(int i = 0; i < FlowersRed.Length; i++)
            {
                FlowersRed[i].GetComponent<SpriteRenderer>().enabled = false;
            }
            RechenStats.SetValue(0);
            BrainPower.SetValue(0);
            oldRechenStats = 0f;
            oldBrainPower = 0f;
            firstTimeLoaded.SetValue(false);
        }
    }

    private void CheckStats(float oldStats, float newStats, int flowers, Stat statType) 
    { 
        if (oldStats != newStats)
        {
            //Debug.Log("Changing Stats; New FlowerLevel: " + (int)(newStats - flowerThreshhold) + "; Current Flower Level: " + flowers + "; Current BrainPower: " + newStats);
            if((int)(newStats - flowerThreshhold) > flowers)
            { 
                //SpawnFlower(statType, flowers);
            }
        }
    }

    public void OnSpawnFlower()
    {
        Debug.Log("Spawn Flower");
    }

    private void DespawnFlowers(Stat statType)
    {
        switch (statType)
        {
            case Stat.Rechen:
                for(int i = 0; i < FlowersBlue.Length; i++)
                {
                    if(FlowersBlue[i].GetComponent<SpriteRenderer>().enabled == true)
                    {
                        FlowersBlue[i].GetComponent<SpriteRenderer>().enabled = false;
                    }
                }
                break;
            case Stat.Brainpower:
            for(int i = 0; i < FlowersBlue.Length; i++)
                if(FlowersRed[i].GetComponent<SpriteRenderer>().enabled == true)
                    {
                        FlowersRed[i].GetComponent<SpriteRenderer>().enabled = false;
                    }
                break;
            default:
                break;
        }
    }

    private void OnEnable() {
        SpawnFlowers(FlowersBlue);
    }


    private void OnDisable() {
        DespawnFlowers(Stat.Rechen);
        DespawnFlowers(Stat.Brainpower);
    }

    private void SpawnFlowers(GameObject[] flowers)
    {
        for(int i = 0; i < flowers.Length && i < (int) BrainPower.GetValue(); i++)
        {
            if(FlowersBlue[i].GetComponent<SpriteRenderer>().enabled == false)
            {
                FlowersBlue[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
