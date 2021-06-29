using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMinigame : MonoBehaviour
{
    [SerializeField] BooleanVariable playedMinigame;
    [SerializeField] IntVariable treeLevel;
    [SerializeField] FloatVariable brainPower;

    private void Start() {
        brainPower.SetValue(0);
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
        brainPower.SetValue(brainPower.GetValue() + 1);
    }
}
