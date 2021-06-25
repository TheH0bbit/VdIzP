using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Rechenspiel : MonoBehaviour
{
    Random r;
    string asStr;
    int solution;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        r = new Random();
        count = 0;
        initQ();
        this.gameObject.GetComponentInChildren<InputField>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = count.ToString();
        if (Input.GetKeyDown("space"))
        {
            nextQuestion();
        }

    }

    void nextQuestion() {
        
        if(int.Parse( this.gameObject.GetComponentInChildren<InputField>().text) == solution)
        {
            count++;
        }
        initQ();
        this.gameObject.GetComponentInChildren<InputField>().text = "";
    }

    void initQ() {
        int a = r.Next(10);
        int b = r.Next(10);
        switch (r.Next(3))
        {
            case 0:
                solution = a + b;
                asStr = a + " + " + b;
                break;
            case 1:
                solution = a - b;
                asStr = a + " - " + b;
                break;
            case 2:
                solution = a * b;
                asStr = a + " * " + b;
                break;
        }
        GameObject.FindGameObjectWithTag("Problem").GetComponent<Text>().text = asStr;
    }
}
