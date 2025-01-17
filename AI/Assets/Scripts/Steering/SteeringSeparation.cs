﻿using UnityEngine;
using System.Collections;

public class SteeringSeparation : SteeringAbstract
{

	public LayerMask mask;
	public float search_radius = 2.0f;
	public AnimationCurve strength;
    public Vector3 vec_res;



    Move move;
    SteeringAlign align;

    // Use this for initialization
    void Start () {
		move = GetComponent<Move>();
        align = GetComponent<SteeringAlign>();
    }
	
	// Update is called once per frame
	void Update () 
	{
        // TODO 1: Agents much separate from each other:
        // 1- Find other agents in the vicinity (use a layer for all agents)
        // 2- For each of them calculate a escape vector using the AnimationCurve
        // 3- Sum up all vectors and trim down to maximum acceleration

        vec_res = Vector3.zero;
        Vector3 vec_helper = Vector3.zero;
        Collider[] nearby_tanks = Physics.OverlapSphere(this.transform.position, search_radius, mask);

   

        foreach (Collider col in nearby_tanks)
        {
            vec_helper = -(col.transform.position - this.transform.position);
            
            float str = strength.Evaluate(Mathf.Abs(vec_helper.magnitude));
            vec_helper.Normalize();
            vec_helper *= 0.1f;
            vec_res += vec_helper;
        }

        if (vec_res != Vector3.zero)
        {
            vec_res += transform.position;
            align.DrivetoTarget(vec_res, priority);
        }
	}

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, search_radius);
	}
}
