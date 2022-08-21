using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    BirdController birdController;
    LineRenderer lineRenderer;

    public int numPoints = 50;//nummber of points on line
    public float timeBetweenPoint = 0.1f;//distance between points on line

    public LayerMask CollideableLayers;//physics layer that will cause the line to stop being drawn


    void Start()
    {
        birdController = GetComponent<BirdController>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = birdController.PebbleShootPoint.position;
        Vector3 startingVelocity = birdController.PebbleShootPoint.up * birdController.BlastPower;
        for(float t = 0;t < numPoints; t += timeBetweenPoint)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoint);


        }

        lineRenderer.SetPositions(points.ToArray());
    }
}
