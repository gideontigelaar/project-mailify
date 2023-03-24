using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject happinessText;
    public GameObject hungerText;

    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;

    public GameObject robot;

    void Update()
    {
        happinessText.GetComponent<TextMeshProUGUI>().text = "" + robot.GetComponent<Robot>().happiness;
        hungerText.GetComponent<TextMeshProUGUI>().text = "" + robot.GetComponent<Robot>().hunger;
        nameText.GetComponent<TextMeshProUGUI>().text = robot.GetComponent<Robot>().name;
    }

    public void triggerNamepanel(bool b)
    { 
        namePanel.SetActive(!namePanel.activeInHierarchy);
    
        if (b)
        {
            robot.GetComponent<Robot> ().name = nameInput.GetComponent<InputField> ().text;
            PlayerPrefs.SetString("name", robot.GetComponent<Robot>().name);
        }
    }

}
