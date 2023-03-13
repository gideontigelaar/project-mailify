using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject happinessText;
    public GameObject hungerText;

    public GameObject robot;

    void Update()
    {
        happinessText.GetComponent<TextMeshProUGUI>().text = "" + robot.GetComponent<Robot> ().happiness;
        hungerText.GetComponent<TextMeshProUGUI>().text = "" + robot.GetComponent<Robot> ().hunger;
    }
}
