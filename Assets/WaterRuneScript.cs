using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRuneScript : MonoBehaviour
{
    WaterRuneManager waterRuneManager;
    [SerializeField] int runeId;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite activatedSprite;
    // Start is called before the first frame update
    void Start()
    {
        waterRuneManager = FindObjectOfType<WaterRuneManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("oil"))
        {
            waterRuneManager.ActivateRune(runeId);
            spriteRenderer.sprite = activatedSprite;
        }
    }
}
