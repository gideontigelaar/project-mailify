using System;
using System.Collections;
using UnityEngine;

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

       
        void Start()
        {
            PlayerPrefs.SetString("then", "13/04/2023 13:00:00");
            updateStatus();
            if (!PlayerPrefs.HasKey("name"))
                PlayerPrefs.SetString("name", "Robot");
            _name = PlayerPrefs.GetString("name");
        }

        void Update()
        {
            GetComponent<Animator>().SetBool("jump", gameObject.transform.position.y > -0.48f);

            if (Input.GetMouseButtonUp(0))
            {
                
                Vector2 v = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(v), Vector2.zero);
                if (hit)
                {


                    if (hit.transform.gameObject.tag == "robot")
                    {
                        _clickCount++;

                        if (_clickCount >= 1)
                        {
                            _clickCount = 0;
                            UpdateHappiness(1);
                            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
                        }
                    }
                }
            }
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
            if (_hunger < 0)
                _hunger = 0;
            _happiness -= (int)((100 - _hunger) * (ts.TotalHours / 5));
            if (_happiness < 0)
                _happiness = 0;
            


           

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
            if (happiness > 100)
                happiness = 100;
        }
        public void UpdateHunger(int i)
        {
            hunger += i;
            if (hunger > 100)
                hunger = 100;
        }

        public void Updatecoin(int i)
        {
            coin += i;
            if (coin > 1000)
                coin = 1000;
        }
        public void saveRobot()
        {
            if (!_serverTime)
                updateDevice();
            PlayerPrefs.SetInt("_hunger", _hunger);
            PlayerPrefs.SetInt("_coin", _coin);
            PlayerPrefs.SetInt("_happiness", _happiness);
        }

        public void foodButton(int i)
        {
            switch (i)
            {
                case 0:
                default:
                if (coin > 1) {
                    UpdateHunger(1);
                    Updatecoin(-1);
                }
                break;

                case (1):
                if (coin > 2) {
                    UpdateHunger(2);
                    Updatecoin(-2);
                }
                break;

                case (2):
                if (coin > 3) {
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
                    Updatecoin(-20);
                    break;
                
            }
        }

    }
}