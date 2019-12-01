using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

namespace AI{

	public class AntPatrol : ActionTask{
        public GameObject daycicle;
        public BBParameter<BGCcMath> Path_day;
        public BBParameter<BGCcMath> Path_night;
        public BBParameter<BGCurve> curve_day;
        public BBParameter<BGCurve> curve_night;
        protected override string OnInit(){
            return null;
		}

		protected override void OnExecute(){
            agent.gameObject.GetComponent<SteeringFollowPath>().enabled = true;

            if (daycicle.GetComponent<Day_night>().day)
            {
                agent.gameObject.GetComponent<SteeringFollowPath>().actcurve = curve_day.value;
                agent.gameObject.GetComponent<SteeringFollowPath>().actpath = Path_day.value;
            }
            else
            {
                agent.gameObject.GetComponent<SteeringFollowPath>().actcurve = curve_night.value;
                agent.gameObject.GetComponent<SteeringFollowPath>().actpath = Path_night.value;
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