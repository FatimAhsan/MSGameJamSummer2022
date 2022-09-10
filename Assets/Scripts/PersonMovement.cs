using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PersonMovement : MonoBehaviour
{
    public delegate void FoodHit();
    public static event FoodHit OnFoodHit;//from https://www.youtube.com/watch?v=NWNH9XRtuIc

    //[SerializeField] private Animator a_nimator;
    //private CharacterAnimation characterAnimation;


    public float speed = 5;

    public Transform FoodPosition;

    public Sequence sequenceEnter;//public as used in FoodCollison
    public Sequence sequenceLookAtScreen;//public as used in FoodCollison

    //we have 6 food 
    public GameObject Burger;
    public GameObject Cake;
    public GameObject CakePop;
    public GameObject Fries;
    public GameObject Pizza;
    public GameObject Shake;
    private GameObject SpawnedFood;

    Transform child;
    public GameObject childObj;
    public GameObject childRunObj;

    public bool isHit = false;
    public bool isDirectionRight; //public as used in FoodCollison
    private Vector3 StartPosition;
    public LayerMask CollideableLayers;//physics layer that will cause the line to stop being drawn

    // Start is called before the first frame update
    void Start()
    {
        moveRightOrLeft(1);
        StartPosition = transform.position;

        int randomNumber = Mathf.RoundToInt(Random.Range(0f, 5f));
        if (randomNumber == 0)
            SpawnedFood = (GameObject)Instantiate(Burger, FoodPosition.transform.position, Burger.transform.rotation);
        else if (randomNumber == 1)
            SpawnedFood = (GameObject)Instantiate(Cake, FoodPosition.transform.position, Cake.transform.rotation);
        else if (randomNumber == 2)
            SpawnedFood = (GameObject)Instantiate(CakePop, FoodPosition.transform.position, CakePop.transform.rotation);
        else if (randomNumber == 3)
            SpawnedFood = (GameObject)Instantiate(Fries, FoodPosition.transform.position, Fries.transform.rotation);
        else if (randomNumber == 4)
            SpawnedFood = (GameObject)Instantiate(Pizza, FoodPosition.transform.position, Pizza.transform.rotation);
        else
            SpawnedFood = (GameObject)Instantiate(Shake, FoodPosition.transform.position, Shake.transform.rotation);

        SpawnedFood.transform.parent = gameObject.transform;

        child = childObj.transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isHit)
        {
            if (transform.position.x == StartPosition.x)
            { //Debug.Log("moving right");
                moveRightOrLeft(1);
            }
            else if (transform.position.x == -StartPosition.x)
            { //Debug.Log("moving left");
                moveRightOrLeft(0);
            }
            // Debug.Log("update");
        }
    }



    void OnCollisionEnter(Collision collision)
    {
        //
        if (collision.gameObject.layer == 6)
        {
            isHit = true;
            GetComponent<AudioSource>().Play();
            this.LookAtScreenAndRun();
           
        }    
    }

   /* public void LookAtScreen()
    {
        //public as used in FoodCollison
        sequenceLookAtScreen?.Kill();
        Vector3 rot = transform.rotation.eulerAngles;
        Vector3 rotY = rot;
        rotY.y = 180;
        sequenceLookAtScreen = DOTween.Sequence()
          .Append(transform.DORotate(rotY, 0.2f))
          .AppendInterval(1)
          .Append(transform.DORotate(rot, 0.2f));
    }*/

    public void LookAtScreenAndRun()
    {
        childObj.SetActive(false);
        childRunObj.SetActive(true);
        child = childRunObj.transform;
        sequenceEnter?.Kill();
        sequenceLookAtScreen?.Kill();
        Vector3 rot = transform.rotation.eulerAngles;
        Vector3 rotY = rot;
        rotY.y = 180;
        sequenceLookAtScreen = DOTween.Sequence()
          .Append(child.DORotate(rotY, 0.2f))
          .AppendInterval(1)
          .Append(child.DORotate(rot, 0.2f));


        if (isDirectionRight)
        {
            sequenceLookAtScreen.Append(child.DOMoveX(10, 3f));
        }
        else
        {
            sequenceLookAtScreen.Append(child.DOMoveX(-10, 3f));
        }
        //sequenceLookAtScreen.AppendCallback(PlayRunAnimation);

        transform.GetChild(5).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        transform.GetChild(5).GetComponent<Rigidbody>().freezeRotation = false;
        Destroy(SpawnedFood, 1f);
        Destroy(gameObject, 3f);
        if (OnFoodHit != null) { OnFoodHit(); }
    }
    private void moveRightOrLeft(int RightorLeft)
    {
        //Debug.Log("Right or left function");
        sequenceEnter?.Kill();
        Vector3 pos = transform.position;
        float distance = pos.x * 2;
        float duration = distance / speed;

        if (pos.x < 0) { isDirectionRight = true; }
        else { isDirectionRight = false; }

        pos.x = -pos.x;
        Vector3 rot = transform.rotation.eulerAngles;
        
        sequenceEnter = DOTween.Sequence()
          .Append(transform.DORotate(-rot, 0.2f))
          //.AppendCallback(PlayWalkAnimation)
          .Join(transform.DOMove(pos, 10f));
        

    }

    //private void PlayRunAnimation() => characterAnimation.PlayAnimation(AnimationTypes.run);
    //private void PlayWalkAnimation() => characterAnimation.PlayAnimation(AnimationTypes.walk);
}


