using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class Bilderspiel : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject[] buttons;
    int[] arrangement;
    int tries = 0;
    int corrects = 0;
    // Start is called before the first frame update
    bool guessing = false;
    Random r;
    void Start() {
        r = new Random();
        arrangement = new int[12];
        for(int i = 0; i < 12; i++)
        {
            buttons[i].GetComponent<Image>().sprite = sprites[i];
            buttons[i].SetActive(i < 6);
            arrangement[i] = i;
        }
        StartCoroutine(countdown(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator countdown(int cd) {
        Debug.LogError("yes");
        yield return new WaitForSeconds(cd);
        for (int i = 1; i < 12; i++)
        {
            buttons[i].SetActive(true);
        }
        shuffle();
    }

    public void shuffle() {
        for (int i = 0; i < 20; i++)
        {
            int j = r.Next(12);
            int k = r.Next(12);
            int tmp = arrangement[j];
            arrangement[j] = arrangement[k];
            arrangement[k] = tmp;
        }
        for (int i = 0; i < 12; i++)
        {
            buttons[i].GetComponent<Image>().sprite = sprites[arrangement[i]];
        }
    }

    public void buttonPressed(int key) {
        buttons[key].GetComponent<Button>().interactable = false;
        tries++;
        if (arrangement[key] < 6)
        {
            buttons[key].GetComponent<Image>().color = new Color(0, 255, 0, 100);
            corrects++;
        }
        else{
            buttons[key].GetComponent<Image>().color = new Color(255, 0, 0, 100);
        }
        if (corrects == 6)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
