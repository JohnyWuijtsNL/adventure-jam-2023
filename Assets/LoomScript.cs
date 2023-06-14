using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoomScript : MonoBehaviour
{
    public int stringCount = 0;
    [SerializeField] GameObject cloth;
    // Update is called once per frame
    void Update()
    {
        if (stringCount == 6)
        {
            cloth.GetComponent<ItemScript>().isUnlocked = true;
        }
    }
}
