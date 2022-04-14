using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ballController;

//Citation: https://gamedevbeginner.com/raycasts-in-unity-made-easy/

public class paddleController : MonoBehaviour
{
private CharacterController _controller;
public const float Speed = 0.4f;
public Collider2D myCollider;
//public var tangent;


public RaycastHit2D[] hitInfo = new RaycastHit2D[1];
public Rigidbody2D myBody;
private float spriteHalfLen;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        myCollider = GetComponent<Collider2D>();
       //Debug.Log(myCollider);
        myBody = GetComponent<Rigidbody2D>();
        spriteHalfLen = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.RightArrow)){
        
        //Debug.Log(myCollider);



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
     Vector3 heading = colPoint - myBody.transform.position;
     ////////////////////////// keep this:
    Debug.Log(heading);// this is where on the paddle the collision occurred!
     //////////////////////////
     //Vector3.OrthoNormalize(ref heading, ref colPoint);

            // Debug.Log("after: " + heading);// Vector3.Angle(vel, -normal));

         Vector3 myCollisionVelocity = myBody.velocity;
       // print(myCollisionVelocity);
        // collisionAngleTest1 = Vector3.Angle(myCollisionVelocity, -normal);
 
        // Debug.Log("AngleTest1: " + collisionAngleTest1);




    //  // measure angle
    //  if (Vector3.Angle(vel, -normal) > maxAngle){
    //     //Debug.Log("Help");
    //      // bullet bounces off the surface
    //      myBody.velocity = Vector3.Reflect(vel, normal);
    //  } else {
    //      // bullet penetrates the target - apply damage...
    //      //Destroy(gameObject); // and destroy the bullet
    //  }
  }


}
