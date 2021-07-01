using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHandler : MonoBehaviour
{
    public Sprite[] spriteArray;
    private SpriteRenderer spriteRenderer;
    public int TreeID;
    [SerializeField] IntVariable CurrTree;
    [SerializeField] FloatVariable Stat1;
    [SerializeField] FloatVariable Stat2;

    public float Stat1Stored;
    public float Stat2Stored;
    private bool initiated;

    [SerializeField] private CanvasGroup CG;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        CG = GameObject.Find("StatsCanvas").GetComponent<CanvasGroup>();
        CG.alpha = 0;
        initiated = false;
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        Stat1.SetValue(Stat1Stored);
        Stat2.SetValue(Stat2Stored);
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

    void ChangeSprite(int sprite)
    {
        spriteRenderer.sprite = spriteArray[sprite];
    }
}
