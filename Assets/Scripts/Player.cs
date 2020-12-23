using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] units;
    public bool hasUnit = false;
    public Player(GameObject[] units)
    {
        this.units = units;
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
}
