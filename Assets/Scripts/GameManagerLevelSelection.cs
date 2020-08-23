using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLevelSelection : MonoBehaviour
{
    private int reachedLevel;
    public GameObject level02Button;
    // Start is called before the first frame update
    void Start()
    {
        reachedLevel = PlayerPrefs.GetInt("reachedLevel");
        if (reachedLevel >= 2)
        {
            level02Button.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ClickLevel01()
    {
        if (GameObject.FindGameObjectWithTag("main_menu_music_tag") != null)
        {
            GameObject.FindGameObjectWithTag("main_menu_music_tag").GetComponent<MainMenuMusic>().StopMainMenuMusic();
        }
        SceneManager.LoadScene(2);
    }


    public void ClickLevel02()
    {
        if (GameObject.FindGameObjectWithTag("main_menu_music_tag") != null)
        {
            GameObject.FindGameObjectWithTag("main_menu_music_tag").GetComponent<MainMenuMusic>().StopMainMenuMusic();
        }
        SceneManager.LoadScene(4);
    }

}
