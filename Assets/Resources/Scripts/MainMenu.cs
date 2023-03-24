using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour {

    public GameObject ShopPanel, QuestsPanel, SettingsPanel;
    public GameObject GameBtn, ShopBtn, QuestsBtn, SettingsBtn;

    public void Start() {
        if (PlayerPrefs.GetInt("CurrentTheme", 1) == 1) {
            SetButtonColor(GameBtn, new Color32(10,154,255,255));
        }

        else {
            SetButtonColor(GameBtn, new Color32(10,154,255,255));
        }
    }

    public void OpenGame() {
        if (PlayerPrefs.GetInt("CurrentTheme", 1) == 1) {
            SetButtonColors(GameBtn, ShopBtn, QuestsBtn, SettingsBtn, new Color32(10,154,255,255));
        }

        else {
            SetButtonColors(GameBtn, ShopBtn, QuestsBtn, SettingsBtn, new Color32(10,154,255,255));
        }
    }

    public void OpenShop() {
        if (PlayerPrefs.GetInt("CurrentTheme", 1) == 1) {
            SetButtonColors(ShopBtn, GameBtn, QuestsBtn, SettingsBtn, new Color32(10,154,255,255));
        }

        else {
            SetButtonColors(ShopBtn, GameBtn, QuestsBtn, SettingsBtn, new Color32(10,154,255,255));
        }
    }

    public void OpenQuests() {
        if (PlayerPrefs.GetInt("CurrentTheme", 1) == 1) {
            SetButtonColors(QuestsBtn, GameBtn, ShopBtn, SettingsBtn, new Color32(10,154,255,255));
        }

        else {
            SetButtonColors(QuestsBtn, GameBtn, ShopBtn, SettingsBtn, new Color32(10,154,255,255));
        }
    }

    public void OpenSettings() {
        if (PlayerPrefs.GetInt("CurrentTheme", 1) == 1) {
            SetButtonColors(SettingsBtn, GameBtn, ShopBtn, QuestsBtn, new Color32(10,154,255,255));
        }

        else {
            SetButtonColors(SettingsBtn, GameBtn, ShopBtn, QuestsBtn, new Color32(10,154,255,255));
        }
    }

    void SetButtonColors(GameObject activeBtn, GameObject inactiveBtn1, GameObject inactiveBtn2, GameObject inactiveBtn3, Color32 activeColor) {
        ShopPanel.SetActive(activeBtn == ShopBtn);
        QuestsPanel.SetActive(activeBtn == QuestsBtn);
        SettingsPanel.SetActive(activeBtn == SettingsBtn);
        SetButtonColor(activeBtn, activeColor);
        SetButtonColor(inactiveBtn1, new Color32(112,112,112,255));
        SetButtonColor(inactiveBtn2, new Color32(112,112,112,255));
        SetButtonColor(inactiveBtn3, new Color32(112,112,112,255));
    }

    void SetButtonColor(GameObject button, Color32 color) {
        button.GetComponentInChildren<Image>().color = color;
        button.GetComponentInChildren<TextMeshProUGUI>().color = color;
    }
}
