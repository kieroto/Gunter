using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinCon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void win()
    {
      GameObject manager;
      manager = GameObject.Find("GameStateManager");
      manager.GetComponent<GameState>().check_win_condition();
    }
}
