using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer != 6)
          Destroy(this.gameObject);
        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
        }
    }
}
