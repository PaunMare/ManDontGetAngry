using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dice : MonoBehaviour
{
    public Sprite[] sprites;
    System.Random a;
    public GameObject dice;
    public  bool pressed = false;
    //public Button rollTheDice;
    public int currentNumber;
    public void RollTheDice()
    {
        if (pressed == false)
        {
            a = new System.Random();
            int number = a.Next(6);
            currentNumber = number;
            dice.GetComponent<SpriteRenderer>().sprite = sprites[number];
            pressed = true;
        }
    }
}
