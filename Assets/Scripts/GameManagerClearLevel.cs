using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerClearLevel : MonoBehaviour
{
    private AudioSource wellDone;
    // Start is called before the first frame update
    void Start()
    {
        wellDone = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickContinue()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickSaveQuit()
    {
        Application.Quit();
    }
}
