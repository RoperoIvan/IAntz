using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions{

	public class Is_there_food : ConditionTask{
        public BBParameter<int> current_food;

		protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck(){
            if (current_food.value > 0)
                return true;
            else
                return false;
		}
	}
}