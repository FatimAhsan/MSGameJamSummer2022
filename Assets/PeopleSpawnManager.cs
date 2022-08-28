using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawnManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public Transform[] HurdleSpawnPoints;

    public List<int> SpawnPointsInUse;
    public List<int> HurdleSpawnPointsInUse;
    private List<GameObject> HurdlesInstantiated = new List<GameObject>();

    public GameObject boyPrefab;
    public GameObject girlPrefab;

    //we have 5 hurdles, bench , bush, lamp, tree_1, tree_3
    public GameObject Bench;
    public GameObject Bush;
    public GameObject Lamp;
    public GameObject tree_1;
    public GameObject tree_3;

    private GameObject SpawnedPerson;
    private GameObject SpawnedHurdle;

    private int randomNumber;
    int numberOfClones = 0;
    public int numberOfPeopleInLevelOne = 2;//Number of people in level one is 2
    public int numberOfHurdlesInLevelOne = -1;//Hurdles start from level 2

    int numberOfPeopleToSpawn = 2;
    int numberOfHurdlesToSpawn = 0;

    private int CurrentLevel = -1;//level tracker

    void Start()
    {
        CurrentLevel = -1;
        SpawnNewStuff();
    }
    private void OnEnable()
    {
        LevelManager.OnNewLevel += SpawnNewStuff;
    }
    void SpawnNewStuff()
    {        
        CurrentLevel++;
        SpawnNewPeople();
        if(CurrentLevel > 1)
            SpawnHurdles();
    }
    void SpawnNewPeople()
    {
        SpawnPointsInUse.Clear();
        numberOfClones = 0;

        if (CurrentLevel<4)
        { numberOfPeopleToSpawn = numberOfPeopleInLevelOne + CurrentLevel; }
        else { numberOfPeopleToSpawn = Mathf.RoundToInt(Random.Range(1f, 5f)); }

        for (int i = 0; i < (numberOfPeopleToSpawn); i++)
        {  SpawnPointsInUse.Add(SpawnNewPerson()); }

        LevelManager.instance.NumberOfPeopleOnScene = numberOfPeopleToSpawn;
    }

    void SpawnHurdles()
    {
        HurdlesInstantiated.ForEach(Destroy);
        HurdleSpawnPointsInUse.Clear();

        if (CurrentLevel < 4)
        { numberOfHurdlesToSpawn = numberOfHurdlesInLevelOne + CurrentLevel; }
        else { numberOfHurdlesToSpawn = Mathf.RoundToInt(Random.Range(1f, 5f)); }

        for (int i = 0; i < (numberOfHurdlesToSpawn); i++)
        {  HurdleSpawnPointsInUse.Add(SpawnNewHurdle()); }

    }

    int SpawnNewHurdle()
    {
        randomNumber = Mathf.RoundToInt(Random.Range(0f, SpawnPoints.Length - 1));
        int newRandomnumber = Mathf.RoundToInt(Random.Range(0f, 4f));//we have 5 hurdles, bench , bush, lamp, tree_1, tree_3

        while (HurdleSpawnPointsInUse.Contains(randomNumber))
        {
            if (HurdleSpawnPointsInUse.Contains(randomNumber))
            { randomNumber = Mathf.RoundToInt(Random.Range(0f, HurdleSpawnPoints.Length - 1)); }
            else { break; }
        }


        if (newRandomnumber == 0)
            SpawnedHurdle = (GameObject)Instantiate(Bench, HurdleSpawnPoints[randomNumber].transform.position, Bench.transform.rotation);
        else if(newRandomnumber == 1)
            SpawnedHurdle = (GameObject)Instantiate(Bush, HurdleSpawnPoints[randomNumber].transform.position, Bush.transform.rotation);
        else if (newRandomnumber == 2)
            SpawnedHurdle = (GameObject)Instantiate(Lamp, HurdleSpawnPoints[randomNumber].transform.position, Lamp.transform.rotation);
        else if (newRandomnumber == 3)
            SpawnedHurdle = (GameObject)Instantiate(tree_1, HurdleSpawnPoints[randomNumber].transform.position, tree_1.transform.rotation);
        else
            SpawnedHurdle = (GameObject)Instantiate(tree_3, HurdleSpawnPoints[randomNumber].transform.position, tree_3.transform.rotation);

        HurdlesInstantiated.Add(SpawnedHurdle);

        return randomNumber;
    }
    int SpawnNewPerson()
    { 
        randomNumber = Mathf.RoundToInt(Random.Range(0f, SpawnPoints.Length - 1));
        int newRandomnumber = Mathf.RoundToInt(Random.Range(0f, 1f));

        while (SpawnPointsInUse.Contains(randomNumber))
        {
            if (SpawnPointsInUse.Contains(randomNumber)) 
            { randomNumber = Mathf.RoundToInt(Random.Range(0f, SpawnPoints.Length - 1)); }
            else { break; }
        }


        if(newRandomnumber == 0)
            SpawnedPerson = (GameObject) Instantiate(boyPrefab, SpawnPoints[randomNumber].transform.position, SpawnPoints[randomNumber].transform.rotation);
        else
            SpawnedPerson = (GameObject)Instantiate(girlPrefab, SpawnPoints[randomNumber].transform.position, SpawnPoints[randomNumber].transform.rotation);
        
        
        SpawnedPerson.name = "Clone " + numberOfClones;
        numberOfClones++;

        return randomNumber;
    }
}
