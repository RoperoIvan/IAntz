﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class FSM_Alarm : MonoBehaviour {
    private bool player_detected = false;
    private bool in_alarm = false;
    private Vector3 patrol_pos;

    public GameObject alarm;
    public BansheeGz.BGSpline.Curve.BGCurve path;
    private bool finished = true;

    private IEnumerator decision;

    delegate IEnumerator rOLL();
    private rOLL roo;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == alarm)
            in_alarm = true;
    }

    // Update is called once per frame
    void PerceptionEvent(PerceptionEvent ev)
    {
        if (ev.type == global::PerceptionEvent.types.NEW)
        {
            player_detected = true;
        }
    }

    // TODO 1: Create a coroutine that executes 20 times per second
    // and goes forever. Make sure to trigger it from Start()

    // Use this for initialization
    void Start()
    {
        roo = Test;
        StartCoroutine(roo());
        StartCoroutine(roo());
        StartCoroutine(roo());
    }

    private IEnumerator Test()
    {
        while (true)
        {
            Debug.Log("lololoolololol");
            yield return new WaitForSeconds(1.0f);
        }
    }

    private IEnumerator First()
    {
        Debug.Log("entering Patrol");
        while (true)
        {
            if (player_detected && finished)
            {
                
                StartCoroutine("Second");
                finished = false;
                player_detected = false;
            }

            yield return new WaitForSeconds(1.0f / 20.0f);
        }
    }

    private IEnumerator Second()
    {
        patrol_pos = this.gameObject.transform.position;
        path.gameObject.SetActive(false);

        while (!in_alarm)
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().destination = alarm.transform.position;

            yield return new WaitForSeconds(1.0f / 20.0f);
        }
        StartCoroutine("Third");
        in_alarm = false;
    }


    // TODO 2: If player is spotted, jump to another coroutine that should
    // execute 20 times per second waiting for the player to reach the alarm

    private IEnumerator Third()
    {
        while (this.transform.position.x != patrol_pos.x && this.transform.position.z != patrol_pos.z)
        {
            GetComponent<UnityEngine.AI.NavMeshAgent>().destination = patrol_pos;
            yield return new WaitForSeconds(1.0f / 20.0f);
        }
        GetComponent<UnityEngine.AI.NavMeshAgent>().ResetPath();
        path.gameObject.SetActive(true);
        
        finished = true;
    }


    // TODO 3: Create the last coroutine to have the tank waiting to reach
    // the point where he left the path, and trigger again the patrol



}