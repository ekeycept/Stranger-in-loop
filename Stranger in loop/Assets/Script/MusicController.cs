using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioTrack;
    [SerializeField] private AudioClip[] Tracks;
    int trackNumber = 0;
    void Start()
    {
        audioTrack = GetComponent<AudioSource>(); 
    }
    private void Update()
    {
        if(audioTrack.isPlaying == false)
        {
            audioTrack.clip = Tracks[trackNumber];
            audioTrack.Play();
        }
        if (trackNumber > 0)
            audioTrack.clip = Tracks[1];
        if (trackNumber == 0)
            audioTrack.clip = Tracks[0];
        if (trackNumber > 1)
            trackNumber = 1;
        if (trackNumber < 0)
            trackNumber = 0;

    }

    public void NextTrack()
    {
        trackNumber++;
        Debug.Log("New track!");
    }
    
    public void PreviousTrack()
    {
        Debug.Log("Last track!");
        trackNumber--;
    }
}
