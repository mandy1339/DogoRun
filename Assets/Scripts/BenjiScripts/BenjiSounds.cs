using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenjiSounds : MonoBehaviour
{
    private AudioSource[] mysounds;
    private AudioSource bark;
    private AudioSource cry;
    private AudioSource jump;
    private AudioSource land;


    // Start is called before the first frame update
    void Start()
    {
        mysounds = GetComponents<AudioSource>();
        jump = mysounds[0];
        land = mysounds[1];
        bark = mysounds[2];
        cry = mysounds[3];
    }




    public void PlayJump()
    {
        jump.Play();
    }

    public void PlayLand()
    {
        land.Play();
    }

    public void PlayBark()
    {
        bark.Play();
    }

    public void PlayCry()
    {
        cry.Play();
    }
}
