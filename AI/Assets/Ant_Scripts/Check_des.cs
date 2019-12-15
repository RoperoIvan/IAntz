using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace IAntz{

	public class Check_des : ActionTask{
        public BBParameter<bool> daycicle;


        Move move;
        protected override string OnInit()
        {
            move = agent.gameObject.GetComponent<Move>();
            return null;
        }

        protected override void OnExecute()
        {
            agent.gameObject.GetComponent<SteeringFollowPath>().enabled = true;
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnStop()
        {
            agent.gameObject.GetComponent<SteeringFollowPath>().enabled = false;

            for (int i = 0; i < move.movement_velocity.Length; i++)
            {
                move.movement_velocity[i] = Vector3.zero;
                move.current_velocity = Vector3.zero;
            }
            for (int i = 0; i < move.angular_velocity.Length; i++)
            {
                move.angular_velocity[i] = 0;
                move.current_rotation_speed = 0;
            }
        }

        protected override void OnPause(){
			
		}
	}
}