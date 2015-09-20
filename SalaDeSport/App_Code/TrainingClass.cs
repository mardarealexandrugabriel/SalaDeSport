using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaDeSport
{
    public class TrainingClass
    {
        int Id { get; set; }
        string Name { get; set; }
        int Trainer_Id { get; set; }
        string Day { get; set; }
        int Hour { get; set; }

        public string GetTrainingName()
        {
            return Name;
        }
        public int GetTrainingId()
        {
            return Id;
        }
        public int GetTrainerId()
        {
            return Trainer_Id;
        }
        public int GetHour()
        {
            return Hour;
        }
        public string GetDay()
        {
            return this.Day;
        }
        public TrainingClass()
        {
          
        }
        public TrainingClass(int id, string name, int trainerid, string day, int hour)
        {
            Id = id;
            Name = name;
            Trainer_Id = trainerid;
            Day = day;
            Hour = hour;

        }
        public TrainingClass(int trainerid,string name, string day, int hour)
        {
            Name = name;
            Trainer_Id = trainerid;
            Day = day;
            Hour = hour;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetTrainingDay()
        {
            return Day;
        }

        public void SetId(int x)
        {
            Id = x;
        }
      


    }
}