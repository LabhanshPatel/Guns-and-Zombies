
// this script is attached inside "Defender_3" Prefab on "Shot Gun" Gameobject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Shot_Gun : MonoBehaviour
{
      
    public Weapon Shot_gun = new Weapon();

    [SerializeField] AudioSource reload_shot_gun;

    private bool flag = true;


    void Start()
    {
        StartCoroutine(shoot());
    }

    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            while (Shot_gun.bullet_count > 0)
            {
                if (flag == true)
                {
                    Shot_gun.gun_sprite.color = Color.white;
                    flag = false;
                }

                yield return new WaitForSeconds(Shot_gun.shoot_timing); // 2f

                if (Check_Enemy_in_Radar())
                {
                    reload_shot_gun.Play();

                    yield return new WaitForSeconds(0.3f);

                    Shot_gun.animator.SetBool("start_shooting", true);

                    yield return new WaitForSeconds(0.5f); 
                    Instantiate(Shot_gun.bullet_prefab, transform.position + new Vector3(0.5f, 0, 5f), Quaternion.Euler(0, 0, -90f));
                    GameObject b = Instantiate(Shot_gun.gun_point, transform.position + new Vector3(1f, 0, -2f), Quaternion.identity) as GameObject;

                    Shot_gun.audio_source.Play();

                    yield return new WaitForSeconds(0.05f);
                    Destroy(b);
                    yield return new WaitForSeconds(0.5f);


                    Shot_gun.Stop_Shooting();

                    Shot_gun.bullet_count--;
                }
            }

            if(flag == false)
            {
                Shot_gun.gun_sprite.color = new Color(0.9811321f, 0.3913437f, 0.1157837f);
                flag = true;
            }
        }
    }


    private bool Check_Enemy_in_Radar()
    {
        return Physics2D.Raycast(transform.position, Vector2.right, 3f, Shot_gun.layer_mask);
    }


}
