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
            Debug.Log(100 / Screen.width * Input.mousePosition.x);
            transform.position = (Input.mousePosition) / (Screen.width / 19.2f) - initialMousePosition;
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
            initialMousePosition = Input.mousePosition / (Screen.width / 19.2f) - transform.position;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
