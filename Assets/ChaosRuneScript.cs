using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosRuneScript : MonoBehaviour
{
    [SerializeField] SimonSaysScript simonSaysScript;
    [SerializeField] int runeNumber;
    public SpriteRenderer onSprite;
    public bool clickable = false;
    public float glowNumber;
    // Start is called before the first frame update
    void Start()
    {
        glowNumber = -Mathf.PI / 2;
    }

    // Update is called once per frame
    void Update()
    {
        onSprite.color = new Color(onSprite.color.r, onSprite.color.g, onSprite.color.b, (1 + Mathf.Sin(glowNumber)) / 2);
        glowNumber -= Time.deltaTime * 5;
        if (glowNumber < -Mathf.PI / 2)
        {
            glowNumber = -Mathf.PI / 2;
        }
    }

    private void OnMouseDown()
    {
        if (clickable)
        {
            simonSaysScript.RuneClicked(runeNumber);
            glowNumber = Mathf.PI / 2;
        }
    }
}
