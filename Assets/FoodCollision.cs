using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
            die();
        }
    }
    public void die()
    {
        if (gameObject != null)
        {
            GameObject parentobj = transform.parent.gameObject;
            Destroy(gameObject, 0.1f);

            Sequence newseq = parentobj.GetComponent<PersonMovement>().sequenceEnter;
            newseq?.Kill();

            newseq = parentobj.GetComponent<PersonMovement>().sequenceLookAtScreen;
            bool isright = parentobj.GetComponent<PersonMovement>().isDirectionRight;
            parentobj.GetComponent<PersonMovement>().LookAtScreenAndRun();

            
            Destroy(parentobj, 5f);
            
        }
        if (OnFoodHit != null) { OnFoodHit(); }
    }
}
