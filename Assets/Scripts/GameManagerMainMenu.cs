using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMainMenu : MonoBehaviour
{
    public AudioSource mainMenuBackgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuBackgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        if (!mainMenuBackgroundMusic.isPlaying)
        {
            mainMenuBackgroundMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
