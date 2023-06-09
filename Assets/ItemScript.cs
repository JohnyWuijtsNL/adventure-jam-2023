using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] InventoryScript inventoryScript;
    public bool isUnlocked;

    

    bool isDragging = false;
    Vector3 initialMousePosition;
    Vector3 initialPosition;
    GameManager gameManager;
    InventoryScript inventory;
    bool positionAvailable;
    public int activePage;
    GameObject currentSlot = null;
    [SerializeField] string itemID;
    float draggingTimer = 0;
    float barkDelay = 0.25f;
    float barkTimer = -1000;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        inventory = FindObjectOfType<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = (Input.mousePosition) / (Screen.width / 19.2f) - initialMousePosition;
            initialPosition = transform.localPosition;
            if (transform.localPosition.x > 3.9f)
            {
                initialPosition = new Vector3(3.9f, initialPosition.y, 0);
            }
            if (transform.localPosition.x < -3.9f)
            {
                initialPosition = new Vector3(-3.9f, initialPosition.y, 0);
            }
            if (transform.localPosition.y > 2.6f)
            {
                initialPosition = new Vector3(initialPosition.x, 2.6f, 0);
            }
            if (transform.localPosition.y < -2.6f)
            {
                initialPosition = new Vector3(initialPosition.x, -2.6f, 0);
            }

            draggingTimer += Time.deltaTime;
        }
        else
        {
            if (currentSlot!= null)
            {
                activePage = -1;
            }
            else if (activePage == -1)
            {
                activePage = gameManager.currentPage;
            }
        }

        if (!gameManager.canInteract)
        {
            isDragging = false;
        }

        if (barkTimer < 0 && barkTimer > -100)
        {
            gameManager.RunDialogue(itemID);
            barkTimer = -1000;
        }

        barkTimer -= Time.deltaTime;
    }

    private void OnMouseDown()
    {
        if (gameManager.canInteract)
        {
            isDragging = true;
            initialMousePosition = Input.mousePosition / (Screen.width / 19.2f) - transform.position;
        }
    }

    /*private void OnMouseDown()
    {
        inventoryScript.AddItem(itemID);
        Destroy(gameObject);
    }*/

    private void OnMouseUp()
    {
        
        if (isDragging)
        {
            isDragging = false;
            if (currentSlot != null)
            {
                transform.position = currentSlot.transform.localPosition;
                currentSlot.GetComponent<SlotScript>().isEmpty = false;
                inventoryScript.slots[currentSlot.GetComponent<SlotScript>().slotNumber].sprite = null;
            }
            else
            {
                transform.localPosition = initialPosition;
            }

            if (draggingTimer < 0.25f)
            {
                barkTimer = barkDelay;
            }

            draggingTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("slot"))
        {
            if (collision.gameObject.GetComponent<SlotScript>().isEmpty && currentSlot == null)
            {
                currentSlot = collision.gameObject;
                
                inventoryScript.slots[currentSlot.GetComponent<SlotScript>().slotNumber].sprite = GetComponent<SpriteRenderer>().sprite;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("slot"))
        {
            if (collision.gameObject.GetComponent<SlotScript>().isEmpty)
            {
                currentSlot = collision.gameObject;
                inventoryScript.slots[currentSlot.GetComponent<SlotScript>().slotNumber].sprite = null;
            }
            if (collision.gameObject == currentSlot)
            {
                currentSlot.GetComponent<SlotScript>().isEmpty = true;
                currentSlot = null;
            }
        }
        
    }
}
