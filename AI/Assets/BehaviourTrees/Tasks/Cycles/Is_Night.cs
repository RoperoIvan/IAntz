using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace AI{

	public class Is_Night : ActionTask{
        public BBParameter<bool> day;



        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {

        }

        protected override void OnUpdate()
        {
            if (day.value == true)
            {
                EndAction(false);
            }
        }

        protected override void OnStop()
        {

        }

        protected override void OnPause()
        {

        }
    }
}