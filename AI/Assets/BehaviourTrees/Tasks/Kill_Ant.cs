using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace AI{

	public class Kill_Ant : ActionTask{

        KillAnt killer;
        protected override string OnInit(){
            killer = new KillAnt();
            return null;
		}

		protected override void OnExecute(){          
            killer.Kill(agent.gameObject);
            
            EndAction(true);
		}

		protected override void OnUpdate(){
			
		}

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}