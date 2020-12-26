using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Rules : MonoBehaviour
{
    public Text page1, page2;
    private void Awake()
    {
        page1.enabled = true;
        page2.enabled = false;
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NextPage()
    {
        page1.enabled = false;
        page2.enabled = true;
    }
    public void PreviousPage()
    {
        page1.enabled = true;
        page2.enabled = false;
    }


}
