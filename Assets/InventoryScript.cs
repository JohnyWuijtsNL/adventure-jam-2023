using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] slots;
    public Sprite[] sprites;
    int[] spriteIDs;
    int currentSlot = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteIDs = new int[slots.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(int itemID)
    {
        slots[currentSlot].sprite = sprites[itemID];
        spriteIDs[currentSlot] = itemID;
        currentSlot++;
    }

    public int RemoveItem()
    {
        if (currentSlot == 0)
        {
            return -1;
        }
        currentSlot--;
        slots[currentSlot].sprite = null;
        return spriteIDs[currentSlot];
    }
}
