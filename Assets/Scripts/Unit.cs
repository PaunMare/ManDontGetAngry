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
        if (inHome)
        {
            inHome = false;
            startingPosition.GetComponent<PlaceHolder>().currentObject = this.gameObject;
            currentPosition = startingPosition;
            this.gameObject.transform.position = startingPosition.transform.position;
            indexPosition = 0;
        }
    }
    public void ReturnToTheHouse()
    {
        this.gameObject.transform.position = homePosition.transform.position;
        inHome = true;
        //indexPosition = -1;
    }
    public void MoveThroughTheField()
    {
        if (!inHome)
        {
            if(fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1].GetComponent<PlaceHolder>().currentObject != null)
            {
                if (!fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1].CompareTag(this.gameObject.tag))
                {
                    fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1].GetComponent<PlaceHolder>().currentObject.GetComponent<Unit>().ReturnToTheHouse();
                    currentPosition.GetComponent<PlaceHolder>().currentObject = null;
                    
                    fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1].GetComponent<PlaceHolder>().currentObject = this.gameObject;
                    currentPosition = fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1];
                    this.transform.position = currentPosition.transform.position;
                    indexPosition += dice.GetComponent<Dice>().currentNumber + 1;
                    
                }
            }
            else
            {
                currentPosition.GetComponent<PlaceHolder>().currentObject = null;
                currentPosition = fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1];
                this.transform.position = currentPosition.transform.position;
                fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1].GetComponent<PlaceHolder>().currentObject = this.gameObject;
                indexPosition += dice.GetComponent<Dice>().currentNumber + 1;
            }
        }
    }


}
