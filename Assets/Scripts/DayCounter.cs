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
    [SerializeField] FloatVariable rechenPower;

    [SerializeField] IntVariable currentDay;
    [SerializeField] IntVariable gardenTreeID;

    [SerializeField] TreeController treeController;

    [SerializeField] UnityEvent NewWeekEvent;

    private void Start() 
    {
        textMeshProUGUI = textObject.GetComponent<TextMeshProUGUI>();
        DisplayDay();
    }

    public void NextDay()
    {
        
        if(currentDay.GetValue() >= 6)
        {
            InstantiateNewWeek();
        } else
        {
            currentDay.SetValue(currentDay.GetValue() + 1);
        }
        DisplayDay();
        playedMinigame.SetValue(false);
        Debug.Log("Initiating next day: " + textMeshProUGUI.text);
    }

    private void InstantiateNewWeek()
    {
        treeController.SetTreeValues(brainPower.GetValue(), rechenPower.GetValue(), gardenTreeID.GetValue()%6);
        gardenTreeID.SetValue((gardenTreeID.GetValue()+1)%6);
        currentDay.SetValue(0);
        brainPower.SetValue(0);
        rechenPower.SetValue(0);
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
    }
}
