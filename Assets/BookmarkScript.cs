using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookmarkScript : MonoBehaviour
{
    [SerializeField] int bookmarkNumber;
    [SerializeField] BookmarksScript bookmarksScript;
    GameManager gameManager;
    public bool isLeft = false;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (gameManager.canInteract)
        {
            bookmarksScript.BookmarkClicked(bookmarkNumber);
        }
    }

}
