using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    protected Joystick joystick;
    protected joybutton joybutton;

    protected bool jump; 
    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<joybutton>();
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>(); 

        rigidbody.velocity = new Vector3(joystick.Horizontal * 30f,
                                         rigidbody.velocity.y,
                                         joystick.Vertical * 30f); 

    if(!jump && joybutton.Pressed) 
    {
        jump = true; 
        rigidbody.velocity += Vector3.up * 10f; 
    }

    if(jump && !joybutton.Pressed)
    {
        jump = false; 
    }

    }
}
