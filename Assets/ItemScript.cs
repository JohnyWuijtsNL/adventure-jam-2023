using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] InventoryScript inventoryScript;
    [SerializeField] int itemID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        inventoryScript.AddItem(itemID);
        Destroy(gameObject);
    }
}
