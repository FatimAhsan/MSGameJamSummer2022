using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public delegate void PebbleHit();
    public static event PebbleHit OnPebbleHit;//from https://www.youtube.com/watch?v=NWNH9XRtuIc

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer != 6)
          Destroy(this.gameObject);
        if (OnPebbleHit != null) { OnPebbleHit(); }
    }
}
