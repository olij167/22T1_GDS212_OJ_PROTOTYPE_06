using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    //public float waterDrag, originalDrag;

    public GameObject player;

    RespawnOnLand playerRespawn;

    public AudioSource narratorAudioSource;

    AudioSource waterSplashSource;

    public List<AudioClip> splashSounds;

    public List<AudioClip> waterVOClips;

    int count = 0;

    bool waterVOPlayed;

    private void Start()
    {
        playerRespawn = player.GetComponent<RespawnOnLand>();
        waterSplashSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRespawn.inWater = true;

            waterSplashSource.PlayOneShot(splashSounds[Random.Range(0, splashSounds.Count)]); // << play a random splash sound effect from the list

            if (count + 1 <= waterVOClips.Count)
            {
                PlayWaterNarrative();
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRespawn.inWater = false;

        }
    }

    void PlayWaterNarrative()
    {
        if (!narratorAudioSource.isPlaying && !waterVOPlayed)
        {
            narratorAudioSource.PlayOneShot(waterVOClips[count]);
            waterVOPlayed = true;
        }

        if (!narratorAudioSource.isPlaying && waterVOPlayed)
        {
            if (count + 1 <= waterVOClips.Count)
            {
                count++;
            }
            waterVOPlayed = false;
        }
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        //originalDrag = other.GetComponent<Rigidbody>().drag;

    //        //other.GetComponent<Rigidbody>().useGravity = false;

    //        //other.GetComponent<Rigidbody>().drag *= waterDrag;

    //        //other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
    //        ////other.GetComponent<Rigidbody>().AddRelativeForce(Vector3.down, ForceMode.Force);
    //        //other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.ForwardSpeed -= speedDecreaseAmount;
    //        //other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.BackwardSpeed -= speedDecreaseAmount;
    //        //other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.StrafeSpeed -= speedDecreaseAmount;
    //        //other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.CurrentTargetSpeed -= speedDecreaseAmount;
    //        ////other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.JumpForce += jumpIncreaseAmount;



    //    }
    //} 
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        //other.GetComponent<Rigidbody>().useGravity = true;
    //        //other.GetComponent<Rigidbody>().drag = originalDrag;

    //        //other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.ForwardSpeed -= speedDecreaseAmount;
    //        //other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.BackwardSpeed -= speedDecreaseAmount;
    //        //other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.StrafeSpeed -= speedDecreaseAmount;
    //        //other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.CurrentTargetSpeed -= speedDecreaseAmount;
    //        ////other.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().movementSettings.JumpForce -= jumpIncreaseAmount;

    //    }
    //}
}
