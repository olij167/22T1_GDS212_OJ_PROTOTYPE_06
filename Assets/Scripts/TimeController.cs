using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public float startTimeHours, startTimeMinutes, startTimeSeconds, lateTimeHours, lateTimeMinutes, lateTimeSeconds;
    [HideInInspector] public float timeHours, timeMinutes, timeSeconds, lateTimer;

    public AudioSource narratorAudioSource;

    public AudioClip lateForWorkVO;

    public bool lateAudioPlayed;

    public TextMeshProUGUI timeText, lateForWorkText, workStartText;

    void Start()
    {
        timeHours = startTimeHours;
        timeMinutes = startTimeMinutes;
        timeSeconds = startTimeSeconds;

        lateForWorkText.enabled = false;

        workStartText.text = "Work starts at " + lateTimeHours.ToString("00") + ":" + lateTimeMinutes.ToString("00") + " am";

    }

    void Update()
    {

        if (timeHours < 12f)
        {
            timeText.text = timeHours.ToString("00") + ":" + timeMinutes.ToString("00") + ":" + timeSeconds.ToString("00") + " am";
        }
        else
        {
            timeText.text = timeHours.ToString("00") + ":" + timeMinutes.ToString("00") + ":" + timeSeconds.ToString("00") + " pm";
        }

        timeSeconds += Time.deltaTime;

        if (timeSeconds >= 59f)
        {
            timeMinutes++;
            timeSeconds = 0f;
        }

        if (timeMinutes >= 59f)
        {
            timeHours++;
            timeMinutes = 0f;
        }

        if (timeHours >= lateTimeHours && timeMinutes >= lateTimeMinutes && !lateAudioPlayed)
        {
            if (narratorAudioSource.isPlaying)
            {
                narratorAudioSource.Stop();
            }

            if (!narratorAudioSource.isPlaying)
            {
                narratorAudioSource.PlayOneShot(lateForWorkVO);
                lateForWorkText.enabled = true;

                lateAudioPlayed = true;
            }

        }

        if (lateAudioPlayed)
        {
            lateTimer += Time.deltaTime;
        }

        
    }
}
