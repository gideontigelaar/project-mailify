using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Robot : MonoBehaviour
{
    [SerializeField]
    private int _hunger;
    [SerializeField]
    private int _happiness;
    [SerializeField]
    private int _coin;
    [SerializeField]
    private string _name;

    private bool _serverTime;
    private int _clickCount;

    public GameObject asielPanel;
    public GameObject Person;
    public GameObject aaiButton;
    public GameObject Happiness;
    public GameObject FoodPanel;
    // public GameObject mailButton;

    void Start()
    {
        PlayerPrefs.SetString("then", "20/04/2023 08:00:00");
        updateStatus();

        if (PlayerPrefs.HasKey("name")) { _name = PlayerPrefs.GetString("name"); }
        else { PlayerPrefs.SetString("name", "Robot"); _name = "Robot"; }

        if (PlayerPrefs.HasKey("coin")) { _coin = PlayerPrefs.GetInt("coin"); }
        else { PlayerPrefs.SetInt("coin", 0); _coin = 0; }

        if (PlayerPrefs.HasKey("hunger")) { _hunger = PlayerPrefs.GetInt("hunger"); }
        else { PlayerPrefs.SetInt("hunger", 65); _hunger = 65; }

        if (PlayerPrefs.HasKey("happiness")) { _happiness = PlayerPrefs.GetInt("happiness"); }
        else { PlayerPrefs.SetInt("happiness", 65); _happiness = 65; }   
    }

    void Update()
    {
    }
    
    void updateStatus()
    {
        TimeSpan ts = getTimeSpan();

        if (!PlayerPrefs.HasKey("then"))
        {
            PlayerPrefs.SetString("then", getStringTime());
            _hunger -= (int)(ts.TotalHours * 2);
        }
        
        _happiness -= (int)((99 - _hunger) * (ts.TotalHours * 5));

        if (_hunger <= 0) { _hunger = 0; }

        if (_happiness <= 0) { _happiness = 0; }

        if (_happiness == 0) //* (ts.TotalDays * 4))
        {
            asielPanel.SetActive(true);
            Person.SetActive(false);
            aaiButton.SetActive(false);
        }

        if (_serverTime) { updateServer(); }

        else { InvokeRepeating("updateDevice", 0f, 30f); }
    }

    void updateServer()
    {
    }

    void updateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    TimeSpan getTimeSpan()
    {
        if (_serverTime)
        {
            return new TimeSpan();
        }

        else
        {
            return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
        }
    }

    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    public int hunger
    {
        get { return _hunger; }
        set { _hunger = value; }
    }

    public int happiness
    {
        get { return _happiness; }
        set { _happiness = value; }
    }

    public string name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int coin
    {
        get { return _coin; }
        set { _coin = value; }
    }

    public void UpdateHappiness(int i)
    {
        happiness += i;

        if (happiness >= 99)
        {
        happiness = 99;
        }
    }

    public void UpdateHunger(int i)
    {
        hunger += i;

        if (hunger >= 99)
        {
        hunger = 99;
        }
    }

    public void Updatecoin(int i)
    {
        coin += i;
        if (coin >= 99)
        {
            coin = 99;
        }

        if (coin <= 0)
        {
            coin = 0;
        }
    }

    public void saveRobot()
    {
        if (!_serverTime)
        {
            updateDevice();
            PlayerPrefs.SetInt("hunger", _hunger);
            PlayerPrefs.SetInt("happiness", _happiness);
            PlayerPrefs.SetInt("coin", _coin);
        }
    }

    public void foodButton(int i)
    {
        switch (i)
        {
            case 0:
            default:
            if (coin >= 5)
            {
                UpdateHappiness(20);
                UpdateHunger(25);
                Updatecoin(-5);
                FoodPanel.SetActive(false);
            }
            break;

            case (1):
            if (coin >= 10)
            {
                UpdateHappiness(30);
                UpdateHunger(45);
                Updatecoin(-10);
                FoodPanel.SetActive(false);
            }
            break;

            case (2):
            if (coin >= 15) {
                UpdateHappiness(40);
                UpdateHunger(65);
                Updatecoin(-15);
                FoodPanel.SetActive(false);
            }
            break;
        }
    }

    public void questButton(int i)
    {
        switch (i)
        {
            case (0):
            default:
                Updatecoin(25);
            break;

            case (1):
                Updatecoin(50);
            break;

            case (2):
                Updatecoin(75);
            break;

            case (3):
                Updatecoin(100);
            break;
        }
    }

    public void asielButton(int i)
    {
        switch (i)
        {
            case 0:
            default:
            if (coin >= 30)
            {
                Updatecoin(-30);
                asielPanel.SetActive(false);
                Person.SetActive(true);
                aaiButton.SetActive(true);
            }
            break;
        }
    }

    public void AaiButton(int i)
    {
        switch (i)
        {
            case 0:
            default:
            UpdateHappiness(5);
            Person.transform.position = new Vector3((float) - 0.23, 0, (float) - 9.012836);
            break;
        }
    }

    // public void mailButton(int i)
    // {
    //     Application.OpenURL("mailto:");
    //     mailButton1.SetActive(false);
    // }
}