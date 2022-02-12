using System;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI mText;
    public float time = 0f;
    TimeSpan timer;
    public bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        mText = gameObject.GetComponent<TextMeshProUGUI>();
        mText.text="Ready to launch.";
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            time+=Time.deltaTime;
            timer=TimeSpan.FromSeconds(time);
            mText.text=timer.ToString("mm':'ss'.'ff");
        }
    }
}
