using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace AI{

	public class Is_food_ava : ActionTask{
        BBParameter<int> current_food;

        protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
			EndAction(true);
		}

		protected override void OnUpdate(){
            if (current_food.value > 0)
                EndAction(true);
            else
                EndAction(false);
        }

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}