using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Container : MonoBehaviour
{
    private string liq_type;
    public bool toggled = false;
    AudioSource audioData;
   // public bool selected_final = false;
    // Start is called before the first frame update
    Transform light_;

    
    void Start()
    {
        light_ = this.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Button>().interactable==false)
            set_to_redlight();
        else
            if(toggled==false)
                color_untoggle();
    }

    public void set_to_redlight()
    {
        if(light_.GetChild(5).GetComponent<SpriteRenderer>().enabled==false)
        {
            light_.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
            light_.GetChild(4).GetComponent<SpriteRenderer>().enabled = false;
            light_.GetChild(5).GetComponent<SpriteRenderer>().enabled = true;
        }
       
    }

    public void set_type(string val)
    {
        liq_type = val;
    }

    public void clicked()
    {   

        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        if(toggled==false)
        {
            toggled = true;
            change_to_toggled();  
        }
        else
        {
            toggled = false;
            change_to_untoggled();
        }
        
        
    }

    public void change_to_toggled()
    {
        color_toggle();
        GameObject.Find("GameStateManager").GetComponent<GameState>().button_pressed();
    }
    
    public void change_to_untoggled()
    {
        GameObject.Find("GameStateManager").GetComponent<GameState>().button_depressed();
        color_untoggle();
    }

    public void color_toggle()
    {
        // Color newColor = new Color(1f, 1f, 1f);
        // newColor = new Color(0.78f, 0.78f, 0.78f);
        // this.transform.GetComponent<Image>().color = newColor;
        

        light_.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
        light_.GetChild(4).GetComponent<SpriteRenderer>().enabled = true;
        light_.GetChild(5).GetComponent<SpriteRenderer>().enabled = false;
    }

    public void color_untoggle()
    {
        // Color newColor = new Color(1f, 1f, 1f);
        // newColor = new Color(1f, 1f, 1f); 
        // this.transform.GetComponent<Image>().color = newColor;

        light_.GetChild(3).GetComponent<SpriteRenderer>().enabled = true;
        light_.GetChild(4).GetComponent<SpriteRenderer>().enabled = false;
        light_.GetChild(5).GetComponent<SpriteRenderer>().enabled = false;

    }


}
