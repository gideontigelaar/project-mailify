using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu: MonoBehaviour
{
    public GameObject ShopPanel;
    public GameObject QuestsPanel;
    public GameObject SettingsPanel;

    public GameObject GameBtn;
    public GameObject ShopBtn;
    public GameObject QuestsBtn;
    public GameObject SettingsBtn;

    public void Start()
    {
        GameBtn.GetComponentInChildren<Image>().color = new Color32(12,132,255,255);
        GameBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(12,132,255,255);
	}

    public void OpenGame()
    {
        ShopPanel.SetActive(false);
        QuestsPanel.SetActive(false);
        SettingsPanel.SetActive(false);

        GameBtn.GetComponentInChildren<Image>().color = new Color32(12,132,255,255);
        ShopBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);

        GameBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(12,132,255,255);
        ShopBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
    }

    public void OpenShop()
    {
        ShopPanel.SetActive(true);
        QuestsPanel.SetActive(false);
        SettingsPanel.SetActive(false);

        GameBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<Image>().color = new Color32(12,132,255,255);
        QuestsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);

        GameBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(12,132,255,255);
        QuestsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
    }

    public void OpenQuests()
    {
        ShopPanel.SetActive(false);
        QuestsPanel.SetActive(true);
        SettingsPanel.SetActive(false);

        GameBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<Image>().color = new Color32(12,132,255,255);
        SettingsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);

        GameBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(12,132,255,255);
        SettingsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
    }

    public void OpenSettings()
    {
        ShopPanel.SetActive(false);
        QuestsPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        
        GameBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<Image>().color = new Color32(12,132,255,255);

        GameBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(12,132,255,255);
    }
}