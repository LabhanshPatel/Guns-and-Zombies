using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Zombie : MonoBehaviour
{
    [SerializeField] GameObject coin1_prefab;
    [SerializeField] GameObject coin2_prefab;
    [SerializeField] GameObject coin3_prefab;
    [SerializeField] GameObject coin4_prefab;



    [SerializeField] GameObject blood_effect;
    [SerializeField] SpriteRenderer sprite_renderer;
    [SerializeField] Animator change_anim;
    [SerializeField] CapsuleCollider2D enemy_collider;
    [SerializeField] Enemy_Movement_Zombie enemy_movement_zombie;
    [SerializeField] int health;

    [HideInInspector] public bool death_is_playing = false;

    
    private bool flag = true;
    private bool check_for_Zombie2 = false;
    private bool check_for_Zombie2_Fast = false;
    private bool check_for_Zombie2_Running = false;


    private bool check_for_Zombie3 = false;

    private bool[] this_Zombie = {false,false,false,false,false};
    private float Zombie_Drag_Amount = 0;


    void Start()
    {
        Find_Current_Zombie();

        Calculat_Zombie_Drag_Amount();
    }

   

    private void Update() {

       

        if ( health <= 0 ) {

            if (flag == true)
            {
                if (check_for_Zombie2 == true)               
                        Instantiate(coin2_prefab, transform.position + new Vector3(0f, -0.3f, 0f), Quaternion.identity);               
                else if (check_for_Zombie2_Fast == true)
                        Instantiate(coin3_prefab, transform.position + new Vector3(0f, -0.3f, 0f), Quaternion.identity);
                else if(check_for_Zombie2_Running == true)
                        Instantiate(coin4_prefab, transform.position + new Vector3(0f, -0.3f, 0f), Quaternion.identity);
                else if (check_for_Zombie3 == true)
                        StartCoroutine(Zombie3_coins_animation());
                else
                        Instantiate(coin1_prefab, transform.position + new Vector3(0f, -0.3f, 0f), Quaternion.identity);

                flag = false;
            }
            StartCoroutine(Play_Death_Anim());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Bullet Hand Gun") {             
            Take_Damage(Static_Fields.HG_bullet_damage);

            StartCoroutine(Damage_Animation());
         
            Instantiate(blood_effect, new Vector3(transform.position.x -0.5f, transform.position.y - 0.5f, -1), Quaternion.identity);

        }
        else if (collision.tag == "Bullet Assault Rifle") { 
        
            Take_Damage(Static_Fields.AR_bullet_damage); 

            StartCoroutine(Damage_Animation());
            Instantiate(blood_effect, new Vector3(transform.position.x -0.5f, transform.position.y - 0.2f, -1), Quaternion.identity);           
        }
        else if (collision.tag == "Bullet Shot Gun") { 
        
            Take_Damage(Static_Fields.SG_bullet_damage);

            StartCoroutine(Damage_Animation());
            Instantiate(blood_effect, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.5f, -1), Quaternion.identity);

            // push enemy backward
            if (check_for_Zombie3 == false)
            {
                StartCoroutine(Push_Zombie_Backward());
              /*  enemy_movement_zombie.Zombie_parant_pos.transform.position = new Vector3(enemy_movement_zombie.Zombie_parant_pos.transform.position.x
                    + 0.5f, enemy_movement_zombie.Zombie_parant_pos.transform.position.y, -1); */
            }
            else
                transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, -1);
                 
        }
        else if (collision.tag == "Bullet Burst Gun") { 
            Take_Damage(Static_Fields.BG_bullet_damage);

            StartCoroutine(Damage_Animation());
            Instantiate(blood_effect, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.2f, -1), Quaternion.identity);

            // push enemy backward
            for (int i = 0; i < 4; i++)
            {
                if (this_Zombie[i] == true)
                {
                    if(check_for_Zombie3 == false)
                    enemy_movement_zombie.Zombie_parant_pos.transform.position = new Vector3(enemy_movement_zombie.Zombie_parant_pos.transform.position.x
                        + Zombie_Drag_Amount, enemy_movement_zombie.Zombie_parant_pos.transform.position.y, -1);
                    else
                        transform.position = new Vector3(transform.position.x
                        + Zombie_Drag_Amount, transform.position.y, -1);
                }
            }
        }
        else if (collision.tag == "Bullet Sniper Rifle") { 
            Take_Damage(Static_Fields.SR_bullet_damage);

            StartCoroutine(Damage_Animation());
            Instantiate(blood_effect, new Vector3(transform.position.x -0.5f, transform.position.y - 0.5f, -1), Quaternion.identity);
        }
        
    }


    private void Take_Damage(int damage) {    
        health -= damage;
    }

    IEnumerator Play_Death_Anim()
    {
        death_is_playing = true;
        change_anim.SetBool("is_dead", true);
        enemy_collider.enabled = false;
        yield return new WaitForSeconds(2f);

        Destroy(this.gameObject);
    }

    IEnumerator Zombie3_coins_animation()
    {
        for (int i = 0; i < 3; i++) {        
            Instantiate(coin1_prefab, transform.position + new Vector3(0f, -0.3f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator Damage_Animation()
    {
        if(check_for_Zombie2_Fast == true)
            sprite_renderer.color = new Color(0.5566038f, 0.1024418f, 0.1024418f);
        else
           sprite_renderer.color = new Color(1, 0.5f, 0.5f);

        yield return new WaitForSeconds(0.2f);

        if (check_for_Zombie2_Fast == false)       
            sprite_renderer.color = Color.white;       
        else
            sprite_renderer.color = new Color(0.381041f, 0.3749507f, 0.9811321f);


    }


    IEnumerator Push_Zombie_Backward()
    {
  
        float time = 0;
        while (time < 0.12f) {
            time += Time.deltaTime;
            enemy_movement_zombie.Zombie_parant_pos.transform.Translate(new Vector2(0.1f,0));
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private void Find_Current_Zombie()
    {
        if (this.gameObject.name == "Zombie_2_anim")
            check_for_Zombie2 = true;
        else if (this.gameObject.name == "Zombie_2_Fast_anim")
            check_for_Zombie2_Fast = true;
        else if (this.gameObject.name == "Zombie_2_Running_anim")
            check_for_Zombie2_Running = true;
        else if (this.gameObject.name == "Zombie_3(Clone)")
            check_for_Zombie3 = true;
    }


    private void Calculat_Zombie_Drag_Amount()
    {
      
        if (check_for_Zombie2 == true)
        {
            this_Zombie[1] = true;
            Zombie_Drag_Amount = 0.02f;
        }
        else if (check_for_Zombie2_Fast == true)
        {
            this_Zombie[2] = true;
            Zombie_Drag_Amount = 0.04f;
        }
        else if (check_for_Zombie2_Running == true)
        {
            this_Zombie[4] = true;
            Zombie_Drag_Amount = 0.04f;
        } 
        else if (check_for_Zombie3 == true)
        {
            this_Zombie[3] = true;
            Zombie_Drag_Amount = 0.2f;
        }
        else
        {
            this_Zombie[0] = true;
            Zombie_Drag_Amount = 0.05f;
        }
    } 

}
