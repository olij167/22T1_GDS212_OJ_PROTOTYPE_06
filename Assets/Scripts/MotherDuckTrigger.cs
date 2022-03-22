using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherDuckTrigger : MonoBehaviour
{
    [HideInInspector] public AudioSource narrator;

    public AudioClip reunitedWithMotherAudio;

    public bool motherDuckReached;

    private void Start()
    {
        narrator = GameObject.FindGameObjectWithTag("Narrator").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !motherDuckReached)
        {

            if (narrator.isPlaying)
            {
                narrator.Stop();
            }

            if (!narrator.isPlaying)
            {
                narrator.PlayOneShot(reunitedWithMotherAudio);
            }

            motherDuckReached = true;
        }
    }
}
