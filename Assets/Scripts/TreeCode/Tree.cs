using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] FloatVariable RechenStats;
    [SerializeField] FloatVariable BrainPower;
    [SerializeField] GameObject [] FlowersBlue;
    [SerializeField] GameObject [] FlowersRed;

    private void OnEnable() {
        SpawnFlowers();
    }

    private void OnDisable() {
        DespawnFlowers();
    }


    public void OnSpawnFlower()
    {
        Debug.Log("Spawn Flower");
        SpawnFlowers();
    }

    private void DespawnFlowers()
    {
        for(int i = 0; i < FlowersBlue.Length; i++)
        {
            if(FlowersBlue[i].GetComponent<SpriteRenderer>().enabled == true)
            {
                FlowersBlue[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        for(int i = 0; i < FlowersRed.Length; i++)
        {
            if(FlowersRed[i].GetComponent<SpriteRenderer>().enabled == true)
            {
                FlowersRed[i].GetComponent<SpriteRenderer>().enabled = false;
                }
        }
    }
    
    private void SpawnFlowers()
    {
        for(int i = 0; i < FlowersBlue.Length && i < (int) BrainPower.GetValue(); i++)
        {
            if(FlowersBlue[i].GetComponent<SpriteRenderer>().enabled == false)
            {
                FlowersBlue[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        for(int i = 0; i < FlowersRed.Length && i < (int) RechenStats.GetValue(); i++)
        {
            if(FlowersRed[i].GetComponent<SpriteRenderer>().enabled == false)
            {
                FlowersRed[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
