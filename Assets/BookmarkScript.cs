using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookmarkScript : MonoBehaviour
{
    [SerializeField] int bookmarkNumber;
    [SerializeField] BookmarksScript bookmarksScript;
    public bool isLeft = false;

    private void OnMouseDown()
    {
        bookmarksScript.BookmarkClicked(bookmarkNumber);
    }

}
