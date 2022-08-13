using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Prompt : MonoBehaviour
{
    // Start is called before the first frame update
    
    GameObject[] container_button;
    void Start()
    {
      // this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
      
      
      container_button = GameObject.FindGameObjectsWithTag("container_button");
      foreach (GameObject item in container_button)
        {
            if(item.GetComponent<Container>().toggled==true)
            {
              item.GetComponent<Button>().enabled=false;
            }
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void TaskOnClick()
    // {
    //     //Destroy(this.transform.parent);
    // }

    public void Destroythis()
    {
     // item_.GetComponent<Container>().selected_final=false;
      enableButtons();
      ResetManager();
      Destroy(GameObject.Find("DrinkPrompt(Clone)"));
      //Destroy(instance.this);
    }

    void enableButtons()
    {
      GameObject[] container_button;
      container_button = GameObject.FindGameObjectsWithTag("container_button");
      foreach (GameObject item in container_button)
          {
          
              item.GetComponent<Container>().toggled=false;
              //item.GetComponent<Container>().selected_final=false;
              item.GetComponent<Button>().enabled=true;
              item.GetComponent<Container>().change_to_untoggled();

          }
        
    }
    
    void ResetManager()
    {
      GameObject manager;
      manager = GameObject.Find("GameStateManager");
      manager.GetComponent<GameState>().container_count=0;

      if(manager.GetComponent<GameState>().end_phase==true)
      {
        foreach (GameObject item in container_button)
            item.GetComponent<Button>().interactable=false;

      }

    }

     
}
