using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MixReactions : MonoBehaviour
{
    // Start is called before the first frame update
    public IDictionary reactions = new Dictionary<string, string>();
    GameObject[] container_button;
    public string reaction;

    void Start()
    {
        //water
        reactions.Add("waterwater", "nothing");

        reactions.Add("wateracid", "boils");
        reactions.Add("acidwater", "boils");

        reactions.Add("waterpotion", "boils");
        reactions.Add("potionwater", "boils");

        reactions.Add("watergasoline", "nothing");
        reactions.Add("gasolinewater", "nothing");
        //water

        //acid
        reactions.Add("acidacid", "boils");

        reactions.Add("acidpotion", "boils");
        reactions.Add("potionacid", "boils");

        reactions.Add("acidgasoline", "explodes");
        reactions.Add("gasolineacid", "explodes");
        //acid

        //potion
        reactions.Add("potionpotion", "nothing");

        reactions.Add("potiongasoline", "nothing");
        reactions.Add("gasolinepotion", "nothing");
        //potion
        
        //dragonblood
        reactions.Add("gasolinegasoline", "nothing");
        //dragonblood
    }

    public void react()
    {
        reaction="";
        container_button = GameObject.FindGameObjectsWithTag("container_button");
        
        AudioSource audioData;
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);

        foreach (GameObject item in container_button)
        {
            if(item.GetComponent<Container>().toggled==true)
                reaction=reaction+item.transform.GetChild(1).GetComponent<Text>().text;
        }
        //Debug.Log(reaction);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
