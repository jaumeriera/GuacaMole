using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip AvocadoHit;
    public AudioClip MiniMoleHit;
    public AudioClip MoleHit;
    public AudioClip MoleKingHit;
    public AudioClip GroundHit;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
    }

    private void DoPlay(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
    }

    public void AvocadoSound()
    {
        DoPlay(AvocadoHit);
    }

    public void MiniMoleSound()
    {
        DoPlay(MiniMoleHit);
    }

    public void MoleSound()
    {
        DoPlay(MoleHit);
    }

    public void MoleKingSound()
    {
        DoPlay(MoleKingHit);
    }

    public void GroundSound()
    {
        DoPlay(GroundHit);
    }
}
