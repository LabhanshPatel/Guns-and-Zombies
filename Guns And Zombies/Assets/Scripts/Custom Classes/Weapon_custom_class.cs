using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public GameObject bullet_prefab;
    public GameObject gun_point;
    public Animator animator;
    public SpriteRenderer gun_sprite;
    public AudioSource audio_source;
   
    public LayerMask layer_mask;

    public int bullet_count;
    public float shoot_timing;
    public bool flag_stop_shooting = false;


    public void Add_Bullets(int amount) {    
        bullet_count += amount;
    }
    public void Stop_Shooting() {    
       animator.SetBool("start_shooting", false);
    }
}
