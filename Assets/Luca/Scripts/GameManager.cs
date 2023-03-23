using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject happinessText;
    public GameObject hungerText;
    public GameObject nameText;

    public GameObject Robot;

    void Update()
    {
        happinessText.GetComponent<TextMeshProUGUI>().text = "" + Robot.GetComponent<Robot> ().happiness;
        hungerText.GetComponent<TextMeshProUGUI>().text = "" + Robot.GetComponent<Robot> ().hunger;
        nameText.GetComponent<TextMeshProUGUI>().text = Robot.GetComponent<Robot> ().name;
    }
}
