using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject happinessText;
    public GameObject hungerText;
    public GameObject coinText;
    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;
    public GameObject robot;
    public GameObject foodPanel;
    public GameObject questPanel;
    public GameObject asielPanel;
    public GameObject mailButton1;
    public GameObject mailButton2;



    void Update()
    {
        happinessText.GetComponent<TextMeshProUGUI>().text = "" + robot.GetComponent<Robot>().happiness;
        hungerText.GetComponent<TextMeshProUGUI>().text = "" + robot.GetComponent<Robot>().hunger;
        coinText.GetComponent<TextMeshProUGUI>().text = "" + robot.GetComponent<Robot>().coin;
        nameText.GetComponent<TextMeshProUGUI>().text = robot.GetComponent<Robot>().name;        
    }

    public void triggerNamepanel(bool b)
    { 
        namePanel.SetActive(!namePanel.activeInHierarchy);
    
        if (b)
        {
            robot.GetComponent<Robot> ().name = nameInput.GetComponent<TMP_InputField>().text;
            PlayerPrefs.SetString("name", robot.GetComponent<Robot>().name);
        }
    }

    public void Mail1()
    {
        Application.OpenURL("https://outlook.live.com/owa/");
        mailButton1.SetActive(false);
    }

    public void Mail2()
    {
        Application.OpenURL("https://outlook.live.com/owa/");
        mailButton2.SetActive(false);
    }


}