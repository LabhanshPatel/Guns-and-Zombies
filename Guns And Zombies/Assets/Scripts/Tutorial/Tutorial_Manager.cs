using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Tutorial_class{
    public string name;
    public Tutorial_Scriptableobj tutorual_scriptableobj;
    public TextMeshProUGUI text;
}
public class Tutorial_Manager : MonoBehaviour
{
   

    [SerializeField] Animation animation_manager;
    [SerializeField] List<Tutorial_class> Tutorials_Array = new List<Tutorial_class>();

    [SerializeField] GameObject[] Tutorials_obj_array;

    [SerializeField] GameObject Zombie_Prefab;
    [SerializeField] GameObject T3_Highlight_Box;
  
    [SerializeField] private AudioSource audio_player;

    private int description_index = 0;
    private Vector3 Zombie_spawn_pos;

    private bool[] T = { false, false, false, false};
    private bool flag = true;
    private bool flag_for_T1_6 = false;
    private bool welcom_is_active = true;

  
    void Start()
    {
        Static_Fields.money = 0;
        Tutorials_Array[0].text.text = Tutorials_Array[0].tutorual_scriptableobj.description[0].ToString();
    }


    void Update()
    {

        if (T[0] == true)
            Tutorial_1();
        else if (T[1] == true)
            Tutorial_2();
        else if (T[2] == true)
            Tutorial_3();
        else if (T[3] == true)
        {

            if (Static_Fields.money > 0 && flag == true)
            {
                StartCoroutine(Play_Completion_in());
                flag = false;
            }
        } 
    }

   

    private void Tutorial_1()
    {
        if (flag == true)
        {
            flag = false;

            Tutorials_Array[1].text.text = Tutorials_Array[1].tutorual_scriptableobj.description[description_index].ToString();

            if (description_index == 2)
            {
                StartCoroutine(Hand_Anim());
            }

            if (description_index == 4)
            {
                Tutorials_obj_array[1].transform.Find("Hand Gun sprite").gameObject.SetActive(false);
                GameObject.Find("Weapon Selector UI").transform.Find("Buttom").transform.Find("Hand Gun").gameObject.GetComponent<Gun_UI>().enabled = true;
                StartCoroutine(Wait_For_Refresh());
            }

            if (description_index == 6)
            {
                Tutorials_obj_array[1].transform.Find("Tutorial Highlighted area 2").gameObject.SetActive(true);
                animation_manager.Play("Place Gun inside arena");


            }

        }

        if (Input.GetMouseButtonDown(0) == true)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (description_index != 2 && description_index != 4 && description_index != 5)
            {
                if (description_index == 6)
                {
                    if ((worldPosition.x > 1 && worldPosition.x < 6) && (worldPosition.y > 0 && worldPosition.y < 5))
                    {
                        Zombie_spawn_pos = worldPosition;
                        description_index++;
                        flag = true;

                    }
                }
                else
                {
                    description_index++;
                    flag = true;
                }
            }
            else if (GameObject.Find("Hand") == null && description_index != 4 && description_index != 5)
            {

                if ((worldPosition.x > 0 && worldPosition.x < 1) && (worldPosition.y > -1 && worldPosition.y < 0))
                {
                    audio_player.Play();

                    description_index++;
                    flag = true;
                }
            }
            else if (description_index == 5)
            {

                if (flag_for_T1_6 == true)
                {
                    if ((worldPosition.x > 0 && worldPosition.x < 1) && (worldPosition.y > -1 && worldPosition.y < 0))
                    {
                        description_index++;
                        flag = true;
                    }
                }
            }

            if (description_index == 7)
            {
                StartCoroutine(Play_T1_out());
            }

        }
    }

    private void Tutorial_2()
    {
        if (Static_Fields.money > 0 && flag == true)
        {
            StartCoroutine(Play_T2_in());
            flag = false;

        }

        if (flag == false)
        {

            if (Input.GetMouseButtonDown(0) == true)
            {
                 description_index++;
                 if (description_index < 2)
                      Tutorials_Array[2].text.text = Tutorials_Array[2].tutorual_scriptableobj.description[description_index].ToString();
                 else
                     StartCoroutine(Play_T2_out());
            }
        }
    }

    private void Tutorial_3()
    {
        if (flag == true)
        {
            StartCoroutine(Play_T3_in());
            flag = false;
        }

        if (flag == false)
        {
            if (Input.GetMouseButtonDown(0) == true)
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (description_index == 0)
                {
                    description_index++;

                    Tutorials_Array[3].text.text = Tutorials_Array[3].tutorual_scriptableobj.description[description_index].ToString();
                    GameObject a = GameObject.Find("T3_Highlight_Box(Clone)");
                    Destroy(a);
                    StartCoroutine(Scale_Box_anim());
                    Tutorials_obj_array[3].transform.Find("Hand").gameObject.SetActive(true);
                    animation_manager.Play("Hand 2");
                }
                else if (description_index == 1)
                {
                    if ((worldPosition.x > 0 && worldPosition.x < 1) && (worldPosition.y > 5 && worldPosition.y < 6))
                    {
                        audio_player.Play();

                        description_index++;

                        Tutorials_Array[3].text.text = Tutorials_Array[3].tutorual_scriptableobj.description[description_index].ToString();
                        GameObject a = GameObject.Find("T3_Highlight_Box(Clone)");
                        Destroy(a);
                        StartCoroutine(Scale_Box_anim());

                        Tutorials_obj_array[3].transform.Find("Hand").transform.position =
                        FindObjectOfType<Add_Bullets_Hand_Gun>().transform.position + new Vector3(-0.5f, 0.3f, 0f);


                    }
                }
                else if (description_index == 2)
                {
                    Tutorials_obj_array[3].transform.Find("Hand").gameObject.SetActive(false);
                    if (FindObjectOfType<Add_Bullets_Hand_Gun>().transform.Find("Hand Gun").
                        GetComponent<Hand_Gun>().Hand_gun.bullet_count > 0)
                    {

                        description_index++;

                        Tutorials_Array[3].text.text = Tutorials_Array[3].tutorual_scriptableobj.description[description_index].ToString();
                        GameObject a = GameObject.Find("T3_Highlight_Box(Clone)");
                        Destroy(a);
                        StartCoroutine(Play_T3_out());
                    }
                }
               
            }
        }
    }

    public void On_Click_Next_Button()
    {

        if (welcom_is_active == true)
        {
            description_index++;
            if (description_index == 4)
            {
                animation_manager.Play("Frame out");
                StartCoroutine(T1());
                return;
            }
            else
            {
                audio_player.Play();
                Tutorials_Array[0].text.text = Tutorials_Array[0].tutorual_scriptableobj.description[description_index].ToString();
            }
        }
        else
        {         

            if (description_index == 1)
            {
                PlayerPrefs.SetInt("Show_Tutorial", 1);
                SceneManager.LoadScene(13);

            }
            else
            {
                audio_player.Play();

                description_index++;
                Tutorials_Array[4].text.text = Tutorials_Array[4].tutorual_scriptableobj.description[description_index].ToString();
            }

        }
    }


    IEnumerator T1()
    {
        yield return new WaitForSeconds(1f);
        Tutorials_obj_array[0].SetActive(false);
        Tutorials_obj_array[1].SetActive(true);

        animation_manager.Play("T1 in");

        yield return new WaitForSeconds(1f);
        Tutorials_obj_array[1].transform.Find("Hand Gun sprite").gameObject.SetActive(true);

        T[0] = true;
        description_index = 0;

    }

    IEnumerator Hand_Anim()
    {

        Tutorials_obj_array[1].transform.Find("Hand").gameObject.SetActive(true);
        animation_manager.Play("Hand 1");
        if (description_index == 5)
        {
            audio_player.Play();
            yield return new WaitForSeconds(1f);
        }
        else
            yield return new WaitForSeconds(2f);

        Tutorials_obj_array[1].transform.Find("Hand").gameObject.SetActive(false);


        if (description_index == 5)
        {
            flag_for_T1_6 = true;
        }
    }

    IEnumerator Wait_For_Refresh()
    {
        yield return new WaitForSeconds(8f);
        description_index++;
        yield return new WaitForSeconds(1f);


        StartCoroutine(Hand_Anim());

        flag = true;
    }

    IEnumerator Play_T1_out()
    {
        animation_manager.Play("T1 out");
        yield return new WaitForSeconds(2f);
        flag = true;
        description_index = 0;
        T[0] = false;
        Tutorials_obj_array[1].SetActive(false);

        FindObjectOfType<Add_Bullets_Hand_Gun>().transform.Find("Hand Gun").GetComponent<Hand_Gun>().Hand_gun.bullet_count = 10;
        Instantiate(Zombie_Prefab, new Vector3(10f, (int)Zombie_spawn_pos.y + 0.7f, -5f), Quaternion.identity);

        GameObject.Find("Weapon Selector UI").transform.Find("Buttom").transform.
                Find("Hand Gun").gameObject.SetActive(false);
        T[1] = true;
    }


    IEnumerator Play_T2_in()
    {
        Tutorials_obj_array[2].SetActive(true);
        animation_manager.Play("T2 in");

        yield return new WaitForSeconds(1f);
        Tutorials_Array[2].text.text = Tutorials_Array[2].tutorual_scriptableobj.description[description_index].ToString();
    }

    IEnumerator Play_T2_out()
    {

        animation_manager.Play("T2 out");
        yield return new WaitForSeconds(1f);
        description_index = 0;
        T[1] = false;
        Tutorials_obj_array[2].SetActive(false);

        yield return new WaitForSeconds(1f);

        flag = true;
        T[2] = true;
    }

    IEnumerator Play_T3_in()
    {
        Tutorials_obj_array[3].SetActive(true);

       
        animation_manager.Play("T3 in");
        StartCoroutine(Scale_Box_anim());
        yield return new WaitForSeconds(0.7f);
        Tutorials_Array[3].text.text = Tutorials_Array[3].tutorual_scriptableobj.description[description_index].ToString();
    }


    IEnumerator Play_T3_out()
    {
        yield return new WaitForSeconds(1f);
        animation_manager.Play("T3 out");
        yield return new WaitForSeconds(2f);
        T[2] = false;
        Tutorials_obj_array[3].SetActive(false);

        description_index = 0;
        Instantiate(Zombie_Prefab, new Vector3(10f, (int)Zombie_spawn_pos.y + 0.7f, -5f), Quaternion.identity);

        flag = true;
        T[3] = true;
    }


    IEnumerator Scale_Box_anim()
    {
        GameObject box = null;
        if (description_index !=1)
        {
           box  = Instantiate(T3_Highlight_Box, FindObjectOfType<Add_Bullets_Hand_Gun>().transform.position
                                     + new Vector3(-0.5f, 0.3f, 0f), Quaternion.identity) as GameObject;
        }
        else
        {
           box = Instantiate(T3_Highlight_Box,new Vector3(0.5f, 5.5f, -5f), Quaternion.identity) as GameObject;
        }
      
        Vector3 change = new Vector3(0,0,0);

        while (box.transform.localScale.x <= 1)
        {
             change += new Vector3(2*Time.deltaTime, 2*Time.deltaTime, 2*Time.deltaTime);
             box.transform.localScale = change;
             yield return new WaitForSeconds(0.01f);
        }
    }


    IEnumerator Play_Completion_in()
    {
        welcom_is_active = false;

        Tutorials_obj_array[4].SetActive(true);
        animation_manager.Play("Completion in");

        yield return new WaitForSeconds(0.7f);
        Tutorials_Array[4].text.text = Tutorials_Array[4].tutorual_scriptableobj.description[description_index].ToString();
    }



}