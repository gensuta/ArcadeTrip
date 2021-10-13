using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorBehavior : MonoBehaviour
{


    // FOR THIS SCRIPT the scissor is just moving closer to the next maker based on how many times the player presses the space bar!!
    // this is the thing that's turning to the next object as well

    [SerializeField] GameObject cursor;
    Camera m_camera;
    public bool done;

    Vector3 startPos;

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

    }

    // IF YOU TOUCH THE LAST X COLLIDER FIRE OFF DONE 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("x")) 
        {
            done = true;
        }
    }

    // NEW IDEA
    // SCISSORS MOVE BACK IN FORTH PRESS BUTTON FOR ACCURACY SPEED MESSES U UP
    // PRESS SPACE TO MOVE FWD
    // THE ANGLE THAT U MISSED THE LINE AT WILL CHANGE UR SCORE ( HIGHER ANGLE MORE POINTS U LOSE )


}
