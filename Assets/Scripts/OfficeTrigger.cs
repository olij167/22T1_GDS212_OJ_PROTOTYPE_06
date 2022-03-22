using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OfficeTrigger : MonoBehaviour
{
    public GameObject endGameUI;

    AudioSource narrator;

    public AudioClip arrivedOnTimeAudio, arrivedLateAudio;

    MotherDuckTrigger motherDuck;

    public TimeController time;

    public TextMeshProUGUI endGameText, attendanceText;

    public Image endingImage;

    public Sprite goodEndingImage, badEndingImage;

    private void Start()
    {
        endGameUI.SetActive(false);

        motherDuck = GameObject.FindGameObjectWithTag("MotherDuck").GetComponent<MotherDuckTrigger>();

        narrator = GameObject.FindGameObjectWithTag("Narrator").GetComponent<AudioSource>();

        //attendanceText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (motherDuck.motherDuckReached)
            {
                Time.timeScale = 0f;
                //other.GetComponent<CharacterController>().enabled = false;
                other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                endGameUI.SetActive(true);
                
                if (time.lateForWorkText.enabled)
                {
                    LateTime();

                    if (narrator.isPlaying)
                    {
                        narrator.Stop();
                    }

                    endGameText.text = "Mike saved the duckling but he arrived to work late..." + "\n" + "Next he time he better make it by " + time.lateTimeHours.ToString("00") + ":" + time.lateTimeMinutes.ToString("00");
                    endingImage.sprite = badEndingImage;

                    if (!narrator.isPlaying)
                    {
                        narrator.PlayOneShot(arrivedLateAudio);
                    }
                }
                else
                {
                    EarlyTime();

                    if (narrator.isPlaying)
                    {
                        narrator.Stop();
                    }

                    endGameText.text = "Mike saved the duckling and arrived to work on time!" + "\n" + "Way to go Mike!";
                    endingImage.sprite = goodEndingImage;


                    if (!narrator.isPlaying)
                    {
                        narrator.PlayOneShot(arrivedOnTimeAudio);
                    }



                }
            }
        }
    }

    public void EarlyTime()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        if (time.timeHours <= time.startTimeHours && time.timeMinutes <= time.startTimeMinutes)
        {
            attendanceText.text = "Mike was early by " + (time.startTimeHours - time.timeHours).ToString("00") + " hours, " + (time.startTimeMinutes - time.timeMinutes).ToString("00") + " minutes and " + (time.startTimeSeconds - time.timeSeconds).ToString("00") + " seconds";

        }
    }

    public void LateTime()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (time.lateTimer >= 0f)
        {
            if (time.lateTimer < 60f)
            {
                attendanceText.text = "(by " + time.lateTimer.ToString("00") + " seconds)";
            }

            if (time.lateTimer >= 60f)
            {
                attendanceText.text = "(by " + (time.lateTimer / 60f).ToString("00:00") + " minutes)";

            }

        }
    }


    //if (lateForWorkText.enabled == true)
    //{

    //    if (lateTimeHours == 0f && lateTimeMinutes == 0f)
    //    {
    //        timeLateText.text = "by " +  (timeSeconds - lateTimeSeconds).ToString("00") + " seconds";

    //    }

    //    if (lateTimeHours == 0f && lateTimeMinutes > 0f)
    //    {
    //        timeLateText.text = "by " + (timeMinutes - lateTimeMinutes).ToString("00") + " minutes, and " + (timeSeconds - lateTimeSeconds).ToString("00") + " seconds";

    //    }  

    //    if (lateTimeHours > 0f)
    //    {
    //        timeLateText.text = "by " + (timeHours - lateTimeHours).ToString("00") + " hours, " +  (timeMinutes - lateTimeMinutes).ToString("00") + " minutes," + "\n" + "and " + (timeSeconds - lateTimeSeconds).ToString("00") + " seconds";

    //    }
    //}
}
