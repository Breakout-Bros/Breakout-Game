using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBallScript : MonoBehaviour
{
    public testPaddleScript test_paddle_script;
    // Start is called before the first frame update
    void Start()
    {

        GameObject go = GameObject.Find("paddle");
        testPaddleScript testPaddleScript = (testPaddleScript) go.GetComponent(typeof(testPaddleScript));
        testPaddleScript.GetSphereScript();
        // test_paddle_script = GetComponent<testPaddleScript>();
        // test_paddle_script.GetSphereScript();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
