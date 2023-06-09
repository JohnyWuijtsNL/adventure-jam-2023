using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysScript : MonoBehaviour
{
    [SerializeField] ChaosRuneScript[] chaosRunes;
    bool isPlaying = false;
    int[] sequence;
    int sequenceLength = 3;
    float sequenceDelay = 1.3f;
    int currentRune;
    [SerializeField] SpriteRenderer[] lights;
    int currentLight = 0;
    // Start is called before the first frame update
    void Start()
    {
        sequence = new int[sequenceLength];
        for (int i = 0; i < sequenceLength; i++)
        {
            sequence[i] = Random.Range(0, chaosRunes.Length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sequenceDelay);
        if (sequenceDelay < 0 && !isPlaying)
        {
            
            chaosRunes[sequence[currentRune]].glowNumber = Mathf.PI * 1.5f;
            chaosRunes[sequence[currentRune]].onSprite.color = new Color(1, 1, 1, 0);
            currentRune++;
            if (currentRune >= sequence.Length)
            {
                isPlaying = true;
                currentRune = 0;
            }
            sequenceDelay = 1.3f;
        }

        if (isPlaying && sequenceDelay < 0)
        {
            foreach (var chaosRune in chaosRunes)
            {
                chaosRune.clickable = true;
            }
        }
        sequenceDelay -= Time.deltaTime;
    }

    public void RuneClicked(int runeNumber)
    {
        if (sequence[currentRune] == runeNumber)
        {
            currentRune++;
            if (currentRune >= sequence.Length)
            {
                sequenceDelay = 3;
                isPlaying = false;
                currentRune = 0;
                Debug.Log("You won!");
                foreach (var chaosRune in chaosRunes)
                {
                    chaosRune.clickable = false;
                    chaosRune.onSprite.color = new Color(1, 1, 1, 0);
                    chaosRune.glowNumber = Mathf.PI * 0.5f;
                }

                sequenceLength++;
                sequence = new int[sequenceLength];
                for (int i = 0; i < sequenceLength; i++)
                {
                    sequence[i] = Random.Range(0, chaosRunes.Length);
                }

                lights[currentLight].color = new Color(0, 1, 0, 1);
                currentLight++;
            }
        }
        else
        {
            sequenceDelay = 3;
            sequenceLength = 3;
            sequence = new int[sequenceLength];
            isPlaying = false;
            currentRune = 0;
            currentLight = 0;
            foreach (var chaosRune in chaosRunes)
            {
                chaosRune.clickable = false;
                chaosRune.onSprite.color = new Color(1, 0, 0, 0);
                chaosRune.glowNumber = Mathf.PI * 0.5f;
            }

            foreach (var light in lights)
            {
                light.color = new Color(0.25f, 0.25f, 0.25f, 1);
            }

            for (int i = 0; i < sequenceLength; i++)
            {
                sequence[i] = Random.Range(0, chaosRunes.Length);
            }

            
        }
    }
}
