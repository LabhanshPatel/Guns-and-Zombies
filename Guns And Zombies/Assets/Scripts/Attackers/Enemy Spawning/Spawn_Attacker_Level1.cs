// Current total time of level progression = 3 min

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawn_Attacker_Level1 : MonoBehaviour
{
    [SerializeField] GameObject Enemy1_Prefab;
    

    [SerializeField] GameObject Level_Up_Display_Prefab;
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
                Level_Up_Display_Prefab.SetActive(true);

                if (this.gameObject.name == "Attacker_Spawner_1" && flag == true) {                              
                    background_audio.Stop();
                    flag = false;
                }

            }
        }
    }
   
    IEnumerator Manage_Spawning()
    {       
         yield return new WaitForSeconds(60f);

         min = 10;
         max = 20;

         yield return new WaitForSeconds(60f);
      
         min = 0;
         max = 15;            
    }

}
