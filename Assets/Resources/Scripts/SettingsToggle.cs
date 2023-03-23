using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsToggle : MonoBehaviour
{
// Start is called before the first frame update
private bool isOn = false;
private GameObject toggleCircle;
private Vector3 onPosition = new Vector3(23f, 0f, 0f);
private Vector3 offPosition = new Vector3(-23f, 0f, 0f);
private float lerpTime = 0.15f;
private float currentLerpTime;

// allow the user to drag in a script and also allow input so the user can enter a function the toggle should execute
public GameObject GO;
public string scriptName;
public string functionToExecute;

void Start()
{
    toggleCircle = transform.GetChild(0).gameObject;

    if (PlayerPrefs.GetInt("CurrentTheme", 1) == 1) {
        GO.GetComponent(scriptName).SendMessage("ToggleTheme");
        // GO.GetComponent(scriptName).SendMessage("ForceInvertColors");
        Toggle();
    }
}

    public void Toggle() {
        if (isOn == true)
        {
            // GetComponent<Image>().color = new Color32(255,255,255,255);
            isOn = false;
        }
        else
        {
            // GetComponent<Image>().color = new Color32(255,255,255,255);
            isOn = true;
        }
        currentLerpTime = 0f;

        // execute the function from GameObject.GetComponent(scriptName).functionToExecute
        GO.GetComponent(scriptName).SendMessage(functionToExecute);
    }

// Update is called once per frame
void Update()
{
    if (Input.GetKeyDown(KeyCode.Space)) {
        Toggle();
    }

    if (isOn == true) {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }

        float t = currentLerpTime / lerpTime;
        toggleCircle.transform.localPosition = Vector3.Lerp(offPosition, onPosition, t);
    }
    else {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) {
            currentLerpTime = lerpTime;
        }

        float t = currentLerpTime / lerpTime;
        toggleCircle.transform.localPosition = Vector3.Lerp(onPosition, offPosition, t);
    }
}
}