using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace AI{

	public class SecretPheromones : ActionTask{

		protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
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