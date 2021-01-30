using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_UI : MonoBehaviour
{
    public Color change_weapon_color;

    public bool change_this_black_color = false;
    public bool allow_instantiation = false;

    [SerializeField] int refresh_time;
    

    private float R = 0;
    private float G = 0;
    private float B = 0;

    private Weapon_Spawner weapon_spawner;

    private bool change_now = true;
    private bool start_refresh_func = true;
    private int weapon_ID = 0;

    private static bool[] keep_this_selected = {false, false, false, false, false};
    private static int count_instance = 0;

    public bool deselect_other_ui = false;

    public bool is_selected = false;

    void Start() { 
        
        change_weapon_color = GetComponent<SpriteRenderer>().color;
  
        R = GetComponent<SpriteRenderer>().color.r;
        G = GetComponent<SpriteRenderer>().color.g;
        B = GetComponent<SpriteRenderer>().color.b;
      
        weapon_spawner = FindObjectOfType<Weapon_Spawner>();
        check_for_current_instance();
    }

  

    void Update() {
      
        if (start_refresh_func == true) {         
                change_this_black_color = false;
                Weapon_Refresh_UI();
            
        }

        if (Change_color_to_black()) { 
        
            allow_instantiation = false;
            change_this_black_color = true;
            start_refresh_func = true;

            change_weapon_color = Color.black;
            change_weapon_color.a = 0;
            GetComponent<SpriteRenderer>().color = change_weapon_color;

        }

        if (deselect_other_ui == true) {   
                         
            if (keep_this_selected[weapon_ID - 1] == false) {  
                start_refresh_func = true;
                count_instance++;
            }

            if (count_instance == 4) { 
                deselect_other_ui = false;
                count_instance = 0;
            }
        }
    }




    private void OnMouseDown() {
    
        if (allow_instantiation) {    

            start_refresh_func = false;
            GetComponent<SpriteRenderer>().color = new Color(0,1,1); // change this color!!!!

            deselect_other_ui = true;

            if (is_selected == true && keep_this_selected[weapon_ID - 1] == true) { 
                                  
               start_refresh_func = true;
               is_selected = false;              
            }
            else {           

                for (int i = 0; i < keep_this_selected.Length; i++) {                 

                    if (i == weapon_ID - 1) {                    
                        keep_this_selected[i] = true;
                        is_selected = true;
                    }
                    else                   
                        keep_this_selected[i] = false;                   
                }

            }

        }
    }


    private void Weapon_Refresh_UI() {
        
        if (change_weapon_color.a <= 1) {
         
            change_weapon_color.a += Time.deltaTime / (refresh_time);
            GetComponent<SpriteRenderer>().color = change_weapon_color;
        }
        else {

           if (Static_Fields.money >= Static_Fields.gun_cost[weapon_ID - 1]) {            
                Weapon_is_Ready();
           }
            else {           
                allow_instantiation = false;
                GetComponent<SpriteRenderer>().color = Color.gray;
            }

        }
    }

    

    private void check_for_current_instance() { 
    
        if (this.gameObject.name == "Hand Gun")
            weapon_ID = 1;
        else if (this.gameObject.name == "Assault Rifle")
            weapon_ID = 2;
        else if (this.gameObject.name == "Shot Gun")
            weapon_ID = 3;
        else if (this.gameObject.name == "Burst Gun")
            weapon_ID = 4;
        else if (this.gameObject.name == "Sniper Rifle")
            weapon_ID = 5;
    }

    private bool Change_color_to_black() {

        if (weapon_ID == 1)
            return weapon_spawner.change_color_to_black_hand_gun;
        else if (weapon_ID == 2)
            return weapon_spawner.change_color_to_black_assault_rifle;
        else if (weapon_ID == 3)
            return weapon_spawner.change_color_to_black_shot_gun;
        else if (weapon_ID == 4)
            return weapon_spawner.change_color_to_black_burst_gun;
        else if (weapon_ID == 5)
            return weapon_spawner.change_color_to_black_sniper_rifle;
        else
            return false;

    }

    private void Weapon_is_Ready()
    {
        allow_instantiation = true;

        if (change_weapon_color.r <= 1 && change_now == true)
        {

            R += Time.deltaTime;
            G += Time.deltaTime;
            B += Time.deltaTime;
        }

        change_weapon_color.r = R;
        change_weapon_color.g = G;
        change_weapon_color.b = B;

        if (change_weapon_color.r >= 1 || change_now == false)
        {
            change_now = false;

            R -= Time.deltaTime;
            G -= Time.deltaTime;
            B -= Time.deltaTime;

            if (change_weapon_color.r <= 0)
                change_now = true;

        }

        GetComponent<SpriteRenderer>().color = change_weapon_color;
    }
}
