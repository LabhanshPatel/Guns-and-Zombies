using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Text : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] AudioSource background_music;
    private bool stop_scrolling = true;

    void Start()
    {
        StartCoroutine(Start_Text_Scrolling());
        StartCoroutine(Stop_Text_Scrolling());
    }

    void Update()
    {
        if(stop_scrolling == false)
        transform.Translate(Vector2.down*Time.deltaTime*55);
    }

    IEnumerator Start_Text_Scrolling()
    {
        yield return new WaitForSeconds(2f);
        stop_scrolling = false;
        background_music.Play();
    }

    IEnumerator Stop_Text_Scrolling()
    {
        yield return new WaitForSeconds(67f);
        stop_scrolling = true;
        button.SetActive(true);

        
    }
}
