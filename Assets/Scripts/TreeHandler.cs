using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHandler : MonoBehaviour
{
    public int TreeStage; //for example 0 = no tree, 1 = Tree planted, 2 = Tree Grown
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;

    [SerializeField] FloatVariable Stat1;
    [SerializeField] FloatVariable Stat2;

    public float Stat1Stored;
    public float Stat2Stored;

    [SerializeField] private CanvasGroup CG;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        CG = GameObject.Find("StatsCanvas").GetComponent<CanvasGroup>();
        CG.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
