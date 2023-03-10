using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject happinessText;
    public GameObject hungerText;

    public GameObject robot;

    void Update()
    {
        happinessText.GetComponent<Text> ().text = "" + robot.GetComponent<Robot> ().happines;
        hungerText.GetComponent<Text> ().text = "" + robot.GetComponent<Robot> ().hunger;
    }
}
