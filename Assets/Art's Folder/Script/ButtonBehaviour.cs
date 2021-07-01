using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject can;
    public GameObject ThingsToDisappear;
    public GameObject ThingsToDisappear2;
    public GameObject DisappearMyself;
    public Component PageSwiper;
 
    public void Start()
    {
        
        can.SetActive(false);
    }
    public void SettingButtonPressed()
    {
        if(!can.activeSelf)
        {
            ThingsToDisappear.SetActive(false);
            ThingsToDisappear2.SetActive(false);
            DisappearMyself.SetActive(false);

            can.SetActive(true);

        }
    }
    public void BackButtonPressed()
    {
            ThingsToDisappear.SetActive(true);
            ThingsToDisappear2.SetActive(true);
            DisappearMyself.SetActive(true);

            can.SetActive(false);
        
    }
}
