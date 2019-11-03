using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class SteeringFollowPath : SteeringAbstract
{
    public GameObject UI;
    Move move;
	SteeringSeek seek;
    SteeringAlign align;

    public int type;
    public BGCcMath Path_day;
    public BGCcMath Path_night;
    BGCcMath actpath;
    public BGCurve curve_day;
    public BGCurve curve_night;
    BGCurve actcurve;
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
        actpath = Path_day;
        actcurve = curve_day;
        // TODO 1: Calculate the closest point from the tank to the curve
        path_point = actpath.CalcPositionByClosestPoint(this.transform.position, out current_path_pos);
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (UI.GetComponent<Day_night>()._update)
        {
            if (UI.GetComponent<Day_night>().day)
            {
                actpath = Path_day;
                actcurve = curve_day;

            }
            else
            {
                actpath = Path_night;
                actcurve = curve_night;
            }
            path_point = actpath.CalcPositionByClosestPoint(this.transform.position, out current_path_pos);
        }
           

        float total_path = actpath.GetDistance();
        Vector3 current_dist = path_point - this.transform.position;

        if (current_dist.magnitude <= min_distance)
        {
            actpath.CalcPositionByClosestPoint(this.transform.position, out current_path_pos);
            current_ratio = current_path_pos / total_path;
            current_ratio += ratio_increment;
            if(actcurve.Closed)
            {
                if (current_ratio >= 1)
                {
                    if (type == 2)
                    {
                        UI.GetComponent<Day_night>().Add_food(10);
                    }
                    if (type == 0)
                    {
                        UI.GetComponent<Day_night>().Add_materials(10);
                    }
                    current_ratio = 0.01f;

                }                    
            }
            path_point = actpath.CalcPositionByDistanceRatio(current_ratio);
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
