using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_10_gameover_collider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        { 
            GameObject.Find("Game Over").transform.Find("Canvas").gameObject.SetActive(true);
            GameObject.Find("Game Over").GetComponent<AudioSource>().Play();
        }
    }
}
