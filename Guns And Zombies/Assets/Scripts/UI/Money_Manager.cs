using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money_Manager : MonoBehaviour
{

    public TextMeshProUGUI text;
    [SerializeField] int starting_money_value;

    void Awake()
    {
        if(FindObjectsOfType<Money_Manager>().Length > 1)       
            Destroy(this.gameObject);            
        else        
            DontDestroyOnLoad(this.gameObject);
        
    }


    void Start() {
        Static_Fields.money = starting_money_value;
        text.text = Static_Fields.money.ToString();
    }

    public void Add_Money(int money_value) {
        Static_Fields.money += money_value;      
        text.text = Static_Fields.money.ToString();
    }
    public void Deduct_Money(int price_value) {
        Static_Fields.money -= price_value;
        text.text = Static_Fields.money.ToString();


        if (Static_Fields.money < 0) {
            Static_Fields.money = 0;

            text.text = Static_Fields.money.ToString();
        }
    }

    
}
