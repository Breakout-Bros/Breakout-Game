using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float MoveSpeed = 9.2f;
    private Rigidbody2D myBall;
    private Vector2 direction;
    private Vector2 tempBallVelocity;
    private float collisionAngleTest1;
    private int collisionPaddleSegment;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0.3f, -0.2f);
        myBall = GetComponent<Rigidbody2D>();
        myBall.velocity = direction.normalized * MoveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // This sets the velocity as steady
        myBall.velocity = myBall.velocity.normalized * MoveSpeed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.name == "paddle")
        {

            Vector3 normal = collision.contacts[0].normal;
            collisionAngleTest1 = Vector3.Angle(myBall.velocity, -normal);
            Debug.Log("collision Angle: " + collisionAngleTest1); // this is the angle the ball hits the paddle!

            // this gets the method we need from PaddleController
            GameObject go = GameObject.Find("paddle");
            PaddleController paddleController = (PaddleController)go.GetComponent(typeof(PaddleController));

            // this gets which part (segment, 1-5) of the paddle the ball hit
            collisionPaddleSegment = paddleController.getCollisionSegment();

            if (switchDirectionCheck())
            {
                // reverse direction
                tempBallVelocity = new Vector2(myBall.velocity.x * -1, myBall.velocity.y);
                myBall.velocity = tempBallVelocity;
            }

            //print("myBall.velocity is" + myBall.velocity);

        }
    }
    bool switchDirectionCheck()
    {
        // check to see if we should change the ball's direction
        if (collisionPaddleSegment < 3 && (myBall.velocity.x > 0))
        {
            return true;
        }
        if (collisionPaddleSegment > 3 && (myBall.velocity.x < 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
