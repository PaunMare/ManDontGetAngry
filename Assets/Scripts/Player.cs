using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] units;
    public bool hasUnit = false;
    public string nickName;
    public GameObject[] endingPositions;
    public GameObject startingPosition;
    public Player(GameObject[] units)
    {
        this.units = units;
    }
   
    //public bool AllDeactivated()
    //{
    //    foreach (GameObject g in units)
    //    {
    //        if (g.GetComponent<CapsuleCollider>().enabled == true)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}
    public bool AllDeactivated()
    {
        if(units[0].gameObject.GetComponent<CapsuleCollider>().enabled == false
            && units[1].gameObject.GetComponent<CapsuleCollider>().enabled == false
            && units[2].gameObject.GetComponent<CapsuleCollider>().enabled == false
            && units[3].gameObject.GetComponent<CapsuleCollider>().enabled == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AllInHouse()
    {
       foreach(GameObject g in units)
        {
            if (!g.GetComponent<Unit>().inHome)
            {
                return false;
            }
        
       }
        return true;
    }
    public void FixHome()
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i].GetComponent<Unit>().IsItAtHome() && startingPosition.GetComponent<PlaceHolder>().currentObject!=null && startingPosition.GetComponent<PlaceHolder>().currentObject.CompareTag(units[i].gameObject.tag))
            {
                units[i].gameObject.GetComponent<CapsuleCollider>().enabled = false;
            }
            else
            {
                continue;
            }
        }
    }
    public GameObject OutOfTheHouse(GameObject[] units,GameObject g)
    {
        for(int i = 0; i < units.Length; i++)
        {
            if (!units[i].GetComponent<Unit>().inHome)
            {
                return units[i];
            }
        }
        return null;
    }
    public int OutsideNumber(GameObject[] units, GameObject g)
    {
        int number = 0;
        for (int i = 0; i < units.Length; i++)
        {
            if (!units[i].GetComponent<Unit>().inHome)
            {
                number++;
            }
        }
        return number;
    }
    public bool Victory()
    {
        foreach (GameObject g in endingPositions)
        {
            if(g.GetComponent<PlaceHolder>().currentObject == null)
            {
                return false;
            }
            if (g.GetComponent<PlaceHolder>().currentObject != null && !this.gameObject.CompareTag(g.GetComponent<PlaceHolder>().currentObject.tag))
            {
                return false;
            }
           
        }
        return true;
    }
    //public void ActivateAll()
    //{
    //    foreach(GameObject g in units)
    //    {
    //        g.GetComponent<CapsuleCollider>().enabled = true;
    //    }
    //}
}
