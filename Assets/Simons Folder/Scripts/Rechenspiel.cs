using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class Rechenspiel : MonoBehaviour
{
    Random r;
    string asStr;
    int solution;
    int right;
    int count;
    bool go = false;
    // Start is called before the first frame update
    void Start()
    {
        r = new Random();
        right = 0;
        count = 0;
        StartCoroutine(countDown(3));
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            GameObject.FindGameObjectWithTag("Score").GetComponent<Text>().text = (right.ToString() + " / " + count.ToString());
            if (Input.GetKeyDown("space"))
            {
                count++;
                nextQuestion();
            }
            if (count > 2)
            {
                SceneManager.LoadScene("Leonies Scene");
            }
        }
    }

    void nextQuestion() {
        
        if(int.Parse( this.gameObject.GetComponentInChildren<InputField>().text) == solution)
        {
            right++;
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

    IEnumerator countDown(int t) {
        for(int i = t; i > 0; i--)
        {
            GameObject.FindGameObjectWithTag("Countdown").GetComponent<Text>().text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        GameObject.FindGameObjectWithTag("Countdown").GetComponent<Text>().text = "";
        initQ();
        this.gameObject.GetComponentInChildren<InputField>().Select();
        go = true;
    }
}
