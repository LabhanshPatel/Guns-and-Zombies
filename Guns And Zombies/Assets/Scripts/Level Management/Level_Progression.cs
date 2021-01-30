using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Level_Progression : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float progression_speed;

    [SerializeField] Animator slider_animator;

    [SerializeField] AudioSource background_audio;
    [SerializeField] AudioSource zombie_groan;

    float value = 0;

 

    void Start()
    {        
        StartCoroutine(Wait_For_Getting_Ready());               
    }

    IEnumerator Wait_For_Getting_Ready()
    {
        yield return new WaitForSeconds(15f);
        zombie_groan.Play();
        yield return new WaitForSeconds(5f);

        if(Scene_Loader.current_scene !=13)
           background_audio.Play();

        slider_animator.enabled = true;

        while (true)
        {
            value += progression_speed * Time.deltaTime * 0.001f;
            slider.value = value;

            yield return new WaitForEndOfFrame();
        }
    }
}
