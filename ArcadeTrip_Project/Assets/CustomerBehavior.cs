using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehavior : MonoBehaviour
{
    [SerializeField] GameObject hair, bob;

    // Start is called before the first frame update
    void Start()
    {
        bob.SetActive(false);
        hair.SetActive(true);
    }

    private void OnEnable()
    {
        CursorBehavior.OnCustomerDone += OnHairDone;
    }

    private void OnDisable()
    {
        CursorBehavior.OnCustomerDone -= OnHairDone;
    }

    void OnHairDone()
    {
        bob.SetActive(true);
        hair.SetActive(false);
    }
}
