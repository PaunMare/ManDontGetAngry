using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewLevelManager : MonoBehaviour
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
        players[0].GetComponent<Player>().nickName = PlayerPrefs.GetString("red");
        players[1].GetComponent<Player>().nickName = PlayerPrefs.GetString("green");
        players[2].GetComponent<Player>().nickName = PlayerPrefs.GetString("yellow");
        players[3].GetComponent<Player>().nickName = PlayerPrefs.GetString("blue");
        leftRotate(players, firstPlayer, players.Length);
        currentPlayer = players[0];
        text.text = "Current playing: " + currentPlayer.GetComponent<Player>().nickName;
    }

    // Update is called once per frame
    void Update()
    {
        if (dice.GetComponent<Dice>().pressed)
        {

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
