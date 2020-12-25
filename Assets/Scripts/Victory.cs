using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Victory : MonoBehaviour
{
    public Button exit;
    public Text text;
    void Start()
    {
        text.text ="The winner is: " + PlayerPrefs.GetString("winner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
