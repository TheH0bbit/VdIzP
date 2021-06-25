using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerHandler : MonoBehaviour
{
    [SerializeField] private float flowerType;
    public Sprite[] flowerSpriteArray;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeSprite(int sprite)
    {
        spriteRenderer.sprite = flowerSpriteArray[sprite];
    }
}
