﻿using UnityEngine;
using System.Collections.Generic;

public class PerceptionEvent
{
	public enum senses { VISION, SOUND };
	public enum types { NEW, LOST };

	public GameObject go;
	public senses sense;
	public types type;
}

public class AIVision : MonoBehaviour {

	public Camera frustum;
	public LayerMask ray_mask;
	public LayerMask mask;
    public GameObject current_enemy;
	private List<GameObject> detected;
	private List<GameObject> detected_now;
	private Ray ray;

	// Use this for initialization
	void Start () {
		detected = new List<GameObject>();
		detected_now = new List<GameObject>();
		ray = new Ray();
	}
	
	// Update is called once per frame
	void Update () {
        current_enemy = null;
		Collider[] colliders = Physics.OverlapSphere(transform.position, frustum.farClipPlane, mask);

		detected_now.Clear();

		foreach(Collider col in colliders)
		{
			if(col.gameObject != gameObject && GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(frustum), col.bounds))
			{
				RaycastHit hit;
				ray.origin = transform.position;
				ray.direction = (col.transform.position - transform.position).normalized;
				ray.origin = ray.GetPoint(frustum.nearClipPlane);

            	if(Physics.Raycast(ray, out hit, frustum.farClipPlane, ray_mask) == false)
                { 
                    detected_now.Add(col.gameObject);
                    if(current_enemy == null)
                        current_enemy = col.gameObject;
                    
                }
			}
		}

		// Compare detected with detected_now -------------------------------------
		foreach(GameObject go in detected_now)
		{
			if(detected.Contains(go) == false)
			{
				PerceptionEvent p_event = new PerceptionEvent();
				p_event.go = go;
				p_event.type = PerceptionEvent.types.NEW;
	    		p_event.sense = PerceptionEvent.senses.VISION;

	    		SendMessage("PerceptionEvent", p_event);
    		}
		}

		foreach(GameObject go in detected)
		{
			if(detected_now.Contains(go) == false)
			{
				PerceptionEvent p_event = new PerceptionEvent();
				p_event.go = go;
				p_event.type = PerceptionEvent.types.LOST;
	    		p_event.sense = PerceptionEvent.senses.VISION;

	    		SendMessage("PerceptionEvent", p_event);
    		}
		}

		detected.Clear();
		detected.AddRange(detected_now);
	}
}
