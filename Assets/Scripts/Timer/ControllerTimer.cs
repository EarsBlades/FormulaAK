using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Text timerText;

    [SerializeField] private float timeS;
    [SerializeField] private Text secondomerText;

    [SerializeField] private GameObject GoldText;
    [SerializeField] private GameObject SilverText;
    [SerializeField] private GameObject BronzeText;

    [SerializeField] private float GoldTime;
    [SerializeField] private float SerebroTime;

    [SerializeField] private Text _timeComplete;

    [SerializeField] private GameObject GoldTextMenu;
    [SerializeField] private GameObject SilverTextMenu;
    [SerializeField] private GameObject BronzeTextMenu;

    private float _timeLeft = 0f;
    private bool _timerOn = false;
    private bool _secondomerOn = false;

    public LevelController lv;

    private void Start()
    {
        _timeLeft = time;
        _timerOn = true;

        GameObject temp = GameObject.Find("DefaultCar");
        DriverCar other = temp.GetComponent<DriverCar>();
        other.enabled = false;

        secondomerText.text = timeS.ToString();

        GoldText.gameObject.SetActive(false);
        SilverText.gameObject.SetActive(false);
        BronzeText.gameObject.SetActive(false);

        GoldTextMenu.gameObject.SetActive(false);
        SilverTextMenu.gameObject.SetActive(false);
        BronzeTextMenu.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (_timerOn == true)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
                secondomerText.enabled = false;
            }
            else
            {
                _timeLeft = time;
                _timerOn = false;
                Destroy(timerText);
                GameObject temp = GameObject.Find("DefaultCar");
                DriverCar other = temp.GetComponent<DriverCar>();
                other.enabled = true;
                _secondomerOn = true;
            }
        }
        else
        {
            if (_secondomerOn == true)
            {
                timeS += Time.deltaTime;
                UpdateSecText();
                secondomerText.enabled = true;
            }
            
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
        {
            _timeLeft = 0;
        }
        timerText.text = Mathf.Round(_timeLeft).ToString();
    }

    private void UpdateSecText()
    {
        float minutes = Mathf.FloorToInt(timeS / 60);
        float seconds = Mathf.FloorToInt(timeS % 60);
        secondomerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        _timeComplete.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        if (timeS <= GoldTime)
        {
            GoldText.gameObject.SetActive(true);

            GoldTextMenu.gameObject.SetActive(true);
        }

        if (timeS > GoldTime + 0.2 && timeS <= SerebroTime)
        {
            GoldText.gameObject.SetActive(false);
            SilverText.gameObject.SetActive(true);

            GoldTextMenu.gameObject.SetActive(false);
            SilverTextMenu.gameObject.SetActive(true);
        }

        if (timeS > SerebroTime + 0.2)
        {
            GoldText.gameObject.SetActive(false);
            SilverText.gameObject.SetActive(false);
            BronzeText.gameObject.SetActive(true);

            GoldTextMenu.gameObject.SetActive(false);
            SilverTextMenu.gameObject.SetActive(false);
            BronzeTextMenu.gameObject.SetActive(true);
        }
    }

    public void OnTriggerEnter()
    {
        LevelController.instance.isEndGame();
        _secondomerOn = false;
    }
}
