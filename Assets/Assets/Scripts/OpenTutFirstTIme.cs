using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class OpenTutFirstTIme : MonoBehaviour
{
    
    public GameObject paper_anim;
    public GameObject sound_manager;
    public GameObject bt1, bt2;
    GameObject[] container_button;
    bool start_phase = true;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        paper_anim.GetComponent<Animator>().SetTrigger("tutorialin");
        audioData = sound_manager.transform.GetChild(8).GetComponent<AudioSource>();
        audioData.Play(0);

        bt1.GetComponent<Button>().interactable = false;
        bt2.GetComponent<Button>().interactable = false;
        container_button = GameObject.FindGameObjectsWithTag("container_button");
    }

    // Update is called once per frame
    void Update()
    { 
        if(start_phase == true)
        {
            if(Input.GetMouseButtonDown(0)||Input.GetMouseButtonDown(1))
            {
                paper_anim.GetComponent<Animator>().SetTrigger("tutorialout");
                audioData = sound_manager.transform.GetChild(9).GetComponent<AudioSource>();
                audioData.Play(0);
                bt1.GetComponent<Button>().interactable = true;
                bt2.GetComponent<Button>().interactable = true;

                foreach (GameObject item in container_button)
                    item.GetComponent<Button>().enabled=true;
            
                start_phase = false;
            }
             
        }
        
    }
}
