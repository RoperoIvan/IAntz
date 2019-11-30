using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace AI{

	public class FleeFromEnemy : ActionTask{

        //public BBParameter<GameObject> my_ant;
        //public BBParameter<GameObject> my_enemie;

        SteeringAlign align;
        Move move;

        protected override string OnInit()
        {
            align = agent.gameObject.GetComponent<SteeringAlign>();
            move = agent.gameObject.GetComponent<Move>();
            return null;
        }

        protected override void OnExecute()
        {

        }

        protected override void OnUpdate()
        {
            Vector3 dir = agent.gameObject.GetComponent<PheromonesSecrete>().enemy.transform.position - agent.gameObject.transform.position;
            Vector3 dist = dir.normalized;
            dist = -dist;

            if (dir.magnitude >= 9.0f)
                EndAction(true);
            else
                align.DrivetoTarget(dist, 3);

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

        protected override void OnPause()
        {

        }
    }
}