
// this script is attached inside "Defender_4" Prefab on "Burst Gun" Gameobject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Burst_Gun : MonoBehaviour
{




    public Weapon Burst_gun = new Weapon();
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
          

            yield return new WaitForSeconds(0.1f);

            while (Burst_gun.bullet_count > 0)
            {
                if (flag == true)
                {
                    Burst_gun.gun_sprite.color = Color.white;
                    flag = false;
                }

                yield return new WaitForSeconds(Burst_gun.shoot_timing);
                StartCoroutine(Start_Shooting_Animation());
            }

            if(flag == false)
            {
                flag = true;
                Burst_gun.gun_sprite.color = new Color(0.8f, 0f, 0f);
            }


            yield return new WaitForSeconds(0.6f);

            Burst_gun.animator.SetBool("start_shooting", false);
        }
    }



    private IEnumerator Start_Shooting_Animation()
    {

        if (Check_Enemy_in_Radar()) {

            Burst_gun.animator.SetBool("start_shooting", true);

            Burst_gun.audio_source.Play();

            for (int i = 1; i <= 4; i++) { 
            
                Instantiate(Burst_gun.bullet_prefab, Burst_gun.gun_point.transform.position, Quaternion.Euler(0, 0, -90f));
                
                yield return new WaitForSeconds(0.05f);

                Burst_gun.bullet_count--;
            }

        }
        else {
            Burst_gun.Stop_Shooting();
        }
    }

   

    private bool Check_Enemy_in_Radar()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, 10f, Burst_gun.layer_mask);
    }
}
