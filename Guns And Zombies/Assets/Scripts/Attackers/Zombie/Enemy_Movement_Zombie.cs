using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement_Zombie : MonoBehaviour
{   
    [Range(0,1)]
    [SerializeField] float move_speed;

    public Transform Zombie_parant_pos;

    [SerializeField] LayerMask brain_layer;
    [SerializeField] LayerMask weapon_layer;

    [SerializeField] Animator change_animation;
    [SerializeField] Transform enemy_pos;
    [SerializeField] Damage_Zombie damage_zombie_1_script;

    [SerializeField] AudioSource Zombie_voice;


    // "flag_for_eat" is public because Damage_Zombie wants its reference for damaging brain if a zombie is died but another is still eating it
    [HideInInspector] public bool flag_for_eat = true;

    private bool flag_for_jump = true;
    private bool start_eating = true;

    // we dont want to play jump animation if eating animation is playing
    private bool can_jump = true;

    private bool start_jumping = false;

    private bool check_for_Zombie2 = false;
    private bool check_for_Zombie2_Fast = false;

    private bool check_for_Zombie3 = false;

    private static int voice_count_zombie2 = 0;
    private static int voice_count_zombie2_fast = 0;
    private static int voice_count_zombie3 = 0;

    void Start()
    {
       // Zombie_parant = GameObject.Find
        Assign_Order_of_Layer_to_Enemy();

        if (this.gameObject.name == "Zombie_2_anim")
        {

            check_for_Zombie2 = true;
            StartCoroutine(Zombie2_Voice());
        }
        else if(this.gameObject.name == "Zombie_2_Fast_anim")
        {

            check_for_Zombie2_Fast = true;
            StartCoroutine(Zombie2_Voice());

        }
        else if (this.gameObject.name == "Zombie_3(Clone)")
        {
            check_for_Zombie3 = true;
            StartCoroutine(Zombie3_Voice());
        }
      
       
    }


    void Update()
    {
        if(check_for_Zombie3 == false)
            Zombie_parant_pos.transform.Translate(new Vector2(1,0) * (-1)*move_speed * Time.deltaTime);
        else
            transform.Translate(new Vector2(1, 0) * (-1) * move_speed * Time.deltaTime);


        if (can_jump == true) {
            start_jumping = Physics2D.Raycast(transform.position - new Vector3(0,0.5f), Vector2.left, 0.01f, weapon_layer);
           
            if (start_jumping == true && flag_for_jump == true)
            {
                flag_for_jump = false;

                if (damage_zombie_1_script.death_is_playing == false)
                    StartCoroutine(Start_Jumping());
            }

        }

        if (check_for_Zombie3)
        {
            start_eating = Physics2D.Raycast(transform.position, Vector2.left, 0.1f, brain_layer);
        }
        else if(check_for_Zombie2 || check_for_Zombie2_Fast)
            start_eating = Physics2D.Raycast(Zombie_parant_pos.transform.position + new Vector3(0, 0, 0), Vector2.left, 0.05f, brain_layer);
        else
            start_eating = Physics2D.Raycast(Zombie_parant_pos.transform.position + new Vector3(0.1f,0,0), Vector2.left, 0.05f, brain_layer);


        if (start_eating == true && flag_for_eat == true)
        {
            can_jump = false;

            change_animation.SetBool("is_eating", true);
            move_speed = 0f;

            flag_for_eat = false;
        }

    }

 

    IEnumerator Start_Jumping()
    {
        float current_speed = move_speed;
        change_animation.SetBool("is_jumping", true);
        
        move_speed = 0f;

        if (check_for_Zombie3 == true)
        { 
            yield return new WaitForSeconds(0.33f);
            move_speed = 1.2f;
            transform.position += new Vector3(0,0.5f,0);
            yield return new WaitForSeconds(0.25f);
            transform.position += new Vector3(0, 0.5f, 0);
            yield return new WaitForSeconds(0.25f);
            transform.position += new Vector3(0, -0.5f, 0);
            yield return new WaitForSeconds(0.25f);
            transform.position += new Vector3(0, -0.5f, 0);

            yield return new WaitForSeconds(0.25f);
        }
        else
        {
            yield return new WaitForSeconds(0.6f); 
            move_speed = 1.2f;
            yield return new WaitForSeconds(1f);     
        }

        move_speed = 0f;

        if (check_for_Zombie3 == false)
        {
            if (check_for_Zombie2 == true || check_for_Zombie2_Fast == true)
                yield return new WaitForSeconds(2.2f);
            else          
                yield return new WaitForSeconds(5.4f);
            
        }

        change_animation.SetBool("is_jumping", false);

        if(can_jump == true)
          move_speed = current_speed;

        flag_for_jump = true;

    }


    IEnumerator Zombie2_Voice()
    {
        if (voice_count_zombie2 < 10)
        {
            voice_count_zombie2++;
            yield return new WaitForSeconds(5f);
            Zombie_voice.Play();
        }
    }


    IEnumerator Zombie3_Voice()
    {

        if (voice_count_zombie3 < 5)
        {
            Zombie_voice.Play();
            yield return new WaitForSeconds(2f);
            voice_count_zombie3++;
        }
        
    }

    private void Assign_Order_of_Layer_to_Enemy()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (this.transform.position.y > 5-i && this.transform.position.y < 6-i)
            {
                GetComponent<SpriteRenderer>().sortingOrder = i;
                break;
            }
        }       
    }

}
