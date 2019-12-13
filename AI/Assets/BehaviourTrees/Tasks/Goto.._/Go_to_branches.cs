using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;


namespace AI{

	public class Go_to_branches : ActionTask{

        public BBParameter<GameObject> nearby_branches;
        public BBParameter<bool> on_resource_branches;
        public BBParameter<GameObject> my_ant;


        public BBParameter<int> my_load;
        SteeringAlign align;
        Move move;
        float timer;

        protected override string OnInit()
        {
            align = my_ant.value.GetComponent<SteeringAlign>();
            move = my_ant.value.GetComponent<Move>();
            return null;
        }

        protected override void OnExecute()
        {
            agent.gameObject.GetComponent<ChangingResourceManager>().current_resource_state = 0;
            agent.gameObject.GetComponent<ChangingResourceManager>().current_wanted_resource = 0;
            timer = Time.time;
        }

        protected override void OnUpdate()
        {
            float time_now = Time.time;
            if(time_now - timer >= 2)
            {
                agent.gameObject.GetComponent<ChangingResourceManager>().current_resource_state = 2;
                agent.gameObject.GetComponent<ChangingResourceManager>().current_wanted_resource = 2;
                align.DrivetoTarget(nearby_branches.value.transform.position, 3);
                if (on_resource_branches.value)
                {
                    my_load.value = 3;
                    EndAction(true);
                }
            }
            else
                agent.gameObject.GetComponent<ChangingResourceManager>().current_resource_state = 1;

        }

        protected override void OnStop()
        {
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