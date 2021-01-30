
// this script is attached inside "Defender_1" Prefab on "Hand Gun" Gameobject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Gun : MonoBehaviour
{
  

    public Weapon Hand_gun = new Weapon();

    private bool flag = true;

    void Start()
    {
        StartCoroutine(shoot());
    }

    IEnumerator shoot()
    {

        // waiting for 1sec before starting animation
        yield return new WaitForSeconds(1f);

        while (true)
        {

            // for not running into infinite loop
            yield return new WaitForSeconds(0.1f);

            while (Hand_gun.bullet_count > 0)
            {
                if (flag == true) {                 
                    Hand_gun.gun_sprite.color = Color.white;
                    flag = false;
                }

                yield return new WaitForSeconds(Hand_gun.shoot_timing);// 1.5f

                if (Check_Enemy_in_Radar())
                {
                    Start_Shooting();
                }
                else
                    Hand_gun.Stop_Shooting();

                Hand_gun.flag_stop_shooting = true;
            }



            if (Hand_gun.flag_stop_shooting == true)
            {
                Hand_gun.gun_sprite.color = new Color(0.8f, 0f, 0f);
                flag = true;

                Hand_gun.Stop_Shooting();
                Hand_gun.flag_stop_shooting = false;
            }
        }
    }

    private void Start_Shooting()
    {

        Hand_gun.animator.SetBool("start_shooting", true);

        Instantiate(Hand_gun.bullet_prefab, Hand_gun.gun_point.transform.position, Quaternion.Euler(0, 0, -90f));
        Hand_gun.bullet_count--;

        Hand_gun.audio_source.Play();


    }



    private bool Check_Enemy_in_Radar()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, 5f, Hand_gun.layer_mask);
    }

}
