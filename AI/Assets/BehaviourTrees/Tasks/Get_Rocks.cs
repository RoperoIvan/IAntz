using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;


namespace AI{

	public class Get_Rocks : ActionTask{

        Animator m_Animator;
        public BBParameter<GameObject> my_ant;
        float time_start;
        public BBParameter<float> time_finish;

        protected override string OnInit(){
            m_Animator = my_ant.value.GetComponent<Animator>();
            
            return null;
		}

		protected override void OnExecute(){
            m_Animator.SetBool("Collect", true);
            time_start = Time.time;
        }

		protected override void OnUpdate(){
            float timer = Time.time;
            if (timer - time_start > time_finish.value)
            {
                EndAction(true);
            }


            
		}

		protected override void OnStop(){
            m_Animator.SetBool("Collect", false);
        }

		protected override void OnPause(){
			
		}
	}
}