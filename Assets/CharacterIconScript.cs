using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Yarn.Unity;

public class CharacterIconScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] CanvasGroup canvasGroup;
    Image image;
    [SerializeField] Sprite[] characterIcons;
    [SerializeField] DialogueViewBase dialogueView;
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] LineView lineView;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (nameText.text)
        {
            case "Mage":
                image.sprite = characterIcons[0];
                break;
            case "Player":
                image.sprite = characterIcons[1];
                break;
            case "Fire Demon":
                image.sprite = characterIcons[2];
                break;
            default:
                image.sprite = null;
                break;

        }

        Debug.Log(dialogueRunner.Dialogue.LineHandler);

        image.color = new Color(1, 1, 1, canvasGroup.alpha);

        //dialogueView.UserRequestedViewAdvancement();
    }
}
