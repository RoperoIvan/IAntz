using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoodHandler : MonoBehaviour
{
    public Sprite[] mood;
    public Image mood_img;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mood_img.sprite = mood[GetComponent<MoodManager>().current_mood];
    }
}
