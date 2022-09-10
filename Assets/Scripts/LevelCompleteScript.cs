using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void nextLevel()
    {
        if (LevelSelector.selectedLevel != 10)
        {
            LevelSelector.selectedLevel++;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        }
        else openLevels();
    }

    public void openLevels()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
