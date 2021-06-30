using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayMinigame : MonoBehaviour
{
    [SerializeField] BooleanVariable playedMinigame;
    [SerializeField] IntVariable treeLevel;
    [SerializeField] FloatVariable minigameType;
    [SerializeField] UnityEvent GrowTreeEvent;
    [SerializeField] UnityEvent GrowFlowerEvent;
    [SerializeField] string minigameScene = "";

    public void DoMinigame()
    {
        if(playedMinigame.GetValue() == false)
        {
            playedMinigame.SetValue(true);
            treeLevel.SetValue(treeLevel.GetValue() + 1);
            GrowTreeEvent.Invoke();
        }
        else
        {
            minigameType.SetValue(minigameType.GetValue() + 1);
            GrowFlowerEvent.Invoke();
        }

        Debug.Log("Minigame time");
        SceneManager.LoadScene(minigameScene);
    }
}
