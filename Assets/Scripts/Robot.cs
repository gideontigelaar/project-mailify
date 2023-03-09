using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
  private int _hunger;
  private int _happines;

  private bool _serverTime;

    void Start()
    {
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

        if (_serverTime) 
        {
            updateServer ();
        }
        else
        {
            updateDevice;
        }

    }
   
    void updateServer()
    {
        
    }

    void updateDevice()
    {
        
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
