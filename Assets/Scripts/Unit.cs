using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameObject startingPosition;
    public GameObject homePosition;
    public GameObject[] fieldPositions;
    public GameObject currentPosition;
    public bool inHome = true;
    public GameObject dice;
    public int indexPosition = 0;
    public GameObject placeholder;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = homePosition;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!inHome)
        //{
        //        if (this.gameObject.CompareTag(fieldPositions[indexPosition + dice.GetComponent<Dice>().currentNumber+1].GetComponent<PlaceHolder>().currentObject.tag))
        //        {
        //            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        //        }
        //        else
        //        {
        //            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        //        } 
        //}
        //if (inHome)
        //{
        //    if(startingPosition.GetComponent<PlaceHolder>().currentObject != null && startingPosition.GetComponent<PlaceHolder>().currentObject.tag==this.gameObject.tag)
        //    {
        //        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        //    }
        //    else
        //    {
        //        this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        //    }
        //}
        
    }

    public void MoveToStartingPosition()
    {
        if (inHome)
        {
           startingPosition.GetComponent<PlaceHolder>().currentObject = placeholder.GetComponent<PlaceHolder>().currentObject;
            if (startingPosition.gameObject.GetComponent<PlaceHolder>().currentObject == null)
            {
                inHome = false;
                //startingPosition.GetComponent<PlaceHolder>().currentObject.GetComponent<Unit>().ReturnToTheHouse();
                startingPosition.GetComponent<PlaceHolder>().currentObject = this.gameObject;
                fieldPositions[0].GetComponent<PlaceHolder>().currentObject = this.gameObject;
                currentPosition = startingPosition;
                this.gameObject.transform.position = startingPosition.transform.position;
                indexPosition = 0;
            }
            if(!startingPosition.gameObject.GetComponent<PlaceHolder>().currentObject.CompareTag(this.gameObject.tag))
            {
                
                    inHome = false;
                    startingPosition.GetComponent<PlaceHolder>().currentObject.GetComponent<Unit>().ReturnToTheHouse();
                    startingPosition.GetComponent<PlaceHolder>().currentObject = this.gameObject;
                    currentPosition = startingPosition;
                    this.gameObject.transform.position = startingPosition.transform.position;
                    indexPosition = 0;
            }
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
            if (indexPosition+ dice.GetComponent<Dice>().currentNumber + 1 < fieldPositions.Length)
            {
                this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
                if (fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1].GetComponent<PlaceHolder>().currentObject != null)
                {
                    if (!fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1].gameObject.GetComponent<PlaceHolder>().currentObject.CompareTag(this.gameObject.tag))
                    {
                        if(currentPosition == startingPosition)
                        {
                            startingPosition.GetComponent<PlaceHolder>().currentObject = null;
                            fieldPositions[0].GetComponent<PlaceHolder>().currentObject = null;
                        }
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
                    if(currentPosition == startingPosition)
                    {
                        startingPosition.GetComponent<PlaceHolder>().currentObject = null;
                        fieldPositions[0].GetComponent<PlaceHolder>().currentObject = null;
                    }
                    currentPosition.GetComponent<PlaceHolder>().currentObject = null;
                    currentPosition = fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1];
                    this.transform.position = currentPosition.transform.position;
                    fieldPositions[dice.GetComponent<Dice>().currentNumber + indexPosition + 1].GetComponent<PlaceHolder>().currentObject = this.gameObject;
                    indexPosition += dice.GetComponent<Dice>().currentNumber + 1;
                }
            }
        }
        else
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
    }
    public int ReturnIndexOfPosition(GameObject g, GameObject[] positions)
    {
        int index = -1;
        for(int i = 0; i < positions.Length; i++)
        {
            if (g.Equals(positions[i]))
            {
                index = i;
            }
        }
        return index;
    }

    public bool EndingPosition()
    {
        if (currentPosition.Equals(fieldPositions[fieldPositions.Length - 1]) || currentPosition.Equals(fieldPositions[fieldPositions.Length - 2]) || currentPosition.Equals(fieldPositions[fieldPositions.Length - 3]) || currentPosition.Equals(fieldPositions[fieldPositions.Length - 4]))
        {
            return true;
        }else
        {
            return false;
        }
    }


}
