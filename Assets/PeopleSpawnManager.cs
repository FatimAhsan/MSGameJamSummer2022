using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawnManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public List<int> SpawnPointsInUse;
    public GameObject PeoplePrefab;

    private GameObject SpawnedPerson;

    private int randomNumber;
    int numberOfClones = 0;
    public int numberOfPeopleInLevelOne = 2;//Number of people in level one is 2
    public int numberOfHurdlesInLevelOne = -4;//Hurdles start from level 4

    private int CurrentLevel = 0;//level tracker

    void Start()
    {
        CurrentLevel = 0;
        for (int i = 0; i < numberOfPeopleInLevelOne; i++)
        { SpawnNewPerson(); }
    }
    private void OnEnable()
    {
        LevelManager.OnNewLevel += SpawnNewPeople;
    }

    void SpawnNewPeople()
    {
        CurrentLevel++;
        numberOfClones = 0;
        Debug.Log("Making new people: " + (numberOfPeopleInLevelOne + CurrentLevel));
        for (int i = 1; i <= (numberOfPeopleInLevelOne + CurrentLevel); i++)
        { SpawnNewPerson(); }
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

    void SpawnNewPerson()
    { 
        randomNumber = Mathf.RoundToInt(Random.Range(0f, SpawnPoints.Length - 1));
        SpawnedPerson = (GameObject) Instantiate(PeoplePrefab, SpawnPoints[randomNumber].transform.position, SpawnPoints[randomNumber].transform.rotation);
        SpawnedPerson.name = "Clone " + numberOfClones;
        numberOfClones++;
    }
}
