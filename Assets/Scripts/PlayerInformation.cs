using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInformation : MonoBehaviour
{
    public Text bothErrors;
    public InputField firstPlayer, secondPlayer, thirdPlayer, fourthPlayer;
    string[] colors;

    private void Awake()
    {
        colors = new string[4];
        bothErrors.enabled = false;
        colors[0] = "red";
        colors[1] = "green";
        colors[2] = "blue";
        colors[3] = "yellow";
    }
    public void Submit()
    {
        
        bool nesto = AllDifferent();
        if(firstPlayer.text != "" && secondPlayer.text !="" && thirdPlayer.text != "" && fourthPlayer.text != "" && AllDifferent())
        {
            PlayerPrefs.SetString(colors[0].ToLower(), firstPlayer.text);
            PlayerPrefs.SetString(colors[1].ToLower(), secondPlayer.text);
            PlayerPrefs.SetString(colors[2].ToLower(), thirdPlayer.text);
            PlayerPrefs.SetString(colors[3].ToLower(), fourthPlayer.text);
            SceneManager.LoadScene(3);
        }
        else
        {
            bothErrors.enabled = true;
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public bool AllDifferent()
    {
        for(int i = 0;   i < colors.Length-1 ; i++){
            {
                for (int j = i + 1; j < colors.Length; j++)
                {
                    if (colors[i].Equals(colors[j]))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    public void SetFirstColor(int value)
    {
        if(value == 0)
        {
            colors[0] = "red";
        }else if(value == 1)
        {
            colors[0] = "green";
        }else if (value == 2)
        {
            colors[0] = "blue";
        }
        else if(value == 3)
        {
            colors[0] = "yellow";
        }
    }
    public void SetSecondColor(int value)
    {
        if (value == 0)
        {
            colors[1] = "red";
        }
        else if (value == 1)
        {
            colors[1] = "green";
        }
        else if (value == 2)
        {
           colors[1] = "blue";
        }
        else if(value == 3)
        {
            colors[1] = "yellow";
        }
    }
    public void SetThirdColor(int value)
    {
        if (value == 0)
        {
            colors[2] = "red";
        }
        else if (value == 1)
        {
            colors[2] = "green";
        }
        else if (value == 2)
        {
            colors[2] = "blue";
        }
        else if(value == 3)
        {
            colors[2] = "yellow";
        }
    }
    public void SetFourthColor(int value)
    {
        if (value == 0)
        {
            colors[3] = "red";
        }
        else if (value == 1)
        {
            colors[3] = "green";
        }
        else if (value == 2)
        {
            colors[3] = "blue";
        }
        else if(value == 3)
        {
            colors[3] = "yellow";
        }
    }
}
