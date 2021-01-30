
// this script is attached inside "Defender_2" Prefab on "Assault Rifle" Gameobject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assault_Rifle : MonoBehaviour
{
   
    public Weapon Assault_rifle = new Weapon();
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

            while (Assault_rifle.bullet_count > 0)
            {
                if (flag == true)
                {
                    Assault_rifle.gun_sprite.color = Color.white;
                    flag = false;
                }

                yield return new WaitForSeconds(Assault_rifle.shoot_timing);  // 0.665f

                if (Check_Enemy_in_Radar())
                    Start_Shooting();
                else
                    Assault_rifle.Stop_Shooting();

                Assault_rifle.flag_stop_shooting = true;
            }

            if (Assault_rifle.flag_stop_shooting)
            {
                Assault_rifle.gun_sprite.color = new Color(0.8f, 0f, 0f);
                flag = true;


                Assault_rifle.Stop_Shooting();
                Assault_rifle.flag_stop_shooting = false;
            }
        }
    }

    private void Start_Shooting()
    {
        Assault_rifle.animator.SetBool("start_shooting", true);

        Instantiate(Assault_rifle.bullet_prefab, Assault_rifle.gun_point.transform.position, Quaternion.Euler(0, 0, -90f));
        Assault_rifle.bullet_count--;

        Assault_rifle.audio_source.Play();
    }

 
    private bool Check_Enemy_in_Radar()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, 10f, Assault_rifle.layer_mask);
    }

   
}
