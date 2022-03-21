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
        if (other.gameObject.CompareTag("Player"))
        {

            if (narrator.isPlaying)
            {
                narrator.Stop();
            }

            if (!narrator.isPlaying && !motherDuckReached)
            {
                narrator.PlayOneShot(reunitedWithMotherAudio);
            }

            motherDuckReached = true;
        }
    }
}
