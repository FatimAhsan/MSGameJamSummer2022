using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawnManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public List<int> SpawnPointsInUse;
    public GameObject boyPrefab;
    public GameObject girlPrefab;

    private GameObject SpawnedPerson;

    private int randomNumber;
    int numberOfClones = 0;
    public int numberOfPeopleInLevelOne = 2;//Number of people in level one is 2
    public int numberOfHurdlesInLevelOne = -4;//Hurdles start from level 4

    int numberOfPeopleToSpawn;
    List<int> SpawnPositionsInUse;

    private int CurrentLevel = -1;//level tracker

    void Start()
    {
        CurrentLevel = -1;
        SpawnNewPeople();
    }
    private void OnEnable()
    {
        LevelManager.OnNewLevel += SpawnNewPeople;
    }

    void SpawnNewPeople()
    {
        SpawnPointsInUse.Clear();
        CurrentLevel++;
        numberOfClones = 0;

        if (numberOfPeopleToSpawn < 6)
        { numberOfPeopleToSpawn = numberOfPeopleInLevelOne + CurrentLevel; }

        for (int i = 0; i < (numberOfPeopleToSpawn); i++)
        {  SpawnPointsInUse.Add(SpawnNewPerson()); }
    }

    private GameObject[] FindGameObjectsWithLayer(int x) {
        GameObject[] goArray = FindObjectsOfType<GameObject>();
        List<GameObject> goList = new List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == x)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
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
