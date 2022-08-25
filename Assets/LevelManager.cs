using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public delegate void NewLevel();
    public static event NewLevel OnNewLevel;//from https://www.youtube.com/watch?v=NWNH9XRtuIc
    public static LevelManager instance;

    public int Level = 1;
    int howManyFoodCollsionSinceLevelStarted = 0;

    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
    }
    private void OnEnable()
    {
        FoodCollision.OnFoodHit += Increase_howManyFoodCollsionSinceLevelStarted;
    }

    void Increase_howManyFoodCollsionSinceLevelStarted()
    {
        
        howManyFoodCollsionSinceLevelStarted++;Debug.Log(howManyFoodCollsionSinceLevelStarted);
        if(howManyFoodCollsionSinceLevelStarted == (Level + 1)) 
        {
            Debug.Log("LEVEL INCREASED : " + Level);
            IncreaseLevel(); 
        }
    }
    void IncreaseLevel()
    {
        Level++;
        howManyFoodCollsionSinceLevelStarted = 0;
        if (OnNewLevel != null) { OnNewLevel(); }
    }
}
