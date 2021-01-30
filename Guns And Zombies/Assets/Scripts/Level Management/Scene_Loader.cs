using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Loader : MonoBehaviour
{
    public static int current_scene;

    [SerializeField] Money_Manager money_manager;
 
    
    private Animation transition_animation;
    private Animation pause_ui_anim;

    [SerializeField] AudioSource button_click;
  
    private AudioSource background_music;
    private AudioSource pause_music;

    private int starting_money;
    private bool music_is_started = false;

    private bool check_level9_current_ui = true;

    private void Awake()
    {
        current_scene = SceneManager.GetActiveScene().buildIndex;
        Static_Fields.stop_adding_money = false;

    
        if (current_scene != 0)
        {          
            transition_animation = GameObject.Find("Scene Transition").transform.Find("Canvas").transform.Find("Background").GetComponent<Animation>();
          
        }
    }


    void Start() {

        if (current_scene == 3 || current_scene == 5 || current_scene == 8 || current_scene == 11)
            StartCoroutine(Enable_Weapon_Unlock_UI_Button());

        starting_money = Static_Fields.money;

        if (current_scene == 0) {        
           StartCoroutine(Load_startscene());
        }


        StartCoroutine(Check_if_Music_Started());

        if (current_scene != 1 && current_scene !=0 && current_scene != 14)
        {
            if (current_scene != 12 && current_scene != 15)
            {
                money_manager = FindObjectOfType<Money_Manager>().GetComponent<Money_Manager>();
                background_music = GameObject.Find("Play Space").transform.Find("Canvas(bg Music)").GetComponent<AudioSource>();
            }
            
            pause_ui_anim = GameObject.Find("Pause UI").GetComponent<Animation>();
            pause_music = GameObject.Find("Pause UI").GetComponent<AudioSource>();
        }

        StartCoroutine(Wait_Before_Time_Stops());
      

        if(current_scene == 1 || current_scene == 14)
        {
            if(FindObjectsOfType<Money_Manager>().Length > 0)
               Destroy(FindObjectOfType<Money_Manager>().gameObject);
        }

    }

    public void Load_GameOver_Scene()
    {
        SceneManager.LoadScene(6);
    }
  
    public void Load_Level1_Scene()
    {
        button_click.Play();

        Static_Fields.money = 0;
        money_manager.text.text = Static_Fields.money.ToString();
        transition_animation.Play("scene_transition");
        StartCoroutine(Wait_for_button_response(2));
    }

    public void Load_CurrentLevel_Scene()
    {
        button_click.Play();

        Time.timeScale = 1;
        Static_Fields.money = starting_money;
        money_manager.text.text = Static_Fields.money.ToString();

        transition_animation.Play("scene_transition");

        StartCoroutine(Wait_for_button_response(SceneManager.GetActiveScene().buildIndex));
    }

    public void Load_Menu_scene()
    {
        button_click.Play();

        Time.timeScale = 1;

        transition_animation.Play("scene_transition");

        StartCoroutine(Wait_for_button_response(1));        
    }


    public void Load_Next_Level() {
        button_click.Play();  
        transition_animation.Play("scene_transition");
        StartCoroutine(Wait_for_button_response(current_scene + 1));
    }

    public void Load_Tutorial()
    {
        button_click.Play();
        transition_animation.Play("scene_transition");
        StartCoroutine(Wait_for_button_response(12));

    }
    public void On_Click_Quit_Button() {     
        Application.Quit();
    }

    public void On_Click_Pause_Button()
    {
        if (music_is_started == true)
            background_music.Pause();

        GameObject.Find("Pause UI").transform.Find("Canvas").gameObject.SetActive(true);

        pause_music.Play();

        StartCoroutine(Pause_UI_Animation());
    }

    public void On_Click_Resume_Button()
    {
        button_click.Play();

        pause_ui_anim.Play("Pause UI out");
        Time.timeScale = 1;

        if (music_is_started == true)                
            background_music.Play();
        

        StartCoroutine(wait_for_anim());
    }

    public void On_Click_WeaponUnlockUI_Button()
    {
        if (current_scene == 10)
        {
            if (check_level9_current_ui == true)
            {
                check_level9_current_ui = false;
                GameObject.Find("Hope").transform.Find("Hint").gameObject.SetActive(true);
                GameObject.Find("Hope").transform.Find("We can do it").GetComponent<Animation>().Play();
            }
            else
            {
                GameObject.Find("Hope").transform.Find("Hint").GetComponent<Animation>().Play();
                Time.timeScale = 1;
                GameObject.Find("Play Space").transform.Find("pause").gameObject.SetActive(true);
            }

        }
        else
        {
            StartCoroutine(Play_Weapon_Unlock_Animation());
        }
    }

    public void Reload_Tutorial()
    {
        StartCoroutine(Reload_tutorial());
    }

    public void Load_Cradits()
    {
        transition_animation.Play("scene_transition");

        StartCoroutine(Wait_for_button_response(14));
    }

    IEnumerator Load_startscene() {    
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }

    IEnumerator Wait_for_button_response(int index)
    {
        yield return new WaitForSeconds(1f);      
        SceneManager.LoadScene(index);  
    }


    IEnumerator wait_for_anim()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Pause UI").transform.Find("Canvas").gameObject.SetActive(false);
    }

    IEnumerator Pause_UI_Animation()
    {
        pause_ui_anim.Play("Pause UI in");
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }

    IEnumerator Check_if_Music_Started()
    {
        yield return new WaitForSeconds(20);

        if (current_scene != 12 && current_scene != 13)
        {
            music_is_started = true;
        }

    }

    IEnumerator Reload_tutorial()
    {
        Time.timeScale = 1;
        transition_animation.Play("scene_transition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(12);
    }

    IEnumerator Play_Weapon_Unlock_Animation()
    {
        Time.timeScale = 1;
        GameObject.Find("Weapon Unlocked").GetComponent<Animation>().Play();

        if (current_scene == 3 || current_scene == 5 || current_scene == 8  || current_scene == 11)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject.Find("Play Space").transform.Find("pause").gameObject.SetActive(true);
        }
    }
   
    IEnumerator Wait_Before_Time_Stops()
    {
        yield return new WaitForSeconds(1.1f);

        if (current_scene == 3 || current_scene == 5 || current_scene == 8 || current_scene == 10 || current_scene == 11 || current_scene == 13)        
            Time.timeScale = 0;       
        else       
            Time.timeScale = 1;
        
    }

    IEnumerator Enable_Weapon_Unlock_UI_Button()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("Weapon Unlocked").transform.Find("Canvas").transform.Find("UI").transform.Find("OK").gameObject.SetActive(true);
    }


    public void Load_Level_1()
    {
        SceneManager.LoadScene(2);
    }

    public void Load_Level_2()
    {
        SceneManager.LoadScene(3);
    }
    public void Load_Level_3()
    {
        SceneManager.LoadScene(4);
    }
    public void Load_Level_4()
    {
        SceneManager.LoadScene(5);
    }
    public void Load_Level_5()
    {
        SceneManager.LoadScene(6);
    }
    public void Load_Level_6()
    {
        SceneManager.LoadScene(7);
    }
    public void Load_Level_7()
    {
        SceneManager.LoadScene(8);
    }
    public void Load_Level_8()
    {
        SceneManager.LoadScene(9);
    }
    public void Load_Level_9()
    {
        SceneManager.LoadScene(10);
    }
    public void Load_Level_10()
    {
        SceneManager.LoadScene(11);
    }
   
}
