using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
     public float MoveSpeed = 250.0f;
     public Rigidbody2D myBall;
    public Vector3 myCollisionVelocityBall;
    
    public float collisionAngleTest1;
    // Start is called before the first frame update
    void Start()
    {
        myBall = GetComponent<Rigidbody2D>();
        myBall.AddForce(transform.up * -1.0f * MoveSpeed);
        myBall.AddForce(transform.right * MoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
    myCollisionVelocityBall = myBall.velocity;

    }
 void OnCollisionEnter2D(Collision2D collision){

        if (collision.collider.name == "paddle"){
        Vector3 normal = collision.contacts[0].normal;
        collisionAngleTest1 = Vector3.Angle(myCollisionVelocityBall, -normal);
         Debug.Log("collision Angle: " + collisionAngleTest1); // this is the angle the ball hits the paddle!

       // myCollisionVelocity = myBall.velocity;
        print(myCollisionVelocityBall); // this is the direction of the ball!!!!!!! (before collision)
        }
  }
}
