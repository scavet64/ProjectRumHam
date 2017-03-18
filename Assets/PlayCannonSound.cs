using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCannonSound : MonoBehaviour {

    public AudioClip[] CannonSounds;
    private AudioSource audiosouce;

	// Use this for initialization
	void Start () {
        audiosouce = GetComponent<AudioSource>();
        PlayRandomSound();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayRandomSound() {
        audiosouce.clip = CannonSounds[(int)Random.Range(0, 2)];
        audiosouce.Play();
    }
}
