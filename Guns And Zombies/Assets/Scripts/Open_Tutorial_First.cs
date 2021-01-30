using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Open_Tutorial_First : MonoBehaviour
{
    private const string key_name = "Show_Tutorial";

    void Start()
    {
     //   uncomment to reset key
    //   PlayerPrefs.DeleteKey(key_name);

        if (PlayerPrefs.HasKey(key_name) == false)
        {
            Load_Tutorial();
        }
    }

    public void Load_Tutorial()
    {
        SceneManager.LoadScene(12);
    }
}
