using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public GameObject startingPosition;
    public GameObject homePosition;
    public GameObject[] fieldPositions;
    public GameObject currentPosition;
    public GameObject currentObject;
    public bool inHome = true;
    public GameObject dice;
    public int indexPosition = 0;
    public GameObject placeholder;
    public GameObject[] otherUnits;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = homePosition;
    }

    // Update is called once per frame
    void Update()
    {
        currentObject = fieldPositions[0].GetComponent<PlaceHolder>().currentObject;
        TurnOffTurnON();
    }

    public void MoveToStartingPosition()
    {
        if (inHome)
        {
           currentObject = placeholder.GetComponent<PlaceHolder>().currentObject;
            if (startingPosition.gameObject.GetComponent<PlaceHolder>().currentObject == null)
            {
                inHome = false;
                //startingPosition.GetComponent<PlaceHolder>().currentObject.GetComponent<Unit>().ReturnToTheHouse();
                currentObject = this.gameObject;
                fieldPositions[0].GetComponent<PlaceHolder>().currentObject = this.gameObject;
                currentPosition = startingPosition;
                this.gameObject.transform.position = startingPosition.transform.position;
                indexPosition = 0;
            }
            if(!startingPosition.gameObject.GetComponent<PlaceHolder>().currentObject.CompareTag(this.gameObject.tag))
            {
                    inHome = false;
                    currentObject.GetComponent<Unit>().ReturnToTheHouse();
                    currentObject = this.gameObject;
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
                            currentObject = null;
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
                        currentObject = null;
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
    public int ReturnFieldsTillEnd()
    {
        return fieldPositions.Length - ReturnIndex(currentPosition, fieldPositions);
    }
    public int ReturnIndex(GameObject g, GameObject[] positions)
    {
        int index = -1;
        for(int i = 0; i < positions.Length; i++)
        {
            if (g.transform.position.Equals(positions[i].transform.position))
                index = i;
        }
        return index;
    }
    public void TurnOffTurnON()
    {
        if (dice.GetComponent<Dice>().currentNumber > ReturnFieldsTillEnd() + 1)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        if (this.gameObject.GetComponent<Unit>().inHome && currentObject != null && currentObject.CompareTag(this.gameObject.tag))
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        if (inHome
            && currentObject != null
            && currentObject.CompareTag(this.gameObject.tag)
            && dice.GetComponent<Dice>().currentNumber == 5)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        if (inHome && currentObject == null)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        if (inHome && dice.GetComponent<Dice>().currentNumber == 5 && currentObject != null && currentObject.CompareTag(this.gameObject.tag))
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }

        if (ReturnIndex(this.currentPosition, fieldPositions) + dice.GetComponent<Dice>().currentNumber + 1 < fieldPositions.Length)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        if (ReturnIndex(this.currentPosition, fieldPositions) + dice.GetComponent<Dice>().currentNumber + 1 >= fieldPositions.Length)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        if (OtherInHouse() && ReturnIndex(this.currentPosition, fieldPositions) + dice.GetComponent<Dice>().currentNumber + 1 < fieldPositions.Length)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }

        if (ReturnIndex(this.currentPosition, fieldPositions) + dice.GetComponent<Dice>().currentNumber + 1 < fieldPositions.Length
            && fieldPositions[ReturnIndex(this.currentPosition, fieldPositions) + dice.GetComponent<Dice>().currentNumber + 1].GetComponent<PlaceHolder>().currentObject != null
            && ReturnIndex(this.currentPosition, fieldPositions) + dice.GetComponent<Dice>().currentNumber + 1 < fieldPositions.Length
            && fieldPositions[ReturnIndex(this.currentPosition, fieldPositions) + dice.GetComponent<Dice>().currentNumber + 1].GetComponent<PlaceHolder>().currentObject.CompareTag(this.gameObject.tag))
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }

        //if ((inHome && dice.GetComponent<Dice>().currentNumber < 5)
        //    || (inHome && dice.GetComponent<Dice>().currentNumber < 5 && currentObject != null && this.gameObject.CompareTag(currentObject.tag))
        //    || (!inHome && fieldPositions[ReturnIndex(currentPosition,fieldPositions)+dice.GetComponent<Dice>().currentNumber + 1].GetComponent<PlaceHolder>().currentObject != null
        //    && fieldPositions[ReturnIndex(currentPosition, fieldPositions) + dice.GetComponent<Dice>().currentNumber + 1].GetComponent<PlaceHolder>().currentObject.CompareTag(this.gameObject.tag)
        //    && ReturnIndex(currentPosition,fieldPositions)+dice.GetComponent<Dice>().currentNumber + 1 < fieldPositions.Length))
        //{
        //    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        //}
        //else
        //{
        //    this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
        //}

    }


    public bool IsItAtHome()
    {
        if (inHome)
            return true;
        else
            return false;
    }
    public bool IsActivated()
    {
        if (this.gameObject.GetComponent<CapsuleCollider>().enabled)
            return true;
        else
            return false;
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
    public bool OtherInHouse()
    {
        for(int i = 0; i < otherUnits.Length; i++)
        {
            if (!otherUnits[i].GetComponent<Unit>().inHome)
                return false;
        }
        return true;
    }


}
