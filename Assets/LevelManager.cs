using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void NewLevel();
    public static event NewLevel OnNewLevel;//from https://www.youtube.com/watch?v=NWNH9XRtuIc
    public static LevelManager instance;

    public int NumberOfPeopleOnScene =0;

    public int Level = 1;
    int howManyFoodCollsionSinceLevelStarted = 0;

    private void Awake()
    {
        // First time run
        if (instance == null)
        {
            // Save a reference to 'this'
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Level = LevelSelector.selectedLevel;
    }
    private void OnEnable()
    {
        FoodCollision.OnFoodHit += Increase_howManyFoodCollsionSinceLevelStarted;
    }

    void Increase_howManyFoodCollsionSinceLevelStarted()
    {
        
        howManyFoodCollsionSinceLevelStarted++;Debug.Log(howManyFoodCollsionSinceLevelStarted);
        if(howManyFoodCollsionSinceLevelStarted == NumberOfPeopleOnScene) 
        {
            Debug.Log("LEVEL INCREASED : " + Level);
            IncreaseLevel(); 
        }
    }
    void IncreaseLevel()
    {
        Level++;
        howManyFoodCollsionSinceLevelStarted = 0;
        //LevelProgressionManager.instance.AddPoint();
        if (OnNewLevel != null) { OnNewLevel(); }
    }
}
