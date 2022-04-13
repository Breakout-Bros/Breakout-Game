using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
     public float MoveSpeed = 250.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * -1.0f * MoveSpeed);
        GetComponent<Rigidbody2D>().AddForce(transform.right * MoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
