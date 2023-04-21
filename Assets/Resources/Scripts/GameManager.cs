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


        public bool mIsAppLeft;
        

        public GameObject foodPanel;
        public Sprite[] foodIcons;

        public GameObject questPanel;
        public GameObject asielPanel;

        private void Start()
        {
 
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

        public void OnApplicationFocus(bool hasFocus)
        {
            mIsAppLeft = !hasFocus;
        }

        private void OnAplicationPause(bool PauseStatus)
        {
           mIsAppLeft = PauseStatus;
        }

       public void Mail()
        {
            StartCoroutine(OpenMail());
       }

        IEnumerator OpenMail()
        {
            Application.OpenURL("outlook");

        }

    }
}