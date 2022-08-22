using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private List<Vector3> trajectoryPoints = new List<Vector3>();

    LineRenderer lineRenderer;

    public float divideDragMagBy = 10;

    // Update is called once per frame
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        isPressed = isBallThrown = false;
        lineRenderer.enabled = false;
    }
    void Update()
    {
        if (CreatePebble == null)
            isBallThrown = false;
        if (isBallThrown)
        {
            return;
        }
       if (Input.GetMouseButtonDown(0))
        {
            lineRenderer.enabled = true;
            isPressed = true; start = Input.mousePosition;
            if (!CreatePebble)
                createBall();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
            isPressed = false; end = Input.mousePosition;
            if (!isBallThrown)
            {
                throwBall();
            }
        }

        if (isPressed)
        {
            //move bird--------------------------------------------------
            float HorizontalRotation = Input.GetAxis("Horizontal");
            float VerticalRotation = 0;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
                new Vector3(0, HorizontalRotation * rotationSpeed, VerticalRotation * rotationSpeed)
                );
            //-----------------------------------------------------------

            //display linerenderer--------------------------------------------
            if (lineRenderer.enabled)
                setTrajectoryPoints();
            //------------------------------------------------------------------

        }
        else { this.transform.Rotate(0, 0, 0); }

    }


    private void createBall()
    {
        CreatePebble = (GameObject) Instantiate(BallPrefab, PebbleShootPoint.position, PebbleShootPoint.rotation);
    }

    private void throwBall()
    {
        CreatePebble.SetActive(true);
        CreatePebble.GetComponent<Rigidbody>().useGravity = true;
        force = start - end;
        float vel = Mathf.Sqrt((force.x * force.x) + (force.y * force.y));
        CreatePebble.GetComponent<Rigidbody>().velocity = (PebbleShootPoint.up) * (BlastPower+vel/divideDragMagBy);



        // CreatePebble.GetComponent<Rigidbody>()
        //     .AddForce(GetForceFrom(CreatePebble.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)), ForceMode.Impulse);
        // CreatePebble.GetComponent<Rigidbody>().AddForce(force);
        isBallThrown = true;
    }

    private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos)
    {
        return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y)) * BlastPower;
    }

    void setTrajectoryPoints()
    {
        lineRenderer.positionCount = numOfTrajectoryPoints;
        List<Vector3> points = new List<Vector3>();

        Vector3 startingPosition =PebbleShootPoint.position;

        force = start - Input.mousePosition;
        float vel = Mathf.Sqrt((force.x * force.x) + (force.y * force.y));
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
