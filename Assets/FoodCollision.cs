using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Debug.Log("Collision with ");
            LevelProgressionManager.instance.AddPoint();
        }
    }
}
