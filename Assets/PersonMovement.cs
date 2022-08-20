using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PersonMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

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
            if (transform.position == startPoint.position)
                moveRightOrLeft(1);
            else if (transform.position == endPoint.position)
                moveRightOrLeft(0);
        }
    }
    private void moveRightOrLeft(int RightorLeft)
    {
        sequenceEnter?.Kill();

        if (RightorLeft == 1)
        {
            transform.position = startPoint.position;
            transform.rotation = startPoint.rotation;
            sequenceEnter = DOTween.Sequence()
              .Join(transform.DOMove(endPoint.position, 3f));
        }
        else
        {
            transform.position = endPoint.position;
            transform.rotation = endPoint.rotation;
            sequenceEnter = DOTween.Sequence()
              .Join(transform.DOMove(startPoint.position, 3f));
        }
    }
}


