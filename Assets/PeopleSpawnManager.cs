using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawnManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public List<int> SpawnPointsInUse;
    public GameObject PeoplePrefab;

    private GameObject SpawnedPerson;

    private int randomNumber = 6;
    int numberOfClones = 0;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        { SpawnNewPerson(); }
    }
    void Update()
    {
        //SpawnPointsInUse = 
    }

    private void OnEnable()
    {
       FoodCollision.OnFoodHit += SpawnNewPerson;
    }

    void SpawnNewPerson()
    { 
        randomNumber = Mathf.RoundToInt(Random.Range(0f, SpawnPoints.Length - 1));
        SpawnedPerson = (GameObject) Instantiate(PeoplePrefab, SpawnPoints[randomNumber].transform.position, SpawnPoints[randomNumber].transform.rotation);
        SpawnedPerson.name = "Clone " + numberOfClones;
        numberOfClones++;
    }
}
