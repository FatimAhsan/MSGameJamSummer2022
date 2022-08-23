using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PersonMovement : MonoBehaviour
{
    public delegate void PersonHit();
    public static event PersonHit OnPersonHit;

    public GameObject MiddleOfScreen;

    [SerializeField] private Animator _animator;

    private Sequence sequenceEnter;
    bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        moveRightOrLeft(1);
    }
    // Update is called once per frame
    void Update()
    {
        if (!isHit)
        {
            if (transform.rotation.y == 0)
                moveRightOrLeft(1);
            else if (transform.rotation.y == 180)
                moveRightOrLeft(0);
        }
    }
    private void moveRightOrLeft(int RightorLeft)
    {
        sequenceEnter?.Kill();
        Vector3 pos = transform.position;

        if (RightorLeft == 1)
        {
            pos.x++;
            sequenceEnter = DOTween.Sequence()
              .Join(transform.DOMove(pos, 1f));
        }
        else
        {
            pos.x--;
            sequenceEnter = DOTween.Sequence()
              .Join(transform.DOMove(pos, 1f));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6) { die(); }
        else if(collision.gameObject.layer == 7) {
            float yRot = transform.rotation.y;
            this.transform.Rotate(0, -yRot, 0); }
    }

    public void die()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Collider>().enabled = false;

        if (gameObject != null) { Destroy(gameObject, 3f); }
        if(OnPersonHit != null) { OnPersonHit(); }
    }
}


