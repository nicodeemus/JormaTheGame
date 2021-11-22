using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HydrationManager : MonoBehaviour
{
    [SerializeField] public Text hydration;
    public float time = 15;
    HydrationManager hydrationManager;
    Player player;
    public float cancounter = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        hydrationManager = GameObject.Find("Hydration").GetComponent<HydrationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ticking down timer function for hydration
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        // Player dies if timer runs out
        else
        {
            if(SceneManager.GetActiveScene().name != "StartMenu") { 
                time = 0;
                RespawnMenu.Pause();
                hydrationManager.time = 15;
            }
        }
        // Prevent hydration bar from going above 15(max)
        if(time > 15)
        {
            time = 15;
        }

        DisplayTime(time);
    }

    public void addToHydration()
    {
        // Adds time onto the timer
        time += 2;
        cancounter += 1;
    }

    public void DisplayTime(float timeToDisplay)
    {
        // Renders canvas text for hydration
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float seconds = Mathf.FloorToInt(timeToDisplay);
        hydration.text = "Hydration:\nCans collected:" + cancounter;
    }

}
