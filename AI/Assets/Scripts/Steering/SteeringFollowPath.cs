using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class SteeringFollowPath : SteeringAbstract
{

	Move move;
	SteeringSeek seek;
    SteeringAlign align;

    public BGCcMath Path;
    public float ratio_increment = 0.1f;
    public float min_distance = 1.0f;
    public  float current_ratio = 0.0f;
    private Vector3 path_point;
    public float current_path_pos = 0.0f;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
		seek = GetComponent<SteeringSeek>();
        align = GetComponent<SteeringAlign>();

        // TODO 1: Calculate the closest point from the tank to the curve
        path_point = Path.CalcPositionByClosestPoint(this.transform.position, out current_path_pos);
        
	}
	
	// Update is called once per frame
	void Update () 
	{
        float total_path = Path.GetDistance();
        Vector3 current_dist = path_point - this.transform.position;
        

        if (current_dist.magnitude <= min_distance)
        {
            Path.CalcPositionByClosestPoint(this.transform.position, out current_path_pos);
            current_ratio = current_path_pos / total_path;
            current_ratio += ratio_increment;
            path_point = Path.CalcPositionByDistanceRatio(current_ratio);
        }

        align.DrivetoTarget(path_point, priority);

	}

	void OnDrawGizmosSelected() 
	{

		if(isActiveAndEnabled)
		{
			// Display the explosion radius when selected
			Gizmos.color = Color.green;
			// Useful if you draw a sphere were on the closest point to the path
		}

	}
}
