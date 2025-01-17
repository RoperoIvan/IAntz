﻿using UnityEngine;
using System.Collections;

public class KinematicArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float time_to_target = 0.25f;

	Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
		Vector3 diff = move.target.transform.position - transform.position;

		if(diff.magnitude < min_distance)
			move.SetMovementVelocity(Vector3.zero, 0);

		diff /= time_to_target;

		move.SetMovementVelocity(diff, 0);
	}

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);
	}
}
