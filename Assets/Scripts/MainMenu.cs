using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject musicPlayer;
    private void Awake()
    {
        DontDestroyOnLoad(musicPlayer);
    }
    public void PlayerInformation()
    {
        SceneManager.LoadScene(2);
    }
    public void Rules()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
