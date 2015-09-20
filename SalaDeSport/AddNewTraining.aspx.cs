using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
namespace SalaDeSport
{
    public partial class AddNewTraining : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) Response.Redirect("Login.aspx");
            AddExercices();

        }
        protected void AddExercices()
        {
            List<TypeOfExercicies> List = ConnectionClass.GetTypeOfExercices();
            foreach (TypeOfExercicies Ex in List)
            {
                WrTypeOfExercices.Items.Add(new ListItem(Ex.GetExName(), Ex.GetId().ToString()));
                SkTypeOfExercices.Items.Add(new ListItem(Ex.GetExName(), Ex.GetId().ToString()));
                WodTypeOfExercicies.Items.Add(new ListItem(Ex.GetExName(), Ex.GetId().ToString()));
            }

        }
        protected void SubmitClick(object sender, EventArgs e)
        {
            UserClass Usr = (UserClass)Session["User"];
            int Time = Convert.ToInt32(HourOT.Value);
            string Day = DayOfTheWeek.SelectedValue.ToString();
            string Name = "TrainingName";
            Name = NameOfTraining.Value.ToString();
            int WarmingNumberOfSets = Convert.ToInt32(WrNOS.Value);
            int WarmingNumverOfExercices = Convert.ToInt32(WrNOE.Value);
            int WarmingExerciceId = Convert.ToInt32(WrTypeOfExercices.SelectedValue);
            int SkillNumberOfSets = Convert.ToInt32(SkNOS.Value);
            int SkillNumberOfExercices = Convert.ToInt32(SkNOE.Value);
            int SkillExerciceId = Convert.ToInt32(SkTypeOfExercices.SelectedValue);
            int WodNumberOfSets = Convert.ToInt32(WodNOS.Value);
            int WodNumberOfExercices = Convert.ToInt32(WodNOE.Value);
            int WodExerciceId = Convert.ToInt32(WodTypeOfExercicies.SelectedValue);

            TrainingClass NewTraining = new TrainingClass(Usr.GetId(), Name, Day, Time);
            if (ConnectionClass.IsFree(NewTraining))
            {
                ConnectionClass.InsertNewTraining(NewTraining);
                int id = ConnectionClass.GetTrainingIdFromDB(NewTraining);
                NewTraining.SetId(id);
                StagesClass Warming = new StagesClass(WarmingNumberOfSets, WarmingNumverOfExercices, WarmingExerciceId, NewTraining.GetTrainingId(), "Warming");
                StagesClass Skill = new StagesClass(SkillNumberOfSets, SkillNumberOfExercices, SkillExerciceId, NewTraining.GetTrainingId(), "Skill");
                StagesClass Wod = new StagesClass(WodNumberOfSets, WodNumberOfExercices, WodExerciceId, NewTraining.GetTrainingId(), "Wod");
                ConnectionClass.InsertStage(Warming);
                ConnectionClass.InsertStage(Skill);
                ConnectionClass.InsertStage(Wod);
                Response.Redirect("Program.aspx");

            }
            else
            { VforTime.Visible = true; }
        }

        protected void AddExerciseButtonClick(object sender, EventArgs e)
        {
            if (NewExerciceName.Value.ToString() != "")
            {
                TypeOfExercicies Ex = new TypeOfExercicies(NewExerciceName.Value.ToString());
                if (!ConnectionClass.ExerciceExists(Ex))
                {
                    ConnectionClass.AddNewExercice(Ex);

                }
                Response.Redirect(Request.RawUrl);

            }
        }
    }
}