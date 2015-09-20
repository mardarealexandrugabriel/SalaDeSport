using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalaDeSport
{
    public partial class Training : System.Web.UI.Page
    {
        int TrainingId = 0;
        UserClass UserC;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] == null) Response.Redirect("Login.aspx");
            if (Request.QueryString["TId"] == null || !int.TryParse(Request.QueryString["TId"], out TrainingId) || !ConnectionClass.TrainingExists(TrainingId))
            {
                Response.Redirect("Program.aspx");
            }
            UserC = (UserClass)Session["User"];
            FillPanel(TrainingId);

        }
        protected void FillPanel(int Id)
        {

            
            TrainingClass Tr = ConnectionClass.GetTrainingById(Id);
            StagesClass Warming = ConnectionClass.GetStageByTrainingIdAndType(Tr.GetTrainingId(), "Warming");
            StagesClass Skill = ConnectionClass.GetStageByTrainingIdAndType(Tr.GetTrainingId(), "Skill");
            StagesClass Wod = ConnectionClass.GetStageByTrainingIdAndType(Tr.GetTrainingId(), "Wod");
            UserClass Coach = ConnectionClass.GetUserById(Tr.GetTrainerId());
            PanelTitle.InnerText = Tr.GetName();
            TrainingName.InnerText = Tr.GetName();
            TrainerName.InnerText = String.Format("{0} {1}", Coach.GetFirstname(), Coach.GetLastname());
            TrainingDay.InnerText = Tr.GetTrainingDay();
            TrainingHour.InnerText = String.Format("{0}:00 - {1}:00", Tr.GetHour(), Tr.GetHour() + 1);
            string warming = string.Format("{0} Sets of {1} {2}", Warming.GetNumberOfSets(), Warming.GetNumberOfExercices(), ConnectionClass.GetExerciceById(Warming.GetTypeOfExercice()).GetExName());
            string skill = string.Format("{0} Sets of {1} {2}", Skill.GetNumberOfSets(), Skill.GetNumberOfExercices(), ConnectionClass.GetExerciceById(Skill.GetTypeOfExercice()).GetExName());
            string wod = string.Format("{0} Sets of {1} {2}", Wod.GetNumberOfSets(), Wod.GetNumberOfExercices(), ConnectionClass.GetExerciceById(Wod.GetTypeOfExercice()).GetExName());
            WarmingP.InnerText = warming;
            SkillP.InnerText = skill;
            WodP.InnerText = wod;

            if (UserC.IsCoach())
            {
                if (Tr.GetTrainerId() == UserC.GetId())
                {
                    AttendB.Visible = false;
                    DeleteB.Visible = true;
                    EditB.HRef = String.Format("EditTraining.aspx?TId={0}", Tr.GetTrainingId());
                    EditB.Visible = true;
                    LeaveB.Visible = false;
                }
                else
                {
                    AttendB.Visible = false;
                    DeleteB.Visible = false;
                    EditB.Visible = false;
                    LeaveB.Visible = false;

                }
            }
            else
            {
                if (!ConnectionClass.IsAttending(UserC.GetId(), TrainingId))
                {
                    AttendB.Visible = true;
                    LeaveB.Visible = false;
                }
                else
                {
                    AttendB.Visible = false;
                    LeaveB.Visible = true;
 
                }
                
                DeleteB.Visible = false;
                EditB.Visible = false;

            }

        }
        protected void AttendToTraining(object sender, EventArgs e)
        {
            if (!ConnectionClass.IsAttending(UserC.GetId(), TrainingId))
            {
                ParticipationClass Att = new ParticipationClass(UserC.GetId(), TrainingId);
                ConnectionClass.Attend(Att);
                Response.Redirect(Request.RawUrl);
            }

        }
        protected void LeaveTraining(object sender, EventArgs e)
        {
            if (ConnectionClass.IsAttending(UserC.GetId(), TrainingId))
            {
                ParticipationClass Att = new ParticipationClass(UserC.GetId(), TrainingId);
                ConnectionClass.LeaveTraining(Att);
                Response.Redirect(Request.RawUrl);
                
            }
 
        }
        protected void DeleteTraining(object sender, EventArgs e)
        {
            ConnectionClass.DeleteTrainingById(TrainingId);
            Response.Redirect("Program.aspx");
        }

    }
}