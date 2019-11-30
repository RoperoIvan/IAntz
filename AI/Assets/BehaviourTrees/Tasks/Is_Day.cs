using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions{

	public class Is_Day : ConditionTask{
        public BBParameter<bool> day;

		protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck(){
            if (day.value)
            {
                return true;
            }
            else
                return false;
		}
	}
}