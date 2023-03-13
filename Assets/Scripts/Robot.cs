using System;
using System.Collections;
using UnityEngine;

public class Robot : MonoBehaviour
{
[SerializeField]
  private int _hunger;
 [SerializeField]
  private int _happiness;

  private bool _serverTime;
  private int _clickCount;

    void Start()
    {
      PlayerPrefs.SetString ("then", "10/03/2023 10:00:00");
      updateStatus ();  
    }

    void Update()
    {
        if (Input.GetMouseButtonUp (0))
        {
            Debug.Log ("Clicked");
            Vector2 v = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (v), Vector2.zero);
            if (hit)
            {
                Debug.Log (hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag == "robot")
                {
                    _clickCount++;
                    if (_clickCount >= 3)
                    {
                        _clickCount = 0;
                        UpdateHappiness (1);
                    }
                }
            }
        }
    }

    void updateStatus()
    {
        if (!PlayerPrefs.HasKey ("_hunger")) 
        {
            _hunger = 100;
            PlayerPrefs.SetInt ("_hunger",_hunger);
        }
        else
        {
            _hunger = PlayerPrefs.GetInt ("_hunger");
        }

        if (!PlayerPrefs.HasKey ("_happiness")) 
        {
            _happiness = 100;
            PlayerPrefs.SetInt ("_happiness",_happiness);
        }
        else
        {
            _happiness = PlayerPrefs.GetInt ("_happiness");
        }

        if (!PlayerPrefs.HasKey("then"))
            PlayerPrefs.SetString ("then", getStringTime());


            TimeSpan ts = getTimeSpan ();
            _hunger -= (int) (ts.TotalHours * 2);
            if (_hunger < 0)
                _hunger = 0;
            _happiness -= (int) ((100 - _hunger) * (ts.TotalHours / 5));
            if (_happiness < 0)
                _happiness = 0;



           //Debug.Log (getTimeSpan ().ToString ());
            //Debug.Log (getTimeSpan ().TotalHours );

        if (_serverTime) 
            updateServer ();
        else
        InvokeRepeating ("updateDevice", 0f, 30f);
        

    }
   
    void updateServer()
    {
        
    }

    void updateDevice()
    {
        PlayerPrefs.SetString ("then", getStringTime ());
    }

   TimeSpan getTimeSpan()
   {
        if (_serverTime)
           return new TimeSpan();
       else 
        return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString ("then"));
   }

    string getStringTime()
    {
        DateTime now =DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " + now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    public int hunger
    {
        get {return _hunger;}
        set {_hunger = value;}
    }

    public int happiness
    {
        get{return _happiness;}
        set {_happiness = value;}
    }

    public void UpdateHappiness(int i)
    {
        happiness += i;
        if (happiness > 100)
            happiness = 100;
    }

}
