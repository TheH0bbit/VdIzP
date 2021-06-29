using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayMinigame : MonoBehaviour
{
    [SerializeField] BooleanVariable playedMinigame;
    [SerializeField] IntVariable treeLevel;
    [SerializeField] FloatVariable brainPower;
    [SerializeField] UnityEvent GrowTreeEvent;

    private void Start() {
        brainPower.SetValue(0);
    }


    public void DoMinigame()
    {
        //Debug.Log("Played a Minigame");
        if(playedMinigame.GetValue() == false)
        {
           // Debug.Log("Played first Minigame of the day");
            playedMinigame.SetValue(true);
            treeLevel.SetValue(treeLevel.GetValue() + 1);
            GrowTreeEvent.Invoke();
        }
        brainPower.SetValue(brainPower.GetValue() + 1);
    }
}
