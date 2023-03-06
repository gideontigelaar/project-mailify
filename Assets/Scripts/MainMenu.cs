using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu: MonoBehaviour
{
    public GameObject Shop;
    public GameObject Quests;
    public GameObject Settings;

    public GameObject GameBtn;
    public GameObject ShopBtn;
    public GameObject QuestsBtn;
    public GameObject SettingsBtn;

    public void Start()
    {
        GameBtn.GetComponentInChildren<Image>().color = new Color32(137,207,240,255);
        GameBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(137,207,240,255);
	}

    public void OpenGame()
    {
        Shop.SetActive(false);
        Quests.SetActive(false);
        Settings.SetActive(false);

        GameBtn.GetComponentInChildren<Image>().color = new Color32(137,207,240,255);
        ShopBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);

        GameBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(137,207,240,255);
        ShopBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
    }

    public void OpenShop()
    {
        Shop.SetActive(true);
        Quests.SetActive(false);
        Settings.SetActive(false);

        GameBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<Image>().color = new Color32(137,207,240,255);
        QuestsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);

        GameBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(137,207,240,255);
        QuestsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
    }

    public void OpenQuests()
    {
        Shop.SetActive(false);
        Quests.SetActive(true);
        Settings.SetActive(false);

        GameBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<Image>().color = new Color32(137,207,240,255);
        SettingsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);

        GameBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(137,207,240,255);
        SettingsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
    }

    public void OpenSettings()
    {
        Shop.SetActive(false);
        Quests.SetActive(false);
        Settings.SetActive(true);
        
        GameBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<Image>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<Image>().color = new Color32(137,207,240,255);

        GameBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        ShopBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        QuestsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(112,112,112,255);
        SettingsBtn.GetComponentInChildren<TextMeshProUGUI>().color = new Color32(137,207,240,255);
    }
}