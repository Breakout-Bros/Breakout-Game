using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float MoveSpeed = 7.2f;
    //private float MoveSpeed = 2.2f;
    private Rigidbody2D myBall;
    private Vector2 direction;
    private Vector2 tempBallVelocity;
    private float collisionAngle;
    private int collisionPaddleSegment;
    private float newAngle;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector2(0.3f, -0.2f);
        //direction = new Vector2(0.4f, -0.6f);
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
            // this gets the angle the ball hits the paddle
            Vector3 normal = collision.contacts[0].normal;
            collisionAngle = Vector2.Angle(myBall.velocity, -normal);
            // Debug.Log("collision Angle: " + collisionAngle);

            // this gets the method we need from PaddleController
            GameObject go = GameObject.Find("paddle");
            PaddleController paddleController = (PaddleController)go.GetComponent(typeof(PaddleController));

            // this gets which part (segment, 1-5) of the paddle the ball hit
            collisionPaddleSegment = paddleController.getCollisionSegment();


            // switch direction is currently not working!! it switches for right side but not left!

            // change angle if we didn't hit the middle segment
            //if (collisionPaddleSegment != 3)
            changeAngle();

            // if (switchDirectionCheck())
            // {
            //     // reverse direction
            //     tempBallVelocity = new Vector2(myBall.velocity.x * -1, myBall.velocity.y);
            //     myBall.velocity = tempBallVelocity;
            // }
        }
    }
    bool switchDirectionCheck()
    {
        print("segment " + collisionPaddleSegment + " and velocity " + myBall.velocity.x);
        // check to see if we should change the ball's direction
        if ((collisionPaddleSegment < 3 && (myBall.velocity.x > 0)) ||
        (collisionPaddleSegment > 3 && (myBall.velocity.x < 0)))
        {
            GameObject go = GameObject.Find("paddle");
            PaddleController paddleController = (PaddleController)go.GetComponent(typeof(PaddleController));
            print("SWITCH!!!!!!!!!!!! segment " + paddleController.getCollisionSegment() + " at " + Time.time);
            return true;
        }
        else { return false; }
    }

    void changeAngle()
    {

        // newAngle = collisionAngle * 0.2f;
        // var newDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * newAngle), Mathf.Sin(Mathf.Deg2Rad * newAngle));
        // myBall.velocity = newDirection.normalized * MoveSpeed;

        //print("segment: " + collisionPaddleSegment);

        // print("collision angle is " + collisionAngle);
        // decrease angle
        if ((collisionPaddleSegment == 1 && (myBall.velocity.x > 0)) || (collisionPaddleSegment == 5 && (myBall.velocity.x < 0)))
        {
            newAngle = collisionAngle;
            if (newAngle < 10f) { newAngle += 10f; }
            if (newAngle > 170f) { newAngle -= 10f; }
            newAngle -= 90f;
            print("angle is  " + newAngle + "velocity is " + myBall.velocity.x);

            var newDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * newAngle), Mathf.Sin(Mathf.Deg2Rad * newAngle));
            myBall.velocity = newDirection * MoveSpeed;

            //newAngle = collisionAngle * 0.8f;
        }
        else if ((collisionPaddleSegment == 2 && (myBall.velocity.x > 0)) || (collisionPaddleSegment == 4 && (myBall.velocity.x < 0)))
        {
            //newAngle = collisionAngle * 0.9f;
        }

        // increase angle
        else if ((collisionPaddleSegment == 1 && (myBall.velocity.x < 0)) || (collisionPaddleSegment == 5 && (myBall.velocity.x > 0)))
        {
            //newAngle = collisionAngle * 1.2f;
        }
        else if ((collisionPaddleSegment == 2 && (myBall.velocity.x < 0)) || (collisionPaddleSegment == 4 && (myBall.velocity.x > 0)))
        {
            // newAngle = collisionAngle * 1.2f;
        }


    }
}
