using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public static bool isGameOver = false;
    public GameObject benji;
    private Animator benjiAnim;
    private BenjiSounds benjiSounds;
    private bool lostRecently = true;
    public GameObject initialMessagePanel;
    public GameObject playUI;
    public GameObject barkWave;
    private AudioSource[] sounds;
    private AudioSource catdie;
    private AudioSource benjibark;
    private AudioSource gameOverSound;
    public TextMeshProUGUI barkCountText;
    public int barkCount;
    public AudioSource backgroundMusic;
    public GameObject HowToPlayUI;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        isGameOver = false;
        benjiSounds = benji.GetComponent<BenjiSounds>();
        benjiAnim = benji.GetComponent<Animator>();
        initialMessagePanel.SetActive(true);
        sounds = GetComponents<AudioSource>();
        catdie = sounds[0];
        benjibark = sounds[1];
        gameOverSound = sounds[2];
        barkCountText.text = barkCount.ToString();
        backgroundMusic = GameObject.Find("BackgroundMusicLVL1").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver && lostRecently)
        {
            benjiSounds.PlayCry();
            benjiAnim.SetBool("isDeaded", true);
            lostRecently = false;
            GameOver();
        }

    }

    public void GameOver()
    {
        backgroundMusic.Stop();
        gameOverSound.Play();
        Time.timeScale = .5f;
        gameOverPanel.SetActive(true);
        benji.GetComponent<BenjiControls>().enabled = false;
        benji.GetComponents<BoxCollider2D>()[1].enabled = false;
        Rigidbody2D rb = benji.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(3, 4);
        rb.gravityScale = 1;
    }



    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartPlayingLevel()
    {
        initialMessagePanel.SetActive(false);
        Time.timeScale = 1f;
        playUI.SetActive(true);
    }

    public void OnHowToPlayButtonClick()
    {
        initialMessagePanel.SetActive(false);
        HowToPlayUI.SetActive(true);
    }

    public void OnClickOKHowToPlayButton()
    {
        HowToPlayUI.SetActive(false);
        initialMessagePanel.SetActive(true);
    }

    public void PlayCatDie()
    {
        catdie.Play();
    }

    public void PlayBenjiBark()
    {
        if (barkCount > 0 && !isGameOver)
        {
            GameObject newBarkWave = Instantiate(barkWave);
            newBarkWave.transform.position = benji.transform.position + new Vector3(.5f, 0, 0);
            BarkScript barkScript = newBarkWave.GetComponent<BarkScript>();
            barkScript.initialXPos = newBarkWave.transform.position.x;
            benjibark.Play();
            barkCount--;
            barkCountText.text = barkCount.ToString();
        }
    }

    public void ClearLevel()
    {
        if (SceneManager.GetActiveScene().name.Equals("Level_01"))
        {
            PlayerPrefs.SetInt("reachedLevel", 2);
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level_02"))
        {
            PlayerPrefs.SetInt("reachedLevel", 3);
        }

        SceneManager.LoadScene(3);
    }

    public void OnClickPauseButton()
    {
        //backgroundMusic.Stop();
        backgroundMusic.Pause();
        Time.timeScale = 0f;
        //gameOverPanel.SetActive(true);
        pausePanel.SetActive(true);
        benji.GetComponent<BenjiControls>().enabled = false;


    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }

    public void OnClickResumeButton()
    {
        pausePanel.SetActive(false);
        backgroundMusic.UnPause();
        Time.timeScale = 1f;
        benji.GetComponent<BenjiControls>().enabled = true;
    }

}
