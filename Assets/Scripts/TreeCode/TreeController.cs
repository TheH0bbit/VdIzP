using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public GameObject[] trees;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetTreeValues(float bp, float rp, int treeID)
    {
        trees[treeID].GetComponent<TreeHandler>().SetTreeStats(bp, rp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
