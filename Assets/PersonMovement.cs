using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PersonMovement : MonoBehaviour
{
    public delegate void PersonHit();
    public static event PersonHit OnPersonHit;//from https://www.youtube.com/watch?v=NWNH9XRtuIc

    public float speed = 5;
    public GameObject MiddleOfScreen;

    [SerializeField] private Animator _animator;

    private Sequence sequenceEnter;
    //bool isHit = false;
    private Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        moveRightOrLeft(1);
        StartPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {

        if (transform.position.x == StartPosition.x)
        { Debug.Log("moving right"); moveRightOrLeft(1); }
        else if (transform.position.x == -StartPosition.x)
        { Debug.Log("moving left"); moveRightOrLeft(0); }
       // Debug.Log("update");
    }
    private void moveRightOrLeft(int RightorLeft)
    {
        Debug.Log("Right or left function");
        sequenceEnter?.Kill();
        Vector3 pos = transform.position;
        float distance = pos.x * 2;
        float duration = distance / speed;
        pos.x = -pos.x;
        Vector3 rot = transform.rotation.eulerAngles;

        if (RightorLeft == 1)
        {
            sequenceEnter = DOTween.Sequence()
              .Append(transform.DORotate(-rot, 0.2f))
              .Join(transform.DOMove(pos, 5f));
        }
        else
        {
            sequenceEnter = DOTween.Sequence()
              .Append(transform.DORotate(-rot, 0.2f))
              .Join(transform.DOMove(pos, 5f));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collsion");
        if (collision.gameObject.layer == 6) { die(); }

    }

    public void die()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Collider>().enabled = false;

        if (gameObject != null) { Destroy(gameObject, 0.1f); }
        if(OnPersonHit != null) { OnPersonHit(); }
    }
}


