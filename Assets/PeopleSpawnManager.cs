using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawnManager : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject PeoplePrefab;

    private GameObject SpawnedPerson;

    void Start()
    {
        SpawnNewPerson();
    }

    private void OnEnable()
    {
       PersonMovement.OnPersonHit += SpawnNewPerson;
    }

    void SpawnNewPerson()
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0f, SpawnPoints.Length - 1));
        SpawnedPerson = (GameObject) Instantiate(PeoplePrefab, SpawnPoints[randomNumber].transform.position, SpawnPoints[randomNumber].transform.rotation);

    }
}
