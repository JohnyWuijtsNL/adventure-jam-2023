using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class InventoryScript : MonoBehaviour
{
    public SpriteRenderer[] slots;
    [SerializeField] GameObject[] items;
    [SerializeField] GameManager gameManager;
    int[] spriteIDs;
    int currentSlot = 0;

    [SerializeField] DialogueViewBase dialogueViewBase;
    // Start is called before the first frame update
    void Start()
    {
        spriteIDs = new int[slots.Length];
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in items)
        {
            if ((item.GetComponent<ItemScript>().activePage == gameManager.currentPage || item.GetComponent<ItemScript>().activePage == -1) && item.GetComponent<ItemScript>().isUnlocked)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }
}
