using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackHandler : MonoBehaviour
{
    public Sprite[] attack;
    public Image attack_img;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attack_img.sprite = attack[GetComponent<AttackManager>().current_attack];
    }
}
