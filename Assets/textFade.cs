using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textFade : MonoBehaviour
{
    public Text text;

    void Start()
    {
        if (LevelSelector.selectedLevel == 1)
        {
            text.text = "DRAG TO AIM!";
        }
        else if(LevelSelector.selectedLevel == 4)
        {
            text.text = "AIM AT THE HELMETS TO DROP THEM!";
        }
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        text.CrossFadeAlpha(0.0f, 2f, false);
    }
}
