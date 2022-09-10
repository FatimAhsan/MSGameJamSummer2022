using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FoodCollision : MonoBehaviour
{
    /*
    GameObject parentobj;

    void Start()
    {
        parentobj = transform.parent.gameObject;
    }

    void Update()
    {
        if (parentobj.GetComponent<PersonMovement>().isHit)
        {
            if (OnFoodHit != null) { OnFoodHit(); }
            Destroy(this.gameObject);
        }
    }

    public void die()
    {
        if (gameObject != null)
        {
            GameObject parentobj = transform.parent.gameObject;

            if (parentobj.GetComponent<PersonMovement>().isHit)
            {
                // Destroy(gameObject, 0.1f);

                // Sequence newseq = parentobj.GetComponent<PersonMovement>().sequenceEnter;
                //newseq?.Kill();

                //newseq = parentobj.GetComponent<PersonMovement>().sequenceLookAtScreen;
                //bool isright = parentobj.GetComponent<PersonMovement>().isDirectionRight;
                //parentobj.GetComponent<PersonMovement>().LookAtScreenAndRun();
                
                Destroy(parentobj);
                if (OnFoodHit != null) { OnFoodHit(); }
            }
        }
        
    }*/
}
