using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI mText;
    float time = 0f;
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
        mText.text=time.ToString("0.00");
    }
}
