using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] units;
    public bool hasUnit = false;
    public GameObject[] endingPositions;
    public Player(GameObject[] units)
    {
        this.units = units;
    }
   
    public bool AllDeactivated()
    {
        foreach (GameObject g in units)
        {
            if (g.GetComponent<CapsuleCollider>().enabled == true)
            {
                return false;
            }
        }
        return true;
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
    public void ActivateAll()
    {
        foreach(GameObject g in units)
        {
            g.GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}
