using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    
    System.Random a;
    public Text text;
    public GameObject[] redUnits, blueUnits, yellowUnits, greenUnits;
    GameObject[] players;
    GameObject red, blue, yellow, green;
    GameObject currentPlayer;
    public GameObject dice;
    public Button rollTheDicce;
    int firstPlayer;
    GameObject[] currentUnits;
    private void Awake()
    {
        red = GameObject.Find("Red");
        green = GameObject.Find("Green");
        yellow = GameObject.Find("Yellow");
        blue = GameObject.Find("Blue");
        a = new System.Random();
        firstPlayer = a.Next(4);
        players = new GameObject[4];
        players[0] = red;
        players[1] = green;
        players[2] = yellow;
        players[3] = blue;

        leftRotate(players, firstPlayer, players.Length);
        currentPlayer = players[0];
        text.text = "Current playing: " + currentPlayer.name;
        foreach (GameObject g in players)
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
                                text.text = "Current playing: " + currentPlayer.name;
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
                    text.text = "Current playing: " + currentPlayer.name;
                    dice.GetComponent<Dice>().pressed = false;
                }
            }
            else
            {
                if (currentPlayer.GetComponent<Player>().AllDeactivated())
                {
                    rollTheDicce.interactable = true;

                    leftRotate(players, 1, players.Length);
                    currentPlayer = players[0];
                    text.text = "Current playing: " + currentPlayer.name;
                    dice.GetComponent<Dice>().pressed = false;
                    return;
                }
                if (dice.GetComponent<Dice>().currentNumber == 5)
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
                                text.text = "Current playing: " + currentPlayer.name;
                                dice.GetComponent<Dice>().pressed = false;
                            }
                            if(hit.transform.gameObject.CompareTag(currentPlayer.tag + "Unit") && hit.transform.gameObject.GetComponent<Unit>().inHome)
                            {
                                hit.transform.gameObject.GetComponent<Unit>().MoveToStartingPosition();
                                rollTheDicce.interactable = true;
                                leftRotate(players, 0, players.Length);
                                currentPlayer = players[0];
                                text.text = "Current playing: " + currentPlayer.name;
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
                                text.text = "Current playing: " + currentPlayer.name;
                                dice.GetComponent<Dice>().pressed = false;
                            }
                        }
                    }
                }
            }
           
            currentPlayer.GetComponent<Player>().ActivateAll();
        }
        if (currentPlayer.GetComponent<Player>().units[0].GetComponent<Unit>().EndingPosition()
              && currentPlayer.GetComponent<Player>().units[1].GetComponent<Unit>().EndingPosition()
              && currentPlayer.GetComponent<Player>().units[2].GetComponent<Unit>().EndingPosition()
              && currentPlayer.GetComponent<Player>().units[3].GetComponent<Unit>().EndingPosition())
        {
            PlayerPrefs.SetString("winner", currentPlayer.gameObject.name);
            SceneManager.LoadScene(1);
            print("Winner" + currentPlayer.name);
        }
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
