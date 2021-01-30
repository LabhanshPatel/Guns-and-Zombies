using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money_Left_onLevelUp : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    void Start() {
        text.text = Static_Fields.money.ToString();
    }

  
}
