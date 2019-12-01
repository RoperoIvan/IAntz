using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{

	public class ISeeEnemies : ConditionTask{
		protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck(){
            bool ret = false;
            if (agent.gameObject.GetComponent<AIPerceptionManager>().player_detected)
                ret = true;

            return ret;
            //return false;
		}
	}
}