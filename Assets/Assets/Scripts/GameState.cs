using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System.Linq;
using System;

using Random=System.Random;

public class GameState : MonoBehaviour
{
    private int MAX_TRIES = 9;
    private int MAX_Container_Selection = 2;

    public GameObject prompt_canvas;
    public GameObject mix_reaction_anim;
    public GameObject mix_reaction_text;
    public GameObject droid_anim;
    public GameObject sound_manager;
    public GameObject reset_anim;
    public GameObject win_text;
    public GameObject mix_count_text;
    public GameObject reaction_text;
    public GameObject drink_prompt_prefab;
    private GameObject drink_prompt;
    public GameObject Containers_;
    
    public Button mix_button;
    Text mix_count_text_;

    private List<string> liq_list = new List<string>();
    public bool end_phase=false;
    bool first_start = false;


    public int container_count=0;
    int mix_count = 0;
    GameObject[] container_button;

    AudioSource audioData;

    
    
    void Start()
    {   

        Debug.Log("StartGameState");
        mix_count_text_ = mix_count_text.GetComponent<Text>();
        container_button = GameObject.FindGameObjectsWithTag("container_button");
        Color newColor;
        newColor = new Color(1f, 1f, 1f, 0f);
        foreach (GameObject item in container_button)
            item.transform.GetChild(1).GetComponent<Text>().color= newColor;
        if(first_start == false)
            Init_list();
        randomize();
        assign_containers();
        first_start = true;
    } 

    // Update is called once per frame
    void Update()
    {
        mix_count_text_.text = mix_count.ToString();
        if(container_count == MAX_Container_Selection)
            disable_buttons();
    }

    public void check_win_condition()
    {
        Color newColor;
        newColor = new Color(1f, 1f, 1f, 1f);
        end_phase=true;
        foreach (GameObject item in container_button)
        {
            item.transform.GetChild(1).GetComponent<Text>().color= newColor;
            if(item.GetComponent<Container>().toggled==true)
                if(item.transform.GetChild(1).GetComponent<Text>().text == "gasoline")
                {
                    Debug.Log("WIN!!");
                    audioData = sound_manager.transform.GetChild(3).GetComponent<AudioSource>();
                    audioData.Play(0);
                    droid_anim.GetComponent<Animator>().SetTrigger("winTrigger");
                    win_text.GetComponent<Animator>().SetTrigger("win");

                }
                    
                else
                {
                    audioData = sound_manager.transform.GetChild(4).GetComponent<AudioSource>();
                    audioData.Play(0);
                    droid_anim.GetComponent<Animator>().SetTrigger("loseTrigger");
                    win_text.GetComponent<Animator>().SetTrigger("lose");
                    Debug.Log("Burn beeatch");
                 
                }
                    
        }
        audioData = sound_manager.transform.GetChild(6).GetComponent<AudioSource>();
        audioData.Stop();

    }

    public void restart()
    {
        MAX_Container_Selection = 2;
        container_count=0;
        mix_count = 0;
        end_phase=false;

        foreach (GameObject item in container_button)
        {
        
            item.GetComponent<Container>().toggled=false;
            item.GetComponent<Button>().enabled=true;
            item.GetComponent<Button>().interactable=true;
            item.GetComponent<Container>().color_untoggle();
        }
         
        mix_button.GetComponent<Button>().interactable=false;
        // droid_anim.GetComponent<Animator>().ResetTrigger("winTrigger");
        // droid_anim.GetComponent<Animator>().ResetTrigger("loseTrigger");
        droid_anim.GetComponent<Animator>().SetTrigger("restartTrigger");
        reset_anim.GetComponent<Animator>().SetTrigger("start");
        Debug.Log("restarted");
        audioData = sound_manager.transform.GetChild(6).GetComponent<AudioSource>();
        audioData.PlayDelayed(1.5f);
        
        MAX_Container_Selection = 2;
        container_count=0;
        mix_count = 0;
        end_phase=false;

        Start();
    }

    void disable_buttons()
    {
        
        foreach (GameObject item in container_button)
        {
            if(item.GetComponent<Container>().toggled==false)
                item.GetComponent<Button>().interactable=false;
        }

        if(mix_count==MAX_TRIES)
            mix_button.GetComponent<Button>().interactable=false;
        else
            mix_button.GetComponent<Button>().interactable=true;

    }

    public void button_pressed()
    {
        
        if(container_count<MAX_Container_Selection)
            container_count++;

        if(MAX_Container_Selection == 1)
        {
            
            foreach (GameObject item in container_button)
            {       
                if(item.GetComponent<Container>().toggled==true)
                {
                   
                    drink_prompt = Instantiate(drink_prompt_prefab, item.transform.position, Quaternion.identity, prompt_canvas.transform);
                    drink_prompt.transform.localPosition = drink_prompt.transform.localPosition + new Vector3(0f, -37f, 0f);
                }
                    
            }
        }
        
    }

    public void button_depressed()
    {
        container_count--;
        if(container_count==MAX_Container_Selection-1)
        {            
            foreach (GameObject item in container_button)
            {
                item.GetComponent<Button>().interactable=true;
            }
            mix_button.GetComponent<Button>().interactable=false;
        }

    
        
    }

    public void mix_liquid()
    {

        if(mix_count<MAX_TRIES)
        {
            foreach (GameObject item in container_button)
            {
                if(item.GetComponent<Container>().toggled==true)
                {
                    item.GetComponent<Container>().toggled=false;
                    item.GetComponent<Container>().change_to_untoggled();
                }

                item.GetComponent<Button>().interactable=true;
            }
            
            mix_count++;
            container_count = 0;
            mix_button.GetComponent<Button>().interactable=false;
            
            
            string mixture = mix_button.GetComponent<MixReactions>().reaction;
            mixture = (string)mix_button.GetComponent<MixReactions>().reactions[mixture];
            reaction_text.transform.GetChild(0).GetComponent<Text>().text = mixture;
            
            
            mix_reaction_anim.GetComponent<Animator>().SetTrigger(mixture+"Trigger");
            mix_reaction_text.GetComponent<Animator>().SetTrigger("MixTrigger");

            if(mixture=="boils")
            {
                audioData = sound_manager.transform.GetChild(0).GetComponent<AudioSource>();
                audioData.Play(0);
            }
            else if(mixture=="explodes")
            {
                audioData = sound_manager.transform.GetChild(1).GetComponent<AudioSource>();
                audioData.Play(0);
            }               
            else
            {
                audioData = sound_manager.transform.GetChild(2).GetComponent<AudioSource>();
                audioData.Play(0);
            }

            if(mix_count==MAX_TRIES)
            {
                MAX_Container_Selection=1;   
            }

            
        }
        else
        {   
            Debug.Log("max tries");
        }
        
    }

    void assign_containers()
    {
        int i = 0;
        foreach (Transform child in Containers_.transform)
        {   
            child.GetComponent<Container>().set_type(liq_list[i]);
            child.GetChild(1).GetComponent<Text>().text = liq_list[i];
            i++;
        }
    }
    void Init_list()
    {
        liq_list.Add("water");
        liq_list.Add("water");
        liq_list.Add("gasoline");

        liq_list.Add("gasoline");
        liq_list.Add("potion");
        liq_list.Add("potion");

        liq_list.Add("gasoline");
        liq_list.Add("acid");
        liq_list.Add("acid");


    }

    void randomize()
    {
    //     var rnd = new Random();
    //     var randomized = liq_list.OrderBy(item => rnd.Next());
        liq_list.Shuffle();
        
       Debug.Log("list shuffled: ");
       foreach (string item in liq_list)
            Debug.Log(item);
    }
}
