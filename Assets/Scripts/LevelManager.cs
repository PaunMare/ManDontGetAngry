using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    
    System.Random a;
   
    public GameObject[] redUnits, blueUnits, yellowUnits, greenUnits;
    public GameObject[] players;
    GameObject red, blue, yellow, green;
    GameObject currentPlayer;
    public GameObject dice;
    public Button rollTheDicce;
    int firstPlayer;
    private void Awake()
    {
        red = GameObject.Find("Red");
        green = GameObject.Find("Green");
        yellow = GameObject.Find("Yellow");
        blue = GameObject.Find("Blue");
        a = new System.Random();
        firstPlayer = a.Next(4);
        leftRotate(players, firstPlayer, players.Length);
        currentPlayer = players[0];
        foreach(GameObject g in players)
        {
            print(g.name);
        }
        print(currentPlayer.name);
        
    }


    // Update is called once per frame
    void Update()
    {
        if (dice.GetComponent<Dice>().pressed)
        {
            if (currentPlayer.GetComponent<Player>().AllInHouse())
            {
                if(dice.GetComponent<Dice>().currentNumber == 5)
                {
                    rollTheDicce.interactable = false;
                    if (Input.GetMouseButtonDown(0))
                    {
                        RaycastHit hit;
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit, 1000f))
                        {
                            if (hit.transform.gameObject.CompareTag(currentPlayer.tag + "Unit"))
                            {
                                hit.transform.gameObject.GetComponent<Unit>().MoveToStartingPosition();
                                rollTheDicce.interactable = true;

                                leftRotate(players, 0, players.Length);
                                currentPlayer = players[0];
                                dice.GetComponent<Dice>().pressed = false;
                            }
                        }
                    }
                }
                else
                {
                    leftRotate(players, 1, players.Length);
                    rollTheDicce.interactable = true;
                    currentPlayer = players[0];
                    dice.GetComponent<Dice>().pressed = false;
                }
            }
            else
            {
                if(dice.GetComponent<Dice>().currentNumber == 5)
                {
                    rollTheDicce.interactable = false;
                    if (Input.GetMouseButtonDown(0))
                    {
                        RaycastHit hit;
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit, 1000f))
                        {
                            if (hit.transform.gameObject.CompareTag(currentPlayer.tag + "Unit") && !hit.transform.gameObject.GetComponent<Unit>().inHome)
                            {
                                hit.transform.gameObject.GetComponent<Unit>().MoveThroughTheField();
                                rollTheDicce.interactable = true;
                                leftRotate(players, 0, players.Length);
                                currentPlayer = players[0];
                                dice.GetComponent<Dice>().pressed = false;
                            }
                            if(hit.transform.gameObject.CompareTag(currentPlayer.tag + "Unit") && hit.transform.gameObject.GetComponent<Unit>().inHome)
                            {
                                hit.transform.gameObject.GetComponent<Unit>().MoveToStartingPosition();
                                rollTheDicce.interactable = true;
                                leftRotate(players, 0, players.Length);
                                currentPlayer = players[0];
                                dice.GetComponent<Dice>().pressed = false;
                            }
                        }
                    }
                }
                else
                {
                    rollTheDicce.interactable = false;
                    if (Input.GetMouseButtonDown(0))
                    {
                        RaycastHit hit;
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out hit, 1000f))
                        {
                            if (hit.transform.gameObject.CompareTag(currentPlayer.tag + "Unit"))
                            {
                                hit.transform.gameObject.GetComponent<Unit>().MoveThroughTheField();
                                leftRotate(players, 1, players.Length);
                                rollTheDicce.interactable = true;
                                currentPlayer = players[0];
                                dice.GetComponent<Dice>().pressed = false;
                            }
                        }
                    }
                }
            }
        }









































        //if (dice.GetComponent<Dice>().pressed)
        //{
        //    if (!currentPlayer.GetComponent<Player>().AllInHouse())
        //    {
        //        currentPlayer.GetComponent<Player>().hasUnit = true;
        //        if (currentPlayer.GetComponent<Player>().hasUnit)
        //        {
        //            rollTheDicce.interactable = false;
        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                RaycastHit hit;
        //                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //                if(Physics.Raycast(ray,out hit, 1000f))
        //                {
        //                    if (hit.transform.gameObject.CompareTag(currentPlayer.tag + "Unit"))
        //                    {
        //                        rollTheDicce.interactable = true;
        //                        hit.transform.gameObject.GetComponent<Unit>().MoveThroughTheField();
        //                        //hit.transform.gameObject.GetComponent<Unit>().MoveToStartingPosition();


        //                        dice.GetComponent<Dice>().pressed = false;
        //                        if (dice.GetComponent<Dice>().currentNumber == 5)
        //                        {
        //                            leftRotate(players, 0, players.Length);
        //                        }
        //                        else
        //                        {
        //                            leftRotate(players, 1, players.Length);
        //                        }
        //                        currentPlayer = players[0];
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if(rollTheDicce.GetComponent<Dice>().currentNumber == 5)
        //        {
        //            RaycastHit hit;
        //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //            if (Physics.Raycast(ray, out hit, 1000f))
        //            {
        //                if (hit.transform.gameObject.CompareTag(currentPlayer.tag + "Unit"))
        //                {
        //                    rollTheDicce.interactable = true;
        //                    //hit.transform.gameObject.GetComponent<Unit>().MoveThroughTheField();
        //                    hit.transform.gameObject.GetComponent<Unit>().MoveToStartingPosition();


        //                    dice.GetComponent<Dice>().pressed = false;
        //                    if (dice.GetComponent<Dice>().currentNumber == 5)
        //                    {
        //                        leftRotate(players, 0, players.Length);
        //                    }
        //                    else
        //                    {
        //                        leftRotate(players, 1, players.Length);
        //                    }
        //                    currentPlayer = players[0];
        //                }
        //            }
        //        }
        //        else
        //        {
        //            leftRotate(players, 1, players.Length);
        //            currentPlayer = players[0];
        //        }
        //    }
                //if (currentPlayer.GetComponent<Player>().hasUnit)
                //{
                //    rollTheDicce.interactable = false;
                //    if (Input.GetMouseButtonDown(0))
                //    {
                //        RaycastHit hit;
                //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //        if (Physics.Raycast(ray, out hit, 1000f))
                //        {
                //            if (hit.transform.gameObject.CompareTag(currentPlayer.tag + "Unit"))
                //            {
                //                rollTheDicce.interactable = true;
                //                hit.transform.gameObject.GetComponent<Unit>().MoveThroughTheField();
                //                hit.transform.gameObject.GetComponent<Unit>().MoveToStartingPosition();


                //                dice.GetComponent<Dice>().pressed = false;
                //                if (dice.GetComponent<Dice>().currentNumber == 5)
                //                {
                //                    leftRotate(players, 0, players.Length);
                //                }
                //                else
                //                {
                //                    leftRotate(players, 1, players.Length);
                //                }
                //                currentPlayer = players[0];
                //            }
                //        }
                //    }
                //}
            
        }
    static void leftRotate(GameObject[] arr, int d, int n)
    {
        for (int i = 0; i < d; i++)
            leftRotatebyOne(arr, n);
    }
    static void leftRotatebyOne(GameObject[] arr, int n)
    {
        int i;
        GameObject temp = arr[0];
        for (i = 0; i < n - 1; i++)
            arr[i] = arr[i + 1];

        arr[i] = temp;
    }
}
