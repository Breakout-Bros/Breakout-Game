using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    GetComponent<Rigidbody2D>().AddForce(transform.up * -1.0f * 250);
    GetComponent<Rigidbody2D>().AddForce(transform.right * 250);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
