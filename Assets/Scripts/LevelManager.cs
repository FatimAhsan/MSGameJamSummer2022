using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //public delegate void NewLevel();
    //public static event NewLevel OnNewLevel;//from https://www.youtube.com/watch?v=NWNH9XRtuIc
    //public static LevelManager instance;

    public ParticleSystem rightParticle;
    public ParticleSystem leftParticle;

    private int NumberOfPeopleOnScene =0;

    public static int Level;
    public int howManyFoodCollsionSinceLevelStarted = 0;
    void Start()
    {
        Level = LevelSelector.selectedLevel;
        if (Level < 4)
            NumberOfPeopleOnScene = 1 + Level;
        else NumberOfPeopleOnScene = 5;
    }
    public void ResetColiisons() { howManyFoodCollsionSinceLevelStarted = 0;Debug.Log("done"); NumberOfPeopleOnScene = 0; }
    private void OnEnable()
    {
       PersonMovement.OnFoodHit += Increase_howManyFoodCollsionSinceLevelStarted;
    }
    void ResetCollsions() { howManyFoodCollsionSinceLevelStarted = 10; }
    void Increase_howManyFoodCollsionSinceLevelStarted()
    {
        howManyFoodCollsionSinceLevelStarted++;
        Debug.Log("How many people on scene:" + NumberOfPeopleOnScene + "   food collsions since start:" + howManyFoodCollsionSinceLevelStarted);

        if(howManyFoodCollsionSinceLevelStarted == NumberOfPeopleOnScene) 
        {
            rightParticle.Play();
            leftParticle.Play();
            StartCoroutine(ExampleCoroutine());
            SendNewLevelEvent();
        }
    }

    public void SendNewLevelEvent()
    {

        
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(4);
        NumberOfPeopleOnScene = 0;
        howManyFoodCollsionSinceLevelStarted = 0;
        SceneManager.LoadScene(2);
    }
}
