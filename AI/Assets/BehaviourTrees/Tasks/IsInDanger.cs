using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions{

	public class IsInDanger : ConditionTask{

		protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck(){
            bool ret = false;

            if (agent.gameObject.GetComponent<HealthManager>().current_health <= 2)
                ret = true;

            return ret;
		}
	}
}