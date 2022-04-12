using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Citation: https://gamedevbeginner.com/raycasts-in-unity-made-easy/

public class paddleController : MonoBehaviour
{
private CharacterController _controller;
//public float Speed = 1.0f;

public Collider2D myCollider;
public RaycastHit2D[] hitInfo = new RaycastHit2D[1];
public Rigidbody2D myMove;
private float spriteHalfLen;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        myCollider = GetComponent<Collider2D>();
        myMove = GetComponent<Rigidbody2D>();
        spriteHalfLen = GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.RightArrow)){
        
        myCollider.Raycast(transform.TransformDirection(Vector2.right), hitInfo, 1000f);
            RaycastHit2D hit = hitInfo[0];
            if (hit.distance - spriteHalfLen > 1){
                myMove.MovePosition(transform.position + new Vector3(.6f, 0, 0));
                myCollider.Raycast(transform.TransformDirection(Vector2.right), hitInfo, 1000f);
            }

            else if (hit.collider.name != null){
                myMove.MovePosition(transform.position + new Vector3(hit.distance - spriteHalfLen - 0.0001f, 0, 0));
                myCollider.Raycast(transform.TransformDirection(Vector2.right), hitInfo, 1000f);
            }
            //Debug.Log("hit size: " + hit.distance);
    }

        if (Input.GetKey (KeyCode.LeftArrow)){
            myCollider.Raycast(transform.TransformDirection(Vector2.left), hitInfo, 1000f);
            RaycastHit2D hit = hitInfo[0];
            
            if (hit.distance - spriteHalfLen > 1){
                myMove.MovePosition(transform.position + new Vector3(-.6f, 0, 0));
            }
            else if (hit.collider.name != null){
                myMove.MovePosition(transform.position - new Vector3(hit.distance - spriteHalfLen - 0.001f, 0, 0));
                myCollider.Raycast(transform.TransformDirection(Vector2.left), hitInfo, 1000f);
            }           
        }
    }
}
