using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHandler : MonoBehaviour
{
    public GameObject[] redFlowerArray;
    public GameObject[] blueFlowerArray;
    private SpriteRenderer spriteRenderer;
    public int TreeID;
    [SerializeField] IntVariable CurrTree;
    [SerializeField] FloatVariable Stat1;
    [SerializeField] FloatVariable Stat2;

    public float Stat1Stored;
    public float Stat2Stored;
    [SerializeField] private bool initiated;

    [SerializeField] private CanvasGroup CG;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        CG = GameObject.Find("StatsCanvas").GetComponent<CanvasGroup>();
        CG.alpha = 0;
        initiated = false;
        //spriteRenderer.enabled = false;
        InitFlowers();
        CreateFlowers();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat("Stat1" + TreeID, Stat1Stored);
        PlayerPrefs.SetFloat("Stat2" + TreeID, Stat2Stored);
        if(initiated)
            PlayerPrefs.SetInt("Init" + TreeID, 1);
        else
            PlayerPrefs.SetInt("Init" + TreeID, 0);
    }

    void OnEnable()
    {
        Stat1Stored = PlayerPrefs.GetFloat("Stat1" + TreeID);
        Stat2Stored = PlayerPrefs.GetFloat("Stat2" + TreeID);
        int test = PlayerPrefs.GetInt("Init" + TreeID);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        CreateFlowers();
        
    }

    public void SetTreeStats(float bp, float rp)
    {
        if(TreeID == CurrTree.GetValue())
        Stat1Stored = bp;
        Stat2Stored = rp;
        if (!initiated)
        {
            spriteRenderer.enabled = true;
            initiated = true;
        }
    }


    private void OnMouseEnter()
    {
        Stat1.SetValue(Stat1Stored*0.05f);
        Stat2.SetValue(Stat2Stored*0.05f);
        CG.alpha = 1;
        CG.interactable = true;
        CG.blocksRaycasts = true;
    }

    private void OnMouseExit()
    {
        CG.alpha = 0;
        CG.interactable = false;
        CG.blocksRaycasts = false;
    }


    public void CreateFlowers()
    {
        for(int i=0; i < Mathf.Clamp((int)Mathf.Round(Stat2Stored), 0, 3); i++)
        {
            redFlowerArray[i].GetComponent<SpriteRenderer>().enabled = true;
        }
        for (int i = 0; i < Mathf.Clamp((int)Mathf.Round(Stat1Stored), 0, 3); i++)
        {
            blueFlowerArray[i].GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void InitFlowers()
    {
        for (int i = 0; i < redFlowerArray.Length; i++)
        {
            redFlowerArray[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        for (int i = 0; i < blueFlowerArray.Length; i++)
        {
            blueFlowerArray[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    void ChangeSprite(int sprite)
    {
       // spriteRenderer.sprite = spriteArray[sprite];
    }
}
