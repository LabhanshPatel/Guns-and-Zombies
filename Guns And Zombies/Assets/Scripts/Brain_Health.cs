using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_Health : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float health_loss_rate;
    [SerializeField] int current_brain_index;
  
    [SerializeField] LayerMask enemy_layer;
    [SerializeField] AudioSource brain_eat_audio;
    [SerializeField] AudioSource game_over_audio;
    [SerializeField] AudioSource background_music;
    [SerializeField] GameObject game_over;
    
    private bool flag_1 = false;
    private bool flag_2 = true;


    void Update()
    {

        if(Physics2D.Raycast(transform.position, Vector2.right, 0.6f, enemy_layer))
        {

            if(flag_1 == false)
               brain_eat_audio.enabled = true;

            health -= health_loss_rate * Time.deltaTime;

            if (health <= 0)
            {
                if (flag_2 == true)
                {
                    Static_Fields.stop_adding_money = true;
                    flag_2 = false;

                    background_music.Stop();
                    game_over.SetActive(true);
                    StartCoroutine(Wait_For_Transition());
                }
            }

            flag_1 = true;
        }
        else if(flag_1 == true)
        {
            brain_eat_audio.enabled = false; 
            flag_1 = false;
        }
          
    }

    IEnumerator Wait_For_Transition()
    {
        yield return new WaitForSeconds(2f);
       
        GameObject.Find("Brains").transform.Find("Brain (2)").GetComponent<AudioSource>().enabled = false;
        Time.timeScale = 0;

    }
}
