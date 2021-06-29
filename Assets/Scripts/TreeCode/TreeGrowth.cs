using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TreeGrowth : MonoBehaviour
{
    [SerializeField] IntVariable treeLevel;
    [SerializeField] GameObject [] trees;
    private int lastLevel;
    
    void Start()
    {
        treeLevel.SetValue(0);
        lastLevel = treeLevel.GetValue() + 1;
    }

    void Update()
    {
        if(treeLevel.GetValue() != lastLevel && trees.Length == 8)
        {
            Debug.Log("Tree Level changed from " + lastLevel + " to " + treeLevel.GetValue() + ".");
            lastLevel = treeLevel.GetValue();
            if(treeLevel.GetValue() >= 8)
            {
                treeLevel.SetValue(0);
            }
            if(treeLevel.GetValue() >= 0 && treeLevel.GetValue() < trees.Length)
            {
                for(int i = 0; i < trees.Length; i++)
                {
                    trees[i].SetActive(false);
                }
                trees[treeLevel.GetValue()].SetActive(true);
            }
        }
    }
}