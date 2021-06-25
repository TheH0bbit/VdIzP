using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public FloatVariable fillAmount;
    public Image fillbar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateBar(fillAmount.GetValue());
    }

    void updateBar(float fillAmount)
    {
        fillbar.fillAmount = fillAmount;
    }
}
