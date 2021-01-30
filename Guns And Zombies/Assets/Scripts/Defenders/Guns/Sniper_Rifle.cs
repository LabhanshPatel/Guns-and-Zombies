
// this script is attached inside "Defender_5" Prefab on "Sniper Rifle" Gameobject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_Rifle : MonoBehaviour
{
   

    public Weapon Sniper_rifle = new Weapon();
    private bool flag = true;

    void Start() {   
        StartCoroutine(shoot());
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(2f);
        while (true) { 
        
            yield return new WaitForSeconds(0.1f);

            while (Sniper_rifle.bullet_count > 0) {

                if (flag == true)
                {
                    Sniper_rifle.gun_sprite.color = Color.white;
                    flag = false;
                }

                yield return new WaitForSeconds(Sniper_rifle.shoot_timing);  //1f            
                if (Check_Enemy_in_Radar()) { 
                                 
                    
                    Sniper_rifle.animator.SetBool("start_shooting", true);
                    yield return new WaitForSeconds(2.8f);
                    Sniper_rifle.audio_source.Play();

                    yield return new WaitForSeconds(1.7f);                   
                    Instantiate(Sniper_rifle.bullet_prefab, transform.position + new Vector3(1f, 0, 5f), Quaternion.Euler(0, 0, -90f));
                    GameObject a = Instantiate(Sniper_rifle.gun_point, transform.position + new Vector3(1.8f, 0.05f, -2f), Quaternion.identity) as GameObject;
                    yield return new WaitForSeconds(0.05f);
                    Destroy(a);
                    yield return new WaitForSeconds(2f);
                    Sniper_rifle.Stop_Shooting();

                    Sniper_rifle.bullet_count--;
                }
            }

        }
    }


    private bool Check_Enemy_in_Radar() {     
        return Physics2D.Raycast(transform.position, Vector2.right, 10f, Sniper_rifle.layer_mask);
    }

}
