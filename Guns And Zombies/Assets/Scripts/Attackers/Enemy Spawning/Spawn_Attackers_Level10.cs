using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn_Attackers_Level10 : MonoBehaviour
{
    [SerializeField] GameObject Enemy1_Prefab;
    [SerializeField] GameObject Enemy2_Prefab;
    [SerializeField] GameObject Enemy2_Fast_Prefab;
    [SerializeField] GameObject Enemy2_Running_Prefab;
    [SerializeField] GameObject Enemy3_Prefab;

    [SerializeField] GameObject Level_Up_Prefab;
    [SerializeField] Slider slider;

    [SerializeField] AudioSource background_audio;
    [SerializeField] Animation transition_animation;


    [SerializeField] float min;
    [SerializeField] float max;

    private bool flag = true;

    private bool allow_instantiation = true;

    IEnumerator Start()
    {
        Static_Fields.money = 20000;
        StartCoroutine(Manage_Spawning());

        while (true)
        {

            // for safety from infinite loop
            yield return new WaitForSeconds(1f);

            if (slider.value != 1)
            {

                if (allow_instantiation == true)
                {
                    yield return new WaitForSeconds(Random.Range(min, max));
                    Instantiate(Enemy1_Prefab, transform.position, Quaternion.identity);
                }
            }
            else if (FindObjectsOfType<Damage_Zombie>().Length == 0)
            {
                allow_instantiation = false;

                StartCoroutine(Scene_Transition());
                background_audio.Stop();

             
            }
        }
    }

    IEnumerator Scene_Transition()
    {
        yield return new WaitForSeconds(3f);

        transition_animation.Play("scene_transition");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(15);
    }

    IEnumerator Manage_Spawning()
    {

        yield return new WaitForSeconds(30f);
        StartCoroutine(Launch_Zombie2_Wave(0, 30));

        yield return new WaitForSeconds(30f);
        StartCoroutine(Launch_Zombie2_Wave(0, 30));

        // 1min

              yield return new WaitForSeconds(30f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));


              yield return new WaitForSeconds(20f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));


              yield return new WaitForSeconds(10f);
              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));


              //2 min


              yield return new WaitForSeconds(20f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));



              // 3min

              min = 20;
              max = 30;

              yield return new WaitForSeconds(30f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              // 4min

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));



              //5 min

              yield return new WaitForSeconds(20f);
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(10f);    
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie3_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie3_Wave(0, 30));


              // 6min

              min = 10;
              max = 20;

              yield return new WaitForSeconds(20f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Wave(0, 30));


              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Wave(0, 30));

              // 7min


              yield return new WaitForSeconds(30f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));



              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(5f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(2f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(2f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(1f);
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              // 8min

              yield return new WaitForSeconds(30f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));


              // 9min

              yield return new WaitForSeconds(20f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(20f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30)); 

              yield return new WaitForSeconds(10f);
              StartCoroutine(Launch_Zombie2_Wave(0, 30));
              StartCoroutine(Launch_Zombie3_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Fast_Wave(0, 30));
              StartCoroutine(Launch_Zombie2_Running_Wave(0, 30));



    }

    IEnumerator Launch_Zombie2_Wave(int min, int max)
    {
        int a = Random.Range(min, max);
        yield return new WaitForSeconds(a);

        Instantiate(Enemy2_Prefab, transform.position, Quaternion.identity);
    }


    IEnumerator Launch_Zombie2_Fast_Wave(int min, int max)
    {
        int a = Random.Range(min, max);
        yield return new WaitForSeconds(a);

        Instantiate(Enemy2_Fast_Prefab, transform.position, Quaternion.identity);
    }

    IEnumerator Launch_Zombie2_Running_Wave(int min, int max)
    {

        int a = Random.Range(min, max);
        yield return new WaitForSeconds(a);

        Instantiate(Enemy2_Running_Prefab, transform.position, Quaternion.identity);

    }

    IEnumerator Launch_Zombie3_Wave(int min, int max)
    {

        int a = Random.Range(min, max);
        yield return new WaitForSeconds(a);

        Instantiate(Enemy3_Prefab, transform.position, Quaternion.identity);

    }

}
