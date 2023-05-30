using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class WaterRuneManager : MonoBehaviour
{
    [SerializeField] bool[] isActivated;
    bool gameCompleted = false;
    [SerializeField] GameManager gameManager;
    [SerializeField] DialogueRunner dialogueRunner;
    bool cutsceneHasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateRune (int runeId)
    {
        isActivated[runeId] = true;

        gameCompleted = true;
        foreach (var rune in isActivated)
        {
            if (!rune)
            {
                gameCompleted = false;
            }
        }

        if (gameCompleted && !cutsceneHasPlayed)
        {
            gameManager.RunDialogue("unsealFireDemon");
            cutsceneHasPlayed = true;
        }
    }
}
