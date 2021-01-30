using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class level_counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;

    int level_counter_value;

    private void Start()
    {
        int build_index = SceneManager.GetActiveScene().buildIndex;
        level_counter_value = build_index - 1;

        text.text = level_counter_value.ToString();
    }


}
