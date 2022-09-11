using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 3;

    public GameObject BallPrefab;
    public Transform PebbleShootPoint;

    private bool isPressed, isBallThrown;

    GameObject CreatePebble;//pebble instance new
    Vector3 start, end, force;

    private int numOfTrajectoryPoints = 30;

    LineRenderer lineRenderer;

    public float divideDragMagBy = 50;
    public int NumberOfPebbles;
    public Text pebbletext;
    public Text outOFPebbbles;
    // Update is called once per frame
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        isPressed = isBallThrown = false;
        lineRenderer.enabled = false;

        if (LevelSelector.selectedLevel <= 7)
        { NumberOfPebbles = LevelSelector.selectedLevel + 5; }
        else NumberOfPebbles = 5;
        pebbletext.text = "PEBBLES: " + NumberOfPebbles.ToString();
    }

    private void OnEnable()
    {
        collision.OnPebbleHit += isBallThrownTrue;
    }
    void isBallThrownTrue() 
    { 
        isBallThrown = false;
    }

    void Update()
    {
        if (isBallThrown)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                lineRenderer.enabled = true;start = Input.mousePosition;
                isPressed = true; 
                if (!CreatePebble && NumberOfPebbles != 0)
                    createBall();
                if(NumberOfPebbles == 0) { outOFPebbbles.text = "OUT OF PEBBLES, TRY AGAIN!"; lineRenderer.enabled = false;}
            }
            else if (Input.GetMouseButtonUp(0))
            {
                lineRenderer.enabled = false;
                isPressed = false; end = Input.mousePosition;
                if (!isBallThrown && CreatePebble)
                {
                    throwBall();
                }
                this.transform.Rotate(0, 0, 0);
            }

            if (isPressed)
            {
                //move bird--------------------------------------------------
                float HorizontalRotation = (Input.mousePosition.x - start.x) / 10;

                HorizontalRotation = Mathf.Clamp(HorizontalRotation, -60, 60);
                var rot = transform.localEulerAngles;
                rot.y = -HorizontalRotation;
                transform.localEulerAngles = rot;

                //-----------------------------------------------------------

                //display linerenderer--------------------------------------------
                if (lineRenderer.enabled)
                    setTrajectoryPoints();
                //------------------------------------------------------------------

            }
            else { this.transform.Rotate(0, 0, 0); }
        }
    }


    private void createBall()
    {
        CreatePebble = (GameObject) Instantiate(BallPrefab, PebbleShootPoint.position, PebbleShootPoint.rotation);
        CreatePebble.GetComponent<Rigidbody>().mass = 0;
    }
    private void throwBall()
    {
        NumberOfPebbles--;
        pebbletext.text = "PEBBLES: " + NumberOfPebbles.ToString();

        CreatePebble.SetActive(true);
        CreatePebble.GetComponent<Rigidbody>().mass = 1;
        CreatePebble.GetComponent<Rigidbody>().useGravity = true;
        force.y = start.y - end.y;
        float vel = Mathf.Sqrt((force.x * force.x) + (force.y * force.y));
        if (vel > 500) vel = 500;
        CreatePebble.GetComponent<Rigidbody>().velocity = (PebbleShootPoint.up) * (BlastPower+vel/divideDragMagBy);
        Debug.Log(vel);
        isBallThrown = true;
    }

    void setTrajectoryPoints()
    { 
        lineRenderer.positionCount = numOfTrajectoryPoints;
        List<Vector3> points = new List<Vector3>();

        Vector3 startingPosition =PebbleShootPoint.position;

        force.y = start.y - Input.mousePosition.y;
        float vel = Mathf.Sqrt((force.x * force.x) + (force.y * force.y));
        if (vel > 500) vel = 500;
        Vector3 startingVelocity = (PebbleShootPoint.up) * (BlastPower + vel/divideDragMagBy);

        for (float t = 0; t < numOfTrajectoryPoints; t +=0.1f)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoint);

        }

        lineRenderer.SetPositions(points.ToArray());
    }

}
