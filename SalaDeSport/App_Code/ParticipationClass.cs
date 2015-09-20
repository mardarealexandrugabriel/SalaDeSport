using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaDeSport
{
    public class ParticipationClass
    {
        int Id { get; set; }
        int UserId { get; set; }
        int TrainingId { get; set; }
        public ParticipationClass()
        { }
        public ParticipationClass(int userid, int trainingid)
        {
            UserId = userid;
            TrainingId = trainingid;
        }
        public ParticipationClass(int id, int userid, int trainingid)
        {
            Id = id;
            UserId = userid;
            TrainingId = trainingid;
        }
        public int GetUserId()
        {
            return UserId;
        }
        public int GetTrainingId()
        {
            return TrainingId;
        }
    }
}