using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial_Level_class
{
    public string name;
    public Tutorial_Scriptableobj tutorual_scriptableobj;
    public TextMeshProUGUI text;
   
}

public class Tutorial_Level_script : MonoBehaviour
{
    private int description_index = 0;

    [SerializeField] Tutorial_class Tutorail_obj = new Tutorial_class();

    [SerializeField] Animation frame_out_clip;

    [SerializeField] GameObject pause_ui;

    private void Start()
    {
        Time.timeScale = 1;
        Tutorail_obj.text.text = Tutorail_obj.tutorual_scriptableobj.description[description_index].ToString();
        description_index++;
    }
    public void On_Click_Next_Button()
    {
        if (description_index < 3)
        {
            Tutorail_obj.text.text = Tutorail_obj.tutorual_scriptableobj.description[description_index].ToString();
            description_index++;
        }
        else
        {
            Time.timeScale = 1;
            frame_out_clip.Play("Best_of_Luck_out");
            pause_ui.SetActive(true);
        }
    }

}
