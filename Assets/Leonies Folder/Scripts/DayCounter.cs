using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    [SerializeField] Button nextDayButton;
    [SerializeField] Button playMinigameButton;

    [SerializeField] BooleanVariable playedMinigame;
    [SerializeField] IntVariable treeLevel;

    private void Start() 
    {
        playedMinigame.SetValue(false);
        nextDayButton.onClick.AddListener(NextDay);
        playMinigameButton.onClick.AddListener(DoMinigame);
    }

    private void NextDay()
    {
        if(playedMinigame.GetValue() == false)
        {
            Debug.Log("Reached Treelevel " + treeLevel.GetValue() + ". Resetting Tree to 0 since you failed to do a Minigame today.");
            treeLevel.SetValue(0);
        }
        else
        {
            playedMinigame.SetValue(false);
        }
    }

    private void DoMinigame()
    {
        Debug.Log("Played a Minigame");
        if(playedMinigame.GetValue() == false)
        {
            playedMinigame.SetValue(true);
            treeLevel.SetValue(treeLevel.GetValue() + 1);
        }
    }
}
