using UnityEngine;
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
	private Ray ray;

	// Use this for initialization
	void Start () {

		ray = new Ray();
	}
	
	// Update is called once per frame
	void Update () {
        current_enemy = null;


		Collider[] colliders = Physics.OverlapSphere(transform.position, frustum.farClipPlane, mask);

		foreach(Collider col in colliders)
		{
			if(col.gameObject != gameObject && GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(frustum), col.bounds))
			{
                ray.origin = transform.position;
				ray.direction = (col.transform.position - transform.position).normalized;
				ray.origin = ray.GetPoint(frustum.nearClipPlane);

            	if(Physics.Raycast(ray, frustum.farClipPlane, ray_mask) == false)
                {
                    if(current_enemy == null)
                        current_enemy = col.gameObject;
                }
			}
		}

		
	}
}
