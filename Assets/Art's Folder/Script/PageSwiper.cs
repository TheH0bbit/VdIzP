using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int totalPages = 1;
    private int currentPage = 2;
    public GameObject ThingsToDisappear;
    public AudioSource audi;
    

    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }
    void Update()
    {
        if (currentPage != 2)
        {
            ThingsToDisappear.SetActive(false);
        }
        else
        {
            ThingsToDisappear.SetActive(true);
        }
    }
    public void OnDrag(PointerEventData data)
    {
       
        
        float difference = (data.pressPosition.x - data.position.x) / 20;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
        audi.Play();
       
    }

    public void OnEndDrag(PointerEventData data)
    {
       
        float percentage = (data.pressPosition.x - data.position.x) / 70;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentPage < totalPages)
            {
                currentPage++;
                newLocation += new Vector3(-70, 0, 0);
            }
            else if (percentage < 0 && currentPage > 1)
            {
                currentPage--;
                newLocation += new Vector3(70, 0, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }
    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}

