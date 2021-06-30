using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TreeGrowth : MonoBehaviour
{
    [SerializeField] IntVariable treeLevel;
    [SerializeField] GameObject [] trees;
    [SerializeField] BooleanVariable playedMinigame;
    
    void Start()
    {
        GrowTree();

        //StartNewWeek();
    }

    public void GrowTree()
    {
        
        if(treeLevel.GetValue() >= trees.Length)
        {
            Debug.Log("Growing Tri smol");
            treeLevel.SetValue(0);
        }
        if(treeLevel.GetValue() >= 0 && treeLevel.GetValue() < trees.Length)
        {
            Debug.Log("Activating tree stage " + treeLevel.GetValue());
            for(int i = 0; i < trees.Length; i++)
            {
                trees[i].SetActive(false);
            }
            trees[treeLevel.GetValue()].SetActive(true);
        }
    }

    public void StartNewWeek()
    {
        Debug.Log("New Week for new Tree uwu");
        treeLevel.SetValue(0);
        GrowTree();
    }
}