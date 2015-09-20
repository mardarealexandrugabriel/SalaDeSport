using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalaDeSport
{
    public partial class EditTraining : System.Web.UI.Page
    {
        int TrainingId;
        UserClass UserC;
        TrainingClass Tr;
        StagesClass Warming;
        StagesClass Skill;
        StagesClass Wod;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["TId"] == null || !int.TryParse(Request.QueryString["TId"], out TrainingId) || !ConnectionClass.TrainingExists(TrainingId))
            {
                Response.Redirect("Program.aspx");
            }
            UserC = (UserClass)Session["User"];
            Tr = ConnectionClass.GetTrainingById(TrainingId);
            Warming = ConnectionClass.GetStageByTrainingIdAndType(Tr.GetTrainingId(), "Warming");
            Skill = ConnectionClass.GetStageByTrainingIdAndType(Tr.GetTrainingId(), "Skill");
            Wod = ConnectionClass.GetStageByTrainingIdAndType(Tr.GetTrainingId(), "Wod");
            if (Tr.GetTrainerId() != UserC.GetId())
            {
                Response.Redirect("Program.aspx");

            }
            if (!IsPostBack)
                FillPanel();



        }
        protected void FillPanel()
        {
            AddExercices();
            PanelTitle.InnerText = Tr.GetTrainingName();
            DayOfTheWeek.SelectedValue = Tr.GetTrainingDay();
            NameOfTraining.Value = Tr.GetTrainingName();
            HourOT.Value = Tr.GetHour().ToString();
            WrNOS.Value = Warming.GetNumberOfSets().ToString();
            WrNOE.Value = Warming.GetNumberOfExercices().ToString();
            WrTypeOfExercices.SelectedValue = Warming.GetTypeOfExercice().ToString();
            SkNOS.Value = Skill.GetNumberOfSets().ToString();
            SkNOE.Value = Skill.GetNumberOfExercices().ToString();
            SkTypeOfExercices.SelectedValue = Skill.GetTypeOfExercice().ToString();
            WodNOS.Value = Wod.GetNumberOfSets().ToString();
            WodNOE.Value = Wod.GetNumberOfExercices().ToString();
            WodTypeOfExercicies.SelectedValue = Wod.GetTypeOfExercice().ToString();
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

            TrainingClass NewTraining = new TrainingClass(Tr.GetTrainingId(), Name, UserC.GetId(), Day, Time);
            if (ConnectionClass.IsFree(NewTraining) || (Tr.GetTrainingDay() == DayOfTheWeek.SelectedValue.ToString() && Tr.GetHour() == Convert.ToInt32(HourOT.Value)))
            {
                ConnectionClass.UpdateTraining(NewTraining);
                StagesClass Warming = new StagesClass(WarmingNumberOfSets, WarmingNumverOfExercices, WarmingExerciceId, NewTraining.GetTrainingId(), "Warming");
                StagesClass Skill = new StagesClass(SkillNumberOfSets, SkillNumberOfExercices, SkillExerciceId, NewTraining.GetTrainingId(), "Skill");
                StagesClass Wod = new StagesClass(WodNumberOfSets, WodNumberOfExercices, WodExerciceId, NewTraining.GetTrainingId(), "Wod");
                ConnectionClass.UpdateStage(Warming);
                ConnectionClass.UpdateStage(Skill);
                ConnectionClass.UpdateStage(Wod);
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