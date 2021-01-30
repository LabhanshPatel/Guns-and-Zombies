using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Weapon_Card_UI : MonoBehaviour
{
    [SerializeField] Weapon_Unlock_Scriptable_obj Card;

    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI description;

    void Start()
    {
        image.sprite = Card.image;
        _name.text = Card.name;
        description.text = Card.description;
    }

    void Update()
    {
        
    }
}
