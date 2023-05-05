using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{

    public Rigidbody myBody;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = myBody.velocity;
        Vector3 a;
        a.x = 0.99f;
        a.y = 0.99f;
        a.z = 0.99f;
        if (Input.GetKey(KeyCode.RightArrow)){v.x =  10;}
        if (Input.GetKey(KeyCode.LeftArrow)){ v.x = -10; }
        if ( Input.GetKey(KeyCode.UpArrow)) { v.z = 10; }
        if (Input.GetKey(KeyCode.DownArrow)) { v.z = -10;}
        v.Scale(a);
        myBody.velocity = v;
    }
}
