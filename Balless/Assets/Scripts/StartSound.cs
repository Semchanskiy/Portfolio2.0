using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
    private AudioSource _startSound;
    void Start()
    {
        _startSound = GetComponent<AudioSource>();
    }

    public void PlayClip()
    {
        _startSound.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
