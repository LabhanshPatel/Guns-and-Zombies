using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    [SerializeField] float move_speed = 0.1f;
    private Vector3 target_pos;
    private Money_Manager money_manager;

    private void Start()
    {
        money_manager = FindObjectOfType<Money_Manager>();
        target_pos = new Vector3(-1f, 5.5f, -2f);
    }

    private void Update()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, target_pos, move_speed*Time.deltaTime); 

        if(transform.position == target_pos)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Static_Fields.stop_adding_money == false) {

            if (collision.gameObject.name == "Target Collider")
            {

                if (this.gameObject.name == "Coin 1(Clone)")
                    money_manager.Add_Money(Static_Fields.coin1_value);
                else if (this.gameObject.name == "Coin 2(Clone)")
                    money_manager.Add_Money(Static_Fields.coin2_value);
                else if (this.gameObject.name == "Coin 3(Clone)")
                    money_manager.Add_Money(Static_Fields.coin3_value);
                else if (this.gameObject.name == "Coin 4(Clone)")
                    money_manager.Add_Money(Static_Fields.coin4_value);
            }
        }
    }


   
}
