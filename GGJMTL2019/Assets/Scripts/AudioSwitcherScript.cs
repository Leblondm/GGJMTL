using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class AudioSwitcherScript : MonoBehaviour
{
    private Scene musicScene;
    private AudioSource normalWorldAudio;
    private AudioSource darkWorldAudio;
    void Start()
    {
        normalWorldAudio = GameObject.FindGameObjectWithTag("normal_world_audio").GetComponent<AudioSource>();
        darkWorldAudio = GameObject.FindGameObjectWithTag("dark_world_audio").GetComponent<AudioSource>();
    }

    private bool previousWorldMode = GameManager.Instance.isNormalWorld;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.isNormalWorld != previousWorldMode) {
            if (GameManager.Instance.isNormalWorld)
            {
                normalWorldAudio.timeSamples = darkWorldAudio.timeSamples;
                normalWorldAudio.volume = 1;
                darkWorldAudio.volume = 0;
            } else {
                darkWorldAudio.timeSamples = normalWorldAudio.timeSamples;
                normalWorldAudio.volume = 0;
                darkWorldAudio.volume = 1;
            }
            previousWorldMode = GameManager.Instance.isNormalWorld;

        }
    }
}
