using System;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI mText;
    float time = 0f;
    TimeSpan timer;
    // Start is called before the first frame update
    void Start()
    {
        mText = gameObject.GetComponent<TextMeshProUGUI>();
        mText.text="yoooo";
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        timer=TimeSpan.FromSeconds(time);
        mText.text=timer.ToString("mm':'ss'.'ff");
    }
}
