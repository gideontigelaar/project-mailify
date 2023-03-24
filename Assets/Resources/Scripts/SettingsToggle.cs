using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsToggle : MonoBehaviour {

    bool isOn;
    GameObject toggleCircle;
    Vector3 onPosition = new Vector3(23f, 0f, 0f), offPosition = new Vector3(-23f, 0f, 0f);
    float lerpTime = 0.15f, currentLerpTime;
    public GameObject GO;
    public string scriptName, functionToExecute;

    void Start() {
        toggleCircle = transform.GetChild(0).gameObject;

        if (PlayerPrefs.GetInt("CurrentTheme", 1) == 1) {
            GO.GetComponent(scriptName).SendMessage("ToggleTheme");
            Toggle();
        }
    }

    void Toggle() {
        isOn = !isOn;
        // GetComponent<Image>().sprite = isOn ? Resources.Load<Sprite>("Sprites/Theme2/toggle_on") : Resources.Load<Sprite>("Sprites/Theme2/toggle_off");
        // GetComponent<Image>().color = isOn ? new Color(0.05882353f, 0.5058824f, 0.9803922f, 1f) : new Color(0f, 0f, 0f, 0.5f);

        // CODEGOESHERE








    //         if (isOn) {
    //     // Change sprite to the "toggle_on" sprite for the current theme
    //     GetComponent<Image>().sprite = currentThemeSprites[0];
    //     GetComponent<Image>().color = new Color(0.05882353f, 0.5058824f, 0.9803922f, 1f);
    // } else {
    //     // Change sprite to the "t_SliderBackgroundOff" sprite for the current theme
    //     // Find the sprite in the current theme's folder
    //     string spritePath = "Sprites/Theme" + PlayerPrefs.GetInt("CurrentTheme", 1) + "/t_SliderBackgroundOff";
    //     Sprite offSprite = Resources.Load<Sprite>(spritePath);

    //     GetComponent<Image>().sprite = offSprite;
    //     GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
    // }










        currentLerpTime = 0f;
        GO.GetComponent(scriptName).SendMessage(functionToExecute); // try { GO.GetComponent(scriptName).SendMessage(functionToExecute); } catch {}
    }

    void Update() {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > lerpTime) { currentLerpTime = lerpTime; }
        float t = currentLerpTime / lerpTime;
        toggleCircle.transform.localPosition = isOn ? Vector3.Lerp(offPosition, onPosition, t) : Vector3.Lerp(onPosition, offPosition, t);
    }
}
