using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject can;

    public void Start()
    {
        
        can.SetActive(false);
    }
    public void ButtonPressed()
    {
        if(!can.activeSelf)
        {
            can.SetActive(true);
        }
       else
        {
            can.SetActive(false);
        }
    }
}
