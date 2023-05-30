using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilCanScript : MonoBehaviour
{
    bool isDragging = false;
    Vector3 initialMousePosition;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = (Input.mousePosition) / 100 - initialMousePosition;
            if (transform.localPosition.x > 4.35f)
            {
                transform.localPosition = new Vector3(4.35f, transform.localPosition.y, 0);
            }
            if (transform.localPosition.x < -4.35f)
            {
                transform.localPosition = new Vector3(-4.35f, transform.localPosition.y, 0);
            }
            if (transform.localPosition.y > 2.75f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 2.75f, 0);
            }
            if (transform.localPosition.y < -2.75f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, -2.75f, 0);
            }
        }

        if (!gameManager.canInteract)
        {
            isDragging = false;
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.canInteract)
        {
            isDragging = true;
            initialMousePosition = Input.mousePosition / 100 - transform.position;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
