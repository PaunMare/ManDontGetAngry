using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Victory : MonoBehaviour
{
    public Button exit;
    public Text text;
    void Start()
    {
        text.text ="The winner is: " + PlayerPrefs.GetString("winner");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
