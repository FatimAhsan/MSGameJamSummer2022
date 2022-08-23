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
        SpawnedPerson = (GameObject) Instantiate(PeoplePrefab, SpawnPoints[0].transform.position, Quaternion.identity);

    }
}
