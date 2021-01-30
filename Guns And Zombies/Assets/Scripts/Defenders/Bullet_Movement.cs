using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb_bullet;
    [SerializeField] float bullet_speed_hand_gun = 5f;
    [SerializeField] float bullet_speed_assault_rifle = 5f;
    [SerializeField] float bullet_speed_shot_gun = 5f;
    [SerializeField] float bullet_speed_burst_gun = 5f;
    [SerializeField] float bullet_speed_sniper_rifle = 5f;


  
    private void Start()
    {
        if (gameObject.tag == "Bullet Hand Gun")
            rb_bullet.velocity = Vector2.right * bullet_speed_hand_gun;
        else if (gameObject.tag == "Bullet Assault Rifle")
            rb_bullet.velocity = Vector2.right * bullet_speed_assault_rifle;
        else if (gameObject.tag == "Bullet Shot Gun")
            rb_bullet.velocity = Vector2.right * bullet_speed_shot_gun;
        else if (gameObject.tag == "Bullet Burst Gun")
            rb_bullet.velocity = Vector2.right * bullet_speed_burst_gun;
        else if (gameObject.tag == "Bullet Sniper Rifle")
            rb_bullet.velocity = Vector2.right * bullet_speed_sniper_rifle;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
            Destroy(gameObject);      
        else if(collision.gameObject.name == "Right_Collider")
            Destroy(gameObject);

    }
}
