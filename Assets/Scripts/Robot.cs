using System;
using System.Collections;
using UnityEngine;

public class Robot : MonoBehaviour
{
[SerializeField]
  private int _hunger;
 [SerializeField]
  private int _happines;

  private bool _serverTime;
  private int _clickCount;

    void Start()
    {
      PlayerPrefs.SetString ("then", "13/03/2023 10:00:00");
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

        if (!PlayerPrefs.HasKey ("_happines")) 
        {
            _happines = 100;
            PlayerPrefs.SetInt ("_happines",_happines);
        }
        else
        {
            _happines = PlayerPrefs.GetInt ("_happines");
        }

        if (!PlayerPrefs.HasKey("then"))
            PlayerPrefs.SetString ("then", getStringTime());


            TimeSpan ts = getTimeSpan ();
            _hunger -= (int) (ts.TotalHours * 2);
            if (_hunger < 0)
                _hunger = 0;
            _happines -= (int) ((100 - _hunger) * (ts.TotalHours / 5));
            if (_happines < 0)
                _happines = 0;



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

    public int happines
    {
        get{return _happines;}
        set {_happines = value;}
    }
}
