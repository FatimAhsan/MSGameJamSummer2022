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

    /*private void Awake()
    {
        // First time run
        if (instance == null)
        {
            // Save a reference to 'this'
            instance = this;
        }
    }*/

    // Start is called before the first frame update
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
        Debug.Log("Food collected: "+ howManyFoodCollsionSinceLevelStarted + " with many people:" + NumberOfPeopleOnScene) ;
        if(howManyFoodCollsionSinceLevelStarted == NumberOfPeopleOnScene) 
        {
            Debug.Log("LEVEL INCREASED : " + Level);
            SendNewLevelEvent();
        }
    }

    public void SendNewLevelEvent()
    {
        howManyFoodCollsionSinceLevelStarted = 0;
        SceneManager.LoadScene(2);
    }
}
