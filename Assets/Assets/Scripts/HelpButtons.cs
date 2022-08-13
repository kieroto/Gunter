using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class HelpButtons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject otherbutton;
    public GameObject paper_anim;
    public GameObject sound_manager;
    bool toggled = false;
 
    AudioSource audioData;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void clicked()
    {   


        if(toggled==false)
        {
            toggled = true;
            paper_anim.GetComponent<Animator>().SetTrigger("tutorialin");
            audioData = sound_manager.transform.GetChild(8).GetComponent<AudioSource>();
            audioData.Play(0);
            otherbutton.GetComponent<Button>().interactable = false;
        }
        else
        {
            paper_anim.GetComponent<Animator>().SetTrigger("tutorialout");
            audioData = sound_manager.transform.GetChild(9).GetComponent<AudioSource>();
            audioData.Play(0);
            otherbutton.GetComponent<Button>().interactable = true;
            toggled = false;
        }
        
        
    }

    public void clicked1()
    {   


        if(toggled==false)
        {
            toggled = true;
            paper_anim.GetComponent<Animator>().SetTrigger("tablein");
            audioData = sound_manager.transform.GetChild(8).GetComponent<AudioSource>();
            audioData.Play(0);
            otherbutton.GetComponent<Button>().interactable = false;
        }
        else
        {
            paper_anim.GetComponent<Animator>().SetTrigger("tableout");
            audioData = sound_manager.transform.GetChild(9).GetComponent<AudioSource>();
            audioData.Play(0);
            otherbutton.GetComponent<Button>().interactable = true;
            toggled = false;
        }
        
        
    }
}
