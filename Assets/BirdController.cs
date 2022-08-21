using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 5;

    public GameObject BallPrefab;
    public Transform PebbleShootPoint;

    // Update is called once per frame
    void Update()
    {
        float HorizontalRotation = Input.GetAxis("Horizontal");
        float VerticalRotation = 0;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
            new Vector3(0, HorizontalRotation * rotationSpeed, VerticalRotation * rotationSpeed)
            );

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject CreatePebble = Instantiate(BallPrefab, PebbleShootPoint.position, PebbleShootPoint.rotation);
            CreatePebble.GetComponent<Rigidbody>().velocity = PebbleShootPoint.transform.up * BlastPower;

        }
    }
}
