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

   private void Update() {
       CheckStats(oldRechenStats, RechenStats.GetValue(), rechenFlowers, Stat.Rechen);
       CheckStats(oldBrainPower, BrainPower.GetValue(), brainFlowers, Stat.Brainpower);

       oldRechenStats = RechenStats.GetValue();
       oldBrainPower = BrainPower.GetValue();
   }

    private void CheckStats(float oldStats, float newStats, int flowers, Stat statType) 
    { 
        if (oldStats != newStats)
        {
            Debug.Log("Changing Stats; New FlowerLevel: " + (int)(newStats - flowerThreshhold) + "; Current Flower Level: " + flowers + "; Current BrainPower: " + newStats);
            if((int)(newStats - flowerThreshhold) > flowers)
            { 
                SpawnFlower(statType, flowers);
            }
        }
    }
    private void SpawnFlower(Stat statType, int noFlowers)
    {
        switch (statType)
        {
            case Stat.Rechen:
                for(int i = 0; i < noFlowers && i < FlowersBlue.Length; i++)
                {
                    FlowersBlue[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                rechenFlowers = Mathf.Min(noFlowers, FlowersBlue.Length-1);
                break;
            case Stat.Brainpower:
            for(int i = 0; i < noFlowers && i < FlowersBlue.Length; i++)
                {
                    FlowersRed[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                brainFlowers = Mathf.Min(noFlowers, FlowersRed.Length-1);
                break;
            default:
                break;
        }
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
        
    }


    private void OnDisable() {
        DespawnFlowers(Stat.Rechen);
        DespawnFlowers(Stat.Brainpower);
    }
}
