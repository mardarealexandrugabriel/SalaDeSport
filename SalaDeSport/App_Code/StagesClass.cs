using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaDeSport
{
    public class StagesClass
    {
        int Id{get; set;}
        int NumberOfSets{get;set;}
        int NumberOfExercices { get; set; }
        int TypeOfExercices { get; set; }
        int Training_Id { get; set; }
        string TypeOfStage { get; set;}
        public StagesClass()
        { 
        }
        public StagesClass(int id, int NOS, int NOE, int TOE, int TID,string  TOS)
        {
            Id = id;
            NumberOfSets = NOS;
            NumberOfExercices = NOE;
            TypeOfExercices = TOE;
            Training_Id = TID;
            TypeOfStage = TOS;
        }

        public StagesClass(int NOS, int NOE, int TOE, int TID, string TOS)
        {
            
            NumberOfSets = NOS;
            NumberOfExercices = NOE;
            TypeOfExercices = TOE;
            Training_Id = TID;
            TypeOfStage = TOS;
        }
        public void SetId(int id)
        {
            Id = id;
        }
        public void SetNumberOfSets(int NOS)
        {
            NumberOfSets = NOS;
        }
        public void SetNumberOfExercices(int NOE)
        {
            NumberOfExercices = NOE;
        }
        public void SetTypeOfExercice(int Id)
        {

            TypeOfExercices = Id;
        }
        public void SetTrainingId(int id)
        {
            Training_Id = Id;
        }
        public void SetTypeOfStage(string Ty)
        {
            TypeOfStage = Ty;
        }
        //
        public int GetNumberOfSets()
        {
            return NumberOfSets;
        }
        public int GetNumberOfExercices()
        {
            return NumberOfExercices;
        }
        public int GetTrainingId()
        {
            return Training_Id;
        }
        public int GetTypeOfExercice()
        {
            return TypeOfExercices;
        }
        public string GetTypeOfStage()
        {
            return TypeOfStage;
        }
        public int GetId()
        {
            return Id;
        }

    }
}