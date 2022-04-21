using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class boxScript : MonoBehaviour
{
    public AudioSource audioSource;

    private bool destroyBlock;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()

    {

        if (destroyBlock)
        {
            //destroyBlock = false;
            // AudioSource audio;
            // audio = GetComponent<AudioSource>();
            // audio.Play();
            //GetComponent<MeshRenderer>().enabled = false;
            //GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D col)

    {
        destroyBlock = true;
    }

}
