using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace PET
{
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
        public GameObject Happiness;

        
        void Start()
        {
            PlayerPrefs.SetString("then", "20/04/2023 08:00:00");
            updateStatus();
            if (!PlayerPrefs.HasKey("name"))
                PlayerPrefs.SetString("name", "Robot");
            _name = PlayerPrefs.GetString("name");


            
        }

        void Update()
        {
            
            
        }
        void updateStatus()
        {
                    if (!PlayerPrefs.HasKey("_hunger"))
                    {
                        _hunger = 100;
                        PlayerPrefs.SetInt("_hunger", _hunger);
                    }
                    else
                    {
                        _hunger = PlayerPrefs.GetInt("_hunger");
                    }

                    if (!PlayerPrefs.HasKey("_happiness"))
                    {
                        _happiness = 100;
                        PlayerPrefs.SetInt("_happiness", _happiness);
                    }
                    else
                    {
                        _happiness = PlayerPrefs.GetInt("_happiness");
                    }

                    if (!PlayerPrefs.HasKey("then"))
                        PlayerPrefs.SetString("then", getStringTime());


                    TimeSpan ts = getTimeSpan();
                    _hunger -= (int)(ts.TotalHours * 2);
            if (_hunger < 0) { 
                _hunger = 0; 
            }
            _happiness -= (int)((100 - _hunger) * (ts.TotalHours * 5));
            if (_happiness < 0)
            {
                _happiness = 0;
            }
            if (_happiness == 0) //* (ts.TotalDays * 4))
            {
              asielPanel.SetActive(true);
            Person.SetActive(false);
            }









            if (_serverTime)
                        updateServer();
                    else
                        InvokeRepeating("updateDevice", 0f, 30f);


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
                    return new TimeSpan();
                else
                    return DateTime.Now - Convert.ToDateTime(PlayerPrefs.GetString("then"));
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
            if (happiness > 99)
                happiness = 99;
        }
        public void UpdateHunger(int i)
        {
            hunger += i;
            if (hunger > 99)
                hunger = 99;
        }

        public void Updatecoin(int i)
        {
            coin += i;
            if (coin > 99)
                coin = 99;
            if (coin < 0)
                coin = 0;

        }
        public void saveRobot()
        {
            if (!_serverTime)
                updateDevice();
            PlayerPrefs.SetInt("_hunger", _hunger);
            PlayerPrefs.SetInt("_happiness", _happiness);
            PlayerPrefs.SetInt("_coin", _coin);
        }

        public void foodButton(int i)
        {
            switch (i)
            {
                case 0:
                default:
                if (coin > 1) 
                {
                    UpdateHappiness(2);
                    UpdateHunger(1);
                    Updatecoin(-1);
                }
                break;

                case (1):
                if (coin > 2) 
                {
                    UpdateHappiness(4);
                    UpdateHunger(2);
                    Updatecoin(-2);
                }
                break;

                case (2):
                if (coin > 3) 
                {
                    UpdateHappiness(6);
                    UpdateHunger(3);
                    Updatecoin(-3);
                }
                break;
            }
        }

        public void questButton(int i)
        {
            switch (i)
            {
                case 0:
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
                    if (coin >= 50)
                    {
                        Updatecoin(-50);
                        asielPanel.SetActive(false);
                        Person.SetActive(true);
                    }
                 break;
                
            }
           
        }

        public void aaiButton(int i)
        {
            switch (i)
            {
                case 0:
                default:
                UpdateHappiness(30);
                    break;

            }

        }


    }
    
       

    
}