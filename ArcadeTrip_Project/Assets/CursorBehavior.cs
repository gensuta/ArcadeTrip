using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{

    public static event Action OnMoveForward, OnCustomerDone, OnNoInput, OnMistakeMade;

    [SerializeField] bool onNewTarget;
    [SerializeField] float dist;
    [SerializeField] ScissorBehavior scissors;

    private void Update()
    {
        if (scissors.transform.position.x < transform.position.x && Vector3.Distance(scissors.transform.position,transform.position) <= dist)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (onNewTarget)
                {
                    if (scissors.done)
                    {
                        OnCustomerDone?.Invoke();
                        scissors.done = false;
                    }
                    else
                    {
                        OnMoveForward?.Invoke();
                    }
                }
                else
                {
                    OnMistakeMade?.Invoke();
                    OnNoInput?.Invoke();
                }
            }
      
        }
        if (scissors.done)
        {

            OnCustomerDone?.Invoke();
            scissors.done = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<LineBehavior>())
        {
            onNewTarget = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<LineBehavior>())
        {
            onNewTarget = false;
            OnNoInput?.Invoke();
        }

    }
}
