using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHandler : MonoBehaviour
{
    public int TreeStage; //for example 0 = no tree, 1 = Tree planted, 2 = Tree Grown
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;

    public float stat1;
    public float stat2;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
    }

    void ChangeSprite(int sprite)
    {
        spriteRenderer.sprite = spriteArray[sprite];
    }
}
