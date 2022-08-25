using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PersonMovement : MonoBehaviour
{
  
    public float speed = 5;
    public GameObject MiddleOfScreen;

    [SerializeField] private Animator _animator;

    private Sequence sequenceEnter;
    private Sequence sequenceLookAtScreen;

    //bool isHit = false;
    private Vector3 StartPosition;
    public LayerMask CollideableLayers;//physics layer that will cause the line to stop being drawn

    // Start is called before the first frame update
    void Start()
    {
        moveRightOrLeft(1);
        StartPosition = transform.position;
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (transform.position.x == StartPosition.x)
        { //Debug.Log("moving right");
          moveRightOrLeft(1); }
        else if (transform.position.x == -StartPosition.x)
        { //Debug.Log("moving left");
            moveRightOrLeft(0); }
       // Debug.Log("update");
    }



    void OnCollisionEnter(Collision collision)
    {
        //
        if (collision.gameObject.layer == 6)
        {Debug.Log("collsion");
            this.LookAtScreen();
        }     
        if (collision.gameObject.layer == 8)
        {
            
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Vector3 pos = this.transform.position;
            int randomNumber = Mathf.RoundToInt(Random.Range(5f, 10f));
            this.transform.DOMoveZ(pos.z + randomNumber, 0.2f);
        }
    }

    private void LookAtScreen()
    {
        sequenceLookAtScreen?.Kill();
        Vector3 rot = transform.rotation.eulerAngles;
        Vector3 rotY = rot;
        rotY.y = 180;
        sequenceLookAtScreen = DOTween.Sequence()
          .Append(transform.DORotate(rotY, 0.2f))
          .AppendInterval(1)
          .Append(transform.DORotate(rot, 0.2f));
    }
    private void moveRightOrLeft(int RightorLeft)
    {
        //Debug.Log("Right or left function");
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

}


