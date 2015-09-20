using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SalaDeSport
{
    public partial class Program : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPanel();

        }
        protected void FillPanel()
        {
            List<TrainingClass> List = new List<TrainingClass>();
            List = ConnectionClass.GetListOfTrainings();
            for (int i = 0; i <= 23; i++)
            {
                List<TrainingClass> Part = List.Where(x => x.GetHour() == i).ToList();
                TrainingClass MondayI = Part.FirstOrDefault(u => u.GetDay() == "Monday");
                TrainingClass TuesdayI = Part.FirstOrDefault(u => u.GetDay() == "Tuesday");
                TrainingClass WednesdayI = Part.FirstOrDefault(u => u.GetDay() == "Wednesday");
                TrainingClass ThursdayI = Part.FirstOrDefault(u => u.GetDay() == "Thursday");
                TrainingClass FridayI = Part.FirstOrDefault(u => u.GetDay() == "Friday");
                TrainingClass SaturdayI = Part.FirstOrDefault(u => u.GetDay() == "Saturday");
                TrainingClass SundayI = Part.FirstOrDefault(u => u.GetDay() == "Sunday");

                HtmlTableRow Tr = new HtmlTableRow();
                HtmlTableCell HourIn = new HtmlTableCell();
                HourIn.InnerText = i.ToString()+":00";
                
                HtmlTableCell TdMonday = new HtmlTableCell();
                if (MondayI != null)
                {
                    LiteralControl Ctrl = new LiteralControl("<span class='glyphicon glyphicon-pushpin'></span> ");
                    HtmlAnchor refMonday = new HtmlAnchor();
                    refMonday.Attributes.Add("href", "Training.aspx?TId=" + MondayI.GetTrainingId());
                    refMonday.InnerText = MondayI.GetTrainingName();
                    TdMonday.Controls.Add(Ctrl);
                    TdMonday.Controls.Add(refMonday);
                }
                HtmlTableCell TdTuesday = new HtmlTableCell();
                if (TuesdayI != null)
                {
                    LiteralControl Ctrl = new LiteralControl("<span class='glyphicon glyphicon-pushpin'></span> ");
                    HtmlAnchor refTuesday = new HtmlAnchor();
                    refTuesday.Attributes.Add("href", "Training.aspx?TId=" + TuesdayI.GetTrainingId());
                    refTuesday.InnerText = TuesdayI.GetTrainingName();
                    TdTuesday.Controls.Add(Ctrl);
                    TdTuesday.Controls.Add(refTuesday);
                }
                HtmlTableCell TdWednesday = new HtmlTableCell();
                if (WednesdayI != null)
                {
                    LiteralControl Ctrl = new LiteralControl("<span class='glyphicon glyphicon-pushpin'></span> ");
                    HtmlAnchor refWednesday = new HtmlAnchor();
                    refWednesday.Attributes.Add("href", "Training.aspx?TId=" + WednesdayI.GetTrainingId());
                    refWednesday.InnerText = WednesdayI.GetTrainingName();
                    TdWednesday.Controls.Add(Ctrl);
                    TdWednesday.Controls.Add(refWednesday);
                    
                }
                HtmlTableCell TdThursday = new HtmlTableCell();
                if (ThursdayI != null)
                {
                    LiteralControl Ctrl = new LiteralControl("<span class='glyphicon glyphicon-pushpin'></span> ");
                    HtmlAnchor refThursday = new HtmlAnchor();
                    refThursday.Attributes.Add("href", "Training.aspx?TId=" + ThursdayI.GetTrainingId());
                    refThursday.InnerText = ThursdayI.GetTrainingName();
                    TdThursday.Controls.Add(Ctrl);
                    TdThursday.Controls.Add(refThursday);
                    

                }
                HtmlTableCell TdFriday = new HtmlTableCell();
                if (FridayI != null)
                {
                    LiteralControl Ctrl = new LiteralControl("<span class='glyphicon glyphicon-pushpin'></span> ");
                    HtmlAnchor refFriday = new HtmlAnchor();
                    refFriday.Attributes.Add("href", "Training.aspx?TId=" + FridayI.GetTrainingId());
                    refFriday.InnerText = FridayI.GetTrainingName();
                    TdFriday.Controls.Add(Ctrl);
                    TdFriday.Controls.Add(refFriday);
                    

                }

                HtmlTableCell TdSaturday = new HtmlTableCell();
                if (SaturdayI != null)
                {
                    LiteralControl Ctrl = new LiteralControl("<span class='glyphicon glyphicon-pushpin'></span> ");
                    HtmlAnchor refSaturday = new HtmlAnchor();
                    refSaturday.Attributes.Add("href", "Training.aspx?TId=" + SaturdayI.GetTrainingId());
                    refSaturday.InnerText = SaturdayI.GetTrainingName();
                    TdSaturday.Controls.Add(Ctrl);
                    TdSaturday.Controls.Add(refSaturday);
                    

                }
                HtmlTableCell TdSunday = new HtmlTableCell();
                if (SundayI != null)
                {
                    LiteralControl Ctrl = new LiteralControl("<span class='glyphicon glyphicon-pushpin'></span> ");
                    HtmlAnchor refSunday = new HtmlAnchor();
                    refSunday.Attributes.Add("href", "Training.aspx?TId=" + SundayI.GetTrainingId());
                    refSunday.InnerText = SundayI.GetTrainingName();
                    TdSunday.Controls.Add(Ctrl);
                    TdSunday.Controls.Add(refSunday);
                    

                }
                Tr.Controls.Add(HourIn);
                Tr.Controls.Add(TdMonday);
                Tr.Controls.Add(TdTuesday);
                Tr.Controls.Add(TdWednesday);
                Tr.Controls.Add(TdThursday);
                Tr.Controls.Add(TdFriday);
                Tr.Controls.Add(TdSaturday);
                Tr.Controls.Add(TdSunday);
                tbody.Controls.Add(Tr);

            }

        }

    }
}