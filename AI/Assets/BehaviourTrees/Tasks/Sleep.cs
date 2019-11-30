using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace AI{

	public class Sleep : ActionTask{
        Animator m_Animator;
        public BBParameter<GameObject> my_ant;


        protected override string OnInit(){
            m_Animator = my_ant.value.GetComponent<Animator>();

            return null;
        }

		protected override void OnExecute(){
            m_Animator.SetBool("Movement", false);
		}

		protected override void OnUpdate(){
			
		}

		protected override void OnStop(){
            m_Animator.SetBool("Movement", true);
        }

		protected override void OnPause(){
			
		}
	}
}