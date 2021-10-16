using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorBehavior : MonoBehaviour
{


    // FOR THIS SCRIPT the scissor is just moving closer to the next maker based on how many times the player presses the space bar!!
    // this is the thing that's turning to the next object as well

    [SerializeField] GameObject cursor;
    Camera m_camera;
    public bool done, rotateRight, cuttingLine;

    Vector3 startPos;

    [SerializeField] Vector3 rotateAmt;

    private void OnEnable()
    {
        CursorBehavior.OnMoveForward += OnMoveForward;
        CursorBehavior.OnCustomerDone += OnNewCustomer;
        startPos = transform.position;
    }


    private void OnDisable()
    {
        CursorBehavior.OnMoveForward -= OnMoveForward;
        CursorBehavior.OnCustomerDone -= OnNewCustomer;

    }

    private void OnNewCustomer()
    {
        transform.position = startPos;
    }

    public void OnMoveForward()
    {
       transform.position = Vector3.MoveTowards(transform.position, cursor.transform.position, 0.2f);
    }
    void Start()
    {
        m_camera = Camera.main;  // Don't keep calling Camera.main
    }

    void Update()
    {
        /*  var lookAtPos = Input.mousePosition;
          lookAtPos.z = transform.position.z - m_camera.transform.position.z;
          lookAtPos = m_camera.ScreenToWorldPoint(lookAtPos);
          transform.up = lookAtPos - transform.position;*/


        //rotate to x pos and rotate back to y pos, messing with the transform.up???

        // TURN OFF CURSOR COMPLETELY

        // when player presses space make scissors move forward until it hits a marker then it will go again
        // unless the marker is the final one

        if (!cuttingLine)
        {
            if (rotateRight)
            {
                transform.Rotate(rotateAmt);
            }
            else
            {
                transform.Rotate(-rotateAmt);
            }


            if (transform.rotation.eulerAngles.z <= 50f && transform.rotation.eulerAngles.z > 48f)
            {
                rotateRight = false;
            }

            if (transform.rotation.eulerAngles.z >= 310f && transform.rotation.eulerAngles.z < 312)
            {
                rotateRight = true;
            }
        }

        else
        {
            transform.position += (transform.right * 0.05f); // keep going till we hit a marker
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            cuttingLine = true;
        }

        // make sure there's a ceiling and floor to stop the scissors for going all the way up
        // do we have a click to stop moving? 
        // possible AB test? Show half of people prototype A and half prototype B ( or just show both alternate what u show first )


  
    }

    // IF YOU TOUCH THE LAST X COLLIDER FIRE OFF DONE 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("x")) 
        {
            done = true;
        }

        if (collision.gameObject.name.Equals("marker"))
        {
            cuttingLine = false;
        }
    }

    

    // NEW IDEA
    // SCISSORS MOVE BACK IN FORTH PRESS BUTTON FOR ACCURACY SPEED MESSES U UP
    // PRESS SPACE TO MOVE FWD
    // THE ANGLE THAT U MISSED THE LINE AT WILL CHANGE UR SCORE ( HIGHER ANGLE MORE POINTS U LOSE )


}
