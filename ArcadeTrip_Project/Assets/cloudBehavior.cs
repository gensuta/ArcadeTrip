using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudBehavior : MonoBehaviour
{
    SpriteRenderer sr;
    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        CursorBehavior.OnMoveForward += OnMoveForward;
        CursorBehavior.OnNoInput += OnNoInput;

    }

    private void OnDisable()
    {
        CursorBehavior.OnMoveForward -= OnMoveForward;
        CursorBehavior.OnNoInput -= OnNoInput;

    }

    void OnMoveForward()
    {
        sr.enabled = true;
    }

    void OnNoInput()
    {
        sr.enabled = false;
    }
}
