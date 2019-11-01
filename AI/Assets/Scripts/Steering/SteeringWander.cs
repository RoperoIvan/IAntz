using UnityEngine;
using System.Collections;

public class SteeringWander : MonoBehaviour {

	public float min_distance = 0.1f;
	public float time_to_target = 0.25f;

	Move move;
    SteeringArrive arrive;
    Vector3 vec_random_destination;
    // Use this for initialization


    void Start()
    {
        move = GetComponent<Move>();
        arrive = GetComponent<SteeringArrive>();
        vec_random_destination = new Vector3(Random.Range(-10.0f, 10.0f), transform.position.y, Random.Range(-10.0f, 10.0f));
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, vec_random_destination) < 1)
        {
            vec_random_destination = new Vector3(Random.Range(-10.0f, 10.0f), transform.position.y, Random.Range(-10.0f, 10.0f));
        }
        arrive.Steer(vec_random_destination);
    }

    void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);
	}
}
