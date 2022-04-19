using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

//Citation: https://gamedevbeginner.com/raycasts-in-unity-made-easy/

public class PaddleController : MonoBehaviour
{
private CharacterController _controller;
public const float Speed = 0.4f;
public Collider2D myCollider;
//public var tangent;


public RaycastHit2D[] hitInfo = new RaycastHit2D[1];
public Rigidbody2D myBody;
private float spriteHalfLen;
private float spriteLen;
public float heading;
private int segments = 5;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        myCollider = GetComponent<Collider2D>();
       //Debug.Log(myCollider);
        myBody = GetComponent<Rigidbody2D>();
        spriteHalfLen = GetComponent<SpriteRenderer>().bounds.extents.x;
        spriteLen = spriteHalfLen * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.RightArrow)){
        myCollider.Raycast(transform.TransformDirection(Vector2.right), hitInfo, 1000f);
            RaycastHit2D hit = hitInfo[0];
            if (hit.distance - spriteHalfLen > 1){
                myBody.MovePosition(transform.position + new Vector3(Speed, 0, 0));
                myCollider.Raycast(transform.TransformDirection(Vector2.right), hitInfo, 1000f);
            }

            else if (hit.collider.name != null){
                myBody.MovePosition(transform.position + new Vector3(hit.distance - spriteHalfLen - 0.0001f, 0, 0));
                myCollider.Raycast(transform.TransformDirection(Vector2.right), hitInfo, 1000f);
            }
            //Debug.Log("hit size: " + hit.distance);
    }

        if (Input.GetKey (KeyCode.LeftArrow)){
            myCollider.Raycast(transform.TransformDirection(Vector2.left), hitInfo, 1000f);
            RaycastHit2D hit = hitInfo[0];
            
            if (hit.distance - spriteHalfLen > 1){
                myBody.MovePosition(transform.position + new Vector3(-Speed, 0, 0));
            }
            else if (hit.collider.name != null){
                myBody.MovePosition(transform.position - new Vector3(hit.distance - spriteHalfLen - 0.001f, 0, 0));
                myCollider.Raycast(transform.TransformDirection(Vector2.left), hitInfo, 1000f);
            }           
        }
    }

// this part is to check the angle and adjust as needed
//citation: https://answers.unity.com/questions/848244/find-out-direction-vector-of-movement.html
 public float maxAngle = 95; 
 void OnCollisionEnter2D(Collision2D collision){
     Vector3 normal = collision.contacts[0].normal;
     Vector3 vel = myBody.velocity;
     Vector3 colPoint = collision.contacts[0].point;

     // this is where on the paddle the collision occurred
     Vector3 headingVector = colPoint - myBody.transform.position;
     heading = headingVector.x + spriteHalfLen; //converted headingVector scale

     //Vector3.OrthoNormalize(ref heading, ref colPoint);

            // Debug.Log("after: " + heading);// Vector3.Angle(vel, -normal));

         Vector3 myCollisionVelocity = myBody.velocity;
       // print(myCollisionVelocity);
        // collisionAngleTest1 = Vector3.Angle(myCollisionVelocity, -normal);
 
        // Debug.Log("AngleTest1: " + collisionAngleTest1);


    //  // measure angle
    //  if (Vector3.Angle(vel, -normal) > maxAngle){
    //     //Debug.Log("Help");
    //      myBody.velocity = Vector3.Reflect(vel, normal);
    //  } 
  }

  public int getCollisionSegment(){
      // this gets which segment (1-5, left to right) of the paddle the ball hit
      float headingPercent = heading / spriteLen;
      int segment = (int) Ceiling(headingPercent * 100 / (100 / segments));
      return segment;
  }


}
