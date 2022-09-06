using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public delegate void NewLevel();
    //public static event NewLevel OnNewLevel;//from https://www.youtube.com/watch?v=NWNH9XRtuIc
    //public static LevelManager instance;

    private int NumberOfPeopleOnScene =0;

    public static int Level;
    int howManyFoodCollsionSinceLevelStarted = 0;
    void Start()
    {
        howManyFoodCollsionSinceLevelStarted = 0;
        Level = LevelSelector.selectedLevel;
        if (Level < 4)
            NumberOfPeopleOnScene = 1 + Level;
        else NumberOfPeopleOnScene = 5;
    }
    private void OnEnable()
    {
        FoodCollision.OnFoodHit += Increase_howManyFoodCollsionSinceLevelStarted;
    }

    void Increase_howManyFoodCollsionSinceLevelStarted()
    {
        howManyFoodCollsionSinceLevelStarted++;
       
        if(howManyFoodCollsionSinceLevelStarted == NumberOfPeopleOnScene) 
        {
            
            SendNewLevelEvent();
        }
    }

    public void SendNewLevelEvent()
    {
        NumberOfPeopleOnScene = 0;
        howManyFoodCollsionSinceLevelStarted = 0;
        SceneManager.LoadScene(2);
    }
}
