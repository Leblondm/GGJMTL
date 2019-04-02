using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcherScript : MonoBehaviour
{
    private AudioSource normalWorldAudio;
    private AudioSource darkWorldAudio;

    void Start()
    {
        normalWorldAudio = GameObject.FindGameObjectWithTag("normal_world_audio").GetComponent<AudioSource>();
        darkWorldAudio = GameObject.FindGameObjectWithTag("dark_world_audio").GetComponent<AudioSource>();
    }

    private bool? previousWorldMode = null;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.isNormalWorld != previousWorldMode) {
            if (GameManager.Instance.isNormalWorld)
            {
                normalWorldAudio.volume = 0.50f;
                darkWorldAudio.volume = 0;
            } else {
                normalWorldAudio.volume = 0;
                darkWorldAudio.volume = 0.50f;
            }
            previousWorldMode = GameManager.Instance.isNormalWorld;

        }
    }
}
