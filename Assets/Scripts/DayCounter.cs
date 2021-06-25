using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DayCounter : MonoBehaviour
{

    [SerializeField] GameObject textObject;
    private TextMeshProUGUI textMeshProUGUI;

    [SerializeField] BooleanVariable playedMinigame;
    [SerializeField] FloatVariable brainPower;
    [SerializeField] IntVariable treeLevel;

    private int currentDay = 0;

    private void Start() 
    {
        textMeshProUGUI = textObject.GetComponent<TextMeshProUGUI>();
        Debug.Log(textMeshProUGUI.text);
        playedMinigame.SetValue(false);
    }

    public void NextDay()
    {
        if(currentDay == 6)
        {
            currentDay = 0;
            treeLevel.SetValue(0);
            brainPower.SetValue(0);
            Debug.Log("Reached End of Week");
        } else
        {
            currentDay++;
        }
        switch(currentDay)
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
            Debug.Log("Current Day of the week: " + currentDay);
            playedMinigame.SetValue(false);
    }

    public void DoMinigame()
    {
        Debug.Log("Played a Minigame");
        if(playedMinigame.GetValue() == false)
        {
            Debug.Log("Played first Minigame of the day");
            playedMinigame.SetValue(true);
            treeLevel.SetValue(treeLevel.GetValue() + 1);
        }
        else
        {
            brainPower.SetValue(brainPower.GetValue() + 1);
        }
        SceneManager.LoadScene("Rechenspiel");
    }
}
