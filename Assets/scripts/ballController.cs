using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
     public float MoveSpeed = 250.0f;
     public Rigidbody2D myBall;
    public Vector3 myCollisionVelocityBall;
    public Vector3 direction;
    private Vector2 tempBallVelocity;
    public float collisionAngleTest1;
    private int collisionPaddleSegment;

    // Start is called before the first frame update
    void Start()
    {
        direction= new Vector3(1, 0, 0);
        myBall = GetComponent<Rigidbody2D>();
        myBall.AddForce(transform.up * -1.2f * MoveSpeed);
        myBall.AddForce(transform.right * MoveSpeed);
        direction.x = myBall.velocity.x;
        direction.y = myBall.velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
    //myCollisionVelocityBall = myBall.velocity;

    }
 void OnCollisionEnter2D(Collision2D collision){

        if (collision.collider.name == "paddle"){
        // Vector3 normal = collision.contacts[0].normal;
        // collisionAngleTest1 = Vector3.Angle(myCollisionVelocityBall, -normal);
       //  Debug.Log("collision Angle: " + collisionAngleTest1); // this is the angle the ball hits the paddle!

       // myCollisionVelocity = myBall.velocity;
       // print(myCollisionVelocityBall); // this is the direction of the ball!!!!!!! (before collision)
        




        GameObject go = GameObject.Find("paddle");
        PaddleController paddleController = (PaddleController) go.GetComponent(typeof(PaddleController));
        //print(paddleController.getCollisionSegment());
        collisionPaddleSegment = paddleController.getCollisionSegment();
        print(collisionPaddleSegment);
        
        if (switchDirectionCheck()){
          // reverse direction
          tempBallVelocity = new Vector2(myBall.velocity.x *-1, myBall.velocity.y);
          //tempBallVelocity.x *= -1;
          myBall.velocity = tempBallVelocity;
        }
        
        print("myBall.velocity is" + myBall.velocity);
        
        //myBall.velocity *= -1;
       //myCollisionVelocityBall.x *= -1; // change direction
        //print(myCollisionVelocityBall); // this is the direction of the ball!!!!!!! (before collision)
        }
  }
  bool switchDirectionCheck(){
    // check to see if we should change the ball's direction
    if(collisionPaddleSegment < 3 && (myBall.velocity.x > 0)){
      return true;
    }
    if(collisionPaddleSegment > 3 && (myBall.velocity.x < 0)){
      return true;
    }
    else{
      return false;
    }
  }
}
