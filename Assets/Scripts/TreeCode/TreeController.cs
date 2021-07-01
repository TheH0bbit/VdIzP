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

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetTreeValues(float bp, float rp, int treeID)
    {
        trees[treeID].GetComponent<TreeHandler>().SetTreeStats(bp, rp);
        trees[treeID].GetComponent<TreeHandler>().CreateFlowers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

