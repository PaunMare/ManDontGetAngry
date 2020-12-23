using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameObject startingPosition;
    public GameObject homePosition;
    public GameObject[] fieldPositions;
    GameObject currentPosition;
    public bool inHome = true;
    public GameObject dice;
    int indexPosition = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = homePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToStartingPosition()
    {
        if (inHome && dice.GetComponent<Dice>().currentNumber == 5)
        {
            currentPosition = startingPosition;
            this.gameObject.transform.position = startingPosition.transform.position;
            inHome = false;
        }
    }
    public void ReturnToTheHouse()
    {
        currentPosition = homePosition;
        inHome = true;
    }
    public void MoveThroughTheField()
    {
        if (!inHome)
        {
            currentPosition = fieldPositions[dice.GetComponent<Dice>().currentNumber+indexPosition+1];
            this.transform.position = currentPosition.transform.position;
            indexPosition += dice.GetComponent<Dice>().currentNumber+1;
        }
    }


}
