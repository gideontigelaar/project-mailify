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

    void Start()
    {
      playerPrefs.SetString ("then", "09/03/2023 15:13:50");
      updateStatus ();  
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

        if (!playerPrefs.Haskey("then"))
            playerPrefs.SetString ("then", getStringTime());

            //Debug.Log (getStringSpan ().ToString ());
            //Debug.Log (getStringSpan ().TotalHours ());

        if (_serverTime) 
            updateServer ();
        else
        Invokerepeating ("updateDevice", 0f, 30f);
        

    }
   
    void updateServer()
    {
        
    }

    void updateDevice()
    {
        playerPrefs>SetString ("then", getStringTime ());
    }

   TimeSpan GetTimeSpan()
   {
        if (_serverTime)
            return new TimeSpan();
        else 
        return DateTime.Now - Convert.ToDateTime(playerPrefs.getString ("then"));
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
