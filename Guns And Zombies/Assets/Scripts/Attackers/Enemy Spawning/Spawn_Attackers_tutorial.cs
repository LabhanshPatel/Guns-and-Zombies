using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Attackers_tutorial : MonoBehaviour
{
    [SerializeField] GameObject Enemy1_Prefab;


    [SerializeField] GameObject Level_Up_Display_Prefab;
    [SerializeField] Slider slider;


    [SerializeField] AudioSource background_audio;

    [SerializeField] float min;
    [SerializeField] float max;

    private bool flag = true;

    private bool allow_instantiation = true;

    IEnumerator Start()
    {
        Time.timeScale = 0;

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

                yield return new WaitForSeconds(3f);
                Level_Up_Display_Prefab.SetActive(true);

                if (this.gameObject.name == "Attacker_Spawner_1" && flag == true)
                {
                    if(Scene_Loader.current_scene !=8)
                       background_audio.Stop();

                    flag = false;
                }

            }
        }
    }

    IEnumerator Manage_Spawning()
    {

            yield return new WaitForSeconds(30f);

            min = 10;
            max = 30;             

    }
}
