using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadScene(1);
    }

    public void nextLevel()
    {
        if (LevelSelector.selectedLevel != 10)
        {
            LevelSelector.selectedLevel++;
            SceneManager.LoadScene(1);
        }
    }

    public void openLevels()
    {
        SceneManager.LoadScene(0);
    }
}
