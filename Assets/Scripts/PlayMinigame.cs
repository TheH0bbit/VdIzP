using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayMinigame : MonoBehaviour
{
    [SerializeField] BooleanVariable playedMinigame;
    [SerializeField] IntVariable treeLevel;
    [SerializeField] FloatVariable brainPower;
    [SerializeField] UnityEvent GrowTreeEvent;
    [SerializeField] UnityEvent GrowFlowerEvent;

    private void Start() {

    }


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
            brainPower.SetValue(brainPower.GetValue() + 1);
            GrowFlowerEvent.Invoke();
        }

        Debug.Log("Minigame time");
        SceneManager.LoadScene("Rechenspiel");
    }
}
