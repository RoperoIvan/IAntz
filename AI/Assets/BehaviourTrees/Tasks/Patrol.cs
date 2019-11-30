using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

namespace AI{

	public class Patrol : ActionTask{
        public GameObject daycicle;
        public BGCcMath Path_day;
        public BGCcMath Path_night;
        public BGCurve curve_day;
        public BGCurve curve_night;
        protected override string OnInit(){
            agent.gameObject.GetComponent<SteeringFollowPath>().Path_day = Path_day;
            agent.gameObject.GetComponent<SteeringFollowPath>().Path_night= Path_night;
            agent.gameObject.GetComponent<SteeringFollowPath>().curve_day = curve_day;
            agent.gameObject.GetComponent<SteeringFollowPath>().curve_night = curve_night;
            return null;
		}

		protected override void OnExecute(){
            //agent.gameObject.GetComponent<UnityEngine.AI.>().ResetPath();
            agent.gameObject.GetComponent<SteeringFollowPath>().enabled = true;

            if (daycicle.GetComponent<Day_night>().day)
            {
                agent.gameObject.GetComponent<SteeringFollowPath>().actcurve = curve_day;
                agent.gameObject.GetComponent<SteeringFollowPath>().actpath = Path_day;
            }
            else
            {
                agent.gameObject.GetComponent<SteeringFollowPath>().actcurve = curve_night;
                agent.gameObject.GetComponent<SteeringFollowPath>().actpath = Path_night;
            }
            //EndAction(true);
        }

		protected override void OnUpdate(){
			

        }

		protected override void OnStop(){
            agent.gameObject.GetComponent<SteeringFollowPath>().enabled = false;
        }

		protected override void OnPause(){
			
		}
	}
}