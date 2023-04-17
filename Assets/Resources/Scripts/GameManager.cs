using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PET
{ 
    public class GameManager : MonoBehaviour
    {

        public GameObject happinessText;
        public GameObject hungerText;
        public GameObject coinText;

        public GameObject namePanel;
        public GameObject nameInput;
        public GameObject nameText;

        public GameObject robot;
        public GameObject robotPanel;
        public GameObject []robotList;

        public GameObject homePanel;
        public Sprite[] homeTilesSprites;
        public GameObject[] homeTiles;


        public GameObject background;
        public Sprite[] backgroundOptions;

        public GameObject foodPanel;
        public Sprite[] foodIcons;

        public GameObject questPanel;
        public GameObject asielPanel;

        private void Start()
        {
            if (!PlayerPrefs.HasKey("looks"))
                PlayerPrefs.SetInt("looks", 0);
            createRobot(PlayerPrefs.GetInt("looks"));

            if (!PlayerPrefs.HasKey("background"))
                PlayerPrefs.SetInt("background", 0);
            changeBackground(PlayerPrefs.GetInt("background"));

            if (!PlayerPrefs.HasKey("looks"))
                PlayerPrefs.SetInt("looks", 0);
            createRobot(PlayerPrefs.GetInt("looks"));
        }
        void Update()
        {
            happinessText.GetComponent<TextMeshProUGUI>().text = "" + robot.GetComponent<Robot>().happiness;
            hungerText.GetComponent<TextMeshProUGUI>().text = "" + robot.GetComponent<Robot>().hunger;
            coinText.GetComponent<TextMeshProUGUI>().text = "" + robot.GetComponent<Robot>().coin;
            nameText.GetComponent<TextMeshProUGUI>().text = robot.GetComponent<Robot>().name;

        
        }

        public void triggerNamepanel(bool b)
        { 
            namePanel.SetActive(!namePanel.activeInHierarchy);
    
            if (b)
            {
                robot.GetComponent<Robot> ().name = nameInput.GetComponent<TMP_InputField>().text;
                PlayerPrefs.SetString("name", robot.GetComponent<Robot>().name);
            }
        }

        public void buttonBehavior(int i)
        {
            switch(i) 
            { 
                case 0:
                default:
                    robotPanel.SetActive(!robotPanel.activeInHierarchy);
                    break;
                    case (1):
                    homePanel.SetActive(!homePanel.activeInHierarchy);
                    break;
                    case (2):
                    foodPanel.SetActive(!foodPanel.activeInHierarchy);
                    break; 
                    case (3):
                    questPanel.SetActive(!questPanel.activeInHierarchy);
                    break;
                    case (4):
                    robot.GetComponent<Robot> ().saveRobot ();
                    break;
            }
        }

        public void createRobot(int i)
        {
            if (robot)
            Destroy(robot);
            robot = Instantiate(robotList[i], Vector3.zero, Quaternion.identity) as GameObject;

            toggle(robotPanel);

            PlayerPrefs.SetInt("looks", i);
        }
        public void ChangeTiles(int t)
        {
            for (int i = 0; i < homeTiles.Length; i++)
                homeTiles[1].GetComponent<SpriteRenderer>().sprite = homeTilesSprites [t];

            toggle(homePanel);

            if (homePanel.activeInHierarchy)
                homePanel.SetActive(false);
        }

        public void changeBackground(int i)
        {
            background.GetComponent<SpriteRenderer>().sprite = backgroundOptions[i];
        
            if (homePanel.activeInHierarchy)
                homePanel.SetActive(false);

            toggle(homePanel);

            PlayerPrefs.SetInt("background", i);
        }

        public void selectFood(int i)
        {
            if (homePanel.activeInHierarchy)
                homePanel.SetActive(false);
            toggle(foodPanel);
        }

        public void selectguest(int i)
        {
            if (homePanel.activeInHierarchy)
                homePanel.SetActive(false);
            toggle(questPanel);
        }

        public void asiel(int i)
        {
            if (asielPanel.activeInHierarchy)
                asielPanel.SetActive(false);
            toggle(asielPanel);
        }

        public void toggle(GameObject g)
        {
            if (g.activeInHierarchy)
                g.SetActive(false);
        }
    }
}