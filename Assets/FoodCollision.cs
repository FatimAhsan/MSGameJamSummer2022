using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollision : MonoBehaviour
{
    public delegate void FoodHit();
    public static event FoodHit OnFoodHit;//from https://www.youtube.com/watch?v=NWNH9XRtuIc


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            LevelProgressionManager.instance.AddPoint();
            die();
        }
    }
    public void die()
    {
        if (gameObject != null) { Destroy(transform.parent.gameObject, 0.1f); }
        if (OnFoodHit != null) { OnFoodHit(); }
    }
}
