using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coll : MonoBehaviour
{
    public delegate void PersonHit();
    public static event PersonHit OnPersonHit;//from https://www.youtube.com/watch?v=NWNH9XRtuIc

    
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collsion");
        if (collision.gameObject.layer == 6) {
            if (OnPersonHit != null) { OnPersonHit(); }

        }
    }
    public void die()
    {
        if (gameObject != null) { Destroy(transform.parent.gameObject, 0.1f); }
    }
}
