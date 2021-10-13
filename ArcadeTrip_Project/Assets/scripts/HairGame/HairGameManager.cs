using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HairGameManager : MonoBehaviour
{
    [SerializeField] int customersCompleted, customersFailed, currentScore;



    [SerializeField] GameObject[] linePrefabs, customers;

    GameObject oldLine, oldCat;


    [SerializeField] TextMeshProUGUI scoreText;


    private void OnEnable()
    {
        CursorBehavior.OnMistakeMade += OnMistakeMade;
        CursorBehavior.OnMoveForward += OnMoveForard;
        CursorBehavior.OnCustomerDone += NewCustomer;
    }

    private void OnDisable()
    {
        CursorBehavior.OnMistakeMade -= OnMistakeMade;
        CursorBehavior.OnMoveForward -= OnMoveForard;
        CursorBehavior.OnCustomerDone -= NewCustomer;
    }

    // Start is called before the first frame update
    void Start()
    {
        NewCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + currentScore;
    }

    public void NewCustomer()
    {
        if(oldCat != null) // destroy withs econds to have everything pan off screen
        {
            Destroy(oldCat);
            Destroy(oldLine);
        }

        int randCustomer = GetRandomNum(0, customers.Length);
        int randLine = GetRandomNum(0, linePrefabs.Length);


       oldCat = Instantiate(customers[randCustomer]);
       oldLine = Instantiate(linePrefabs[randLine]);

    }

    void OnMoveForard()
    {
        currentScore += 10;
    }

    void OnMistakeMade()
    {
        currentScore -= 2;
    }

    int GetRandomNum(int min, int max)
    {
        return Random.Range(min, max);
    }
}
