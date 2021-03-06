﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawn_Attacker_Level3 : MonoBehaviour
{
    [SerializeField] GameObject Enemy1_Prefab;
    [SerializeField] GameObject Enemy2_Prefab;
    [SerializeField] GameObject Enemy3_Prefab;

    [SerializeField] GameObject Level_Up_Prefab;
    [SerializeField] Slider slider;

    [SerializeField] AudioSource background_audio;

    [SerializeField] float min;
    [SerializeField] float max;

    private bool flag = true;

    private bool allow_instantiation = true;


    IEnumerator Start() {

        StartCoroutine(Manage_Spawning());

        while (true) {

            // for safety from infinite loop
            yield return new WaitForSeconds(1f);

            if (slider.value != 1) {
                if (allow_instantiation == true)
                {
                    yield return new WaitForSeconds(Random.Range(min, max));
                    Instantiate(Enemy1_Prefab, transform.position, Quaternion.identity);
                }
            }
            else if (FindObjectsOfType<Damage_Zombie>().Length == 0)
            {
                allow_instantiation = false;

                yield return new WaitForSeconds(3f);
                Level_Up_Prefab.SetActive(true);

                if (this.gameObject.name == "Attacker_Spawner_1" && flag == true)
                {
                    background_audio.Stop();
                    flag = false;
                }
            }
        }
    }
   
    IEnumerator Manage_Spawning()
    {
         
        yield return new WaitForSeconds(40f);
        StartCoroutine(Launch_Zombie2_Wave(5, 30));

        yield return new WaitForSeconds(20f);
        StartCoroutine(Launch_Zombie2_Wave(5, 30));

        // 1 min  completed

        yield return new WaitForSeconds(20f);
        StartCoroutine(Launch_Zombie2_Wave(0, 30));

        yield return new WaitForSeconds(20f);
        StartCoroutine(Launch_Zombie2_Wave(0, 30));

        yield return new WaitForSeconds(20f);
        StartCoroutine(Launch_Zombie2_Wave(0, 30));

        // 2 min

        min = 10;
        max = 30;


        yield return new WaitForSeconds(20f);   // intro of Zombie3
        StartCoroutine(Launch_Zombie3_Wave(0, 30));


        yield return new WaitForSeconds(40f);
        StartCoroutine(Launch_Zombie2_Wave(0, 30));

        // 3 min

        yield return new WaitForSeconds(20f);
        StartCoroutine(Launch_Zombie3_Wave(0, 30));


        yield return new WaitForSeconds(30f);
        StartCoroutine(Launch_Zombie2_Wave(0, 30));

        yield return new WaitForSeconds(10f);
        StartCoroutine(Launch_Zombie2_Wave(0, 30));

        // 4 min

        yield return new WaitForSeconds(10f);
        StartCoroutine(Launch_Zombie2_Wave(0, 30));

        yield return new WaitForSeconds(20f);
        StartCoroutine(Launch_Zombie3_Wave(0, 30));
    

        yield return new WaitForSeconds(15f);
        StartCoroutine(Launch_Zombie3_Wave(0, 30));

        yield return new WaitForSeconds(15f);
        StartCoroutine(Launch_Zombie3_Wave(0, 30));

    }

    IEnumerator Launch_Zombie2_Wave(int min, int max)
    {
        
       int a = Random.Range(min, max);          
       yield return new WaitForSeconds(a);
           
       Instantiate(Enemy2_Prefab, transform.position, Quaternion.identity);
        
    }

    IEnumerator Launch_Zombie3_Wave(int min, int max)
    {

        int a = Random.Range(min, max);
        yield return new WaitForSeconds(a);

        Instantiate(Enemy3_Prefab, transform.position, Quaternion.identity);

    }

}
