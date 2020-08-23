using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private AudioSource mainMenuSong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        mainMenuSong = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopMainMenuMusic()
    {
        mainMenuSong.Stop();
    }
    public void PlayMainMenuMusic()
    {
        mainMenuSong.Play();
    }

    // from scenes use this code:
    // GameObject.FindGameObjectWithTag("MainMenuMusic").GetComponent<MusicClass>().PlayMainMenuMusic();
}
