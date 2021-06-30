using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class DayCounter : MonoBehaviour
{

    [SerializeField] GameObject textObject;
    private TextMeshProUGUI textMeshProUGUI;

    [SerializeField] BooleanVariable playedMinigame;
    [SerializeField] FloatVariable brainPower;

    [SerializeField] IntVariable currentDay;

    [SerializeField] UnityEvent NewWeekEvent;

    private void Start() 
    {
        textMeshProUGUI = textObject.GetComponent<TextMeshProUGUI>();
        DisplayDay();
    }

    public void NextDay()
    {
        Debug.Log("Initiating next Day");
        if(currentDay.GetValue() >= 6)
        {
            InstantiateNewWeek();
        } else
        {
            currentDay.SetValue(currentDay.GetValue() + 1);
        }
            DisplayDay();
            playedMinigame.SetValue(false);
    }

    private void InstantiateNewWeek()
    {
        currentDay.SetValue(0);
        brainPower.SetValue(0);
        Debug.Log("Reached End of Week");
        NewWeekEvent.Invoke();
    }

    private void DisplayDay()
    {
        switch(currentDay.GetValue())
        {
            case 1:
                textMeshProUGUI.text = "DIENSTAG";
                break;
            case 2:
                textMeshProUGUI.text = "MITTWOCH";
                break;
            case 3:
                textMeshProUGUI.text = "DONNERSTAG";
                break;
            case 4:
                textMeshProUGUI.text = "FREITAG";
                break;
            case 5:
                textMeshProUGUI.text = "SAMSTAG";
                break;
            case 6:
                textMeshProUGUI.text = "SONNTAG";
                break;
            case 0:
                textMeshProUGUI.text = "MONTAG";
                break;
            default:
                Debug.Log("Sth went wrong with the Day Counter");
                break;
        }
            Debug.Log("Current Day: " + textMeshProUGUI.text);
    }
}
