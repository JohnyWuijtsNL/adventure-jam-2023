using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookmarksScript : MonoBehaviour
{
    [SerializeField] GameObject[] bookmarks;
    [SerializeField] GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BookmarkClicked(int bookmarkNumber)
    {
        foreach (var bookmark in bookmarks)
        {
            bookmark.GetComponent<SpriteRenderer>().sortingOrder = -1;
            if (bookmark.GetComponent<BookmarkScript>().isLeft)
            {
                bookmark.transform.position = new Vector3(bookmark.transform.position.x * -1, bookmark.transform.position.y, bookmark.transform.position.z);
                bookmark.transform.eulerAngles = new Vector3(0, 0, bookmark.transform.eulerAngles.z * -1);
                bookmark.transform.localScale = new Vector3(bookmark.transform.localScale.x * -1, 1, 1);
                bookmark.GetComponent<BookmarkScript>().isLeft = !bookmark.GetComponent<BookmarkScript>().isLeft;
            }
        }
        for (int i = 0; i < bookmarkNumber; i++)
        {
            bookmarks[i].transform.position = new Vector3(bookmarks[i].transform.position.x * -1, bookmarks[i].transform.position.y, bookmarks[i].transform.position.z);
            bookmarks[i].transform.eulerAngles = new Vector3(0, 0, bookmarks[i].transform.eulerAngles.z * -1);
            bookmarks[i].transform.localScale = new Vector3(bookmarks[i].transform.localScale.x * -1, 1, 1);
            bookmarks[i].GetComponent<BookmarkScript>().isLeft = !bookmarks[i].GetComponent<BookmarkScript>().isLeft;
        }

        bookmarks[bookmarkNumber - 1].GetComponent<SpriteRenderer>().sortingOrder = 1;
        gameManager.ChangePage(bookmarkNumber);
    }
}
