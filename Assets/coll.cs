using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class coll : MonoBehaviour
{
    public delegate void PersonHit();
    public static event PersonHit OnPersonHit;//from https://www.youtube.com/watch?v=NWNH9XRtuIc

    private Sequence sequenceLookAtScreen;
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collsion");
        if (collision.gameObject.layer == 6) { 
            sequenceLookAtScreen?.Kill();
            Vector3 rot = transform.rotation.eulerAngles;
            Vector3 rotY = rot;
            rotY.y = 180;
            sequenceLookAtScreen = DOTween.Sequence()
              .Append(transform.DORotate(rotY, 0.2f))
              .AppendInterval(10)
              .Append(transform.DORotate(rot, 0.2f));
        }


    }
    public void die()
    {
        if (gameObject != null) { Destroy(transform.parent.gameObject, 0.1f); }
        if (OnPersonHit != null) { OnPersonHit(); }
    }
}
