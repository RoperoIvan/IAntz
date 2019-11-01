using UnityEngine;
using System.Collections;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class Followcurve : MonoBehaviour
{
    // Start is called before the first frame update
    public BGCcMath c_path;
    private float distance;
    public float all_dist;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance += 0.1f * Time.deltaTime;
        Vector3 new_pos = c_path.CalcByDistanceRatio(BGCurveBaseMath.Field.Position, distance);
        transform.position = new_pos;

    }
}
