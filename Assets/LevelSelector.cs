using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public static int selectedLevel;
    public int Level;
    public void PlayGame()
    {
        selectedLevel = Level;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
