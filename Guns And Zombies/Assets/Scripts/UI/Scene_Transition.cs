using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Transition : MonoBehaviour
{


    void Awake()
    {
        if (FindObjectsOfType<Scene_Transition>().Length > 1)
            Destroy(this.gameObject);
        else
            DontDestroyOnLoad(this.gameObject);
    }

  
}
