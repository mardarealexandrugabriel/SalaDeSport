using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaDeSport
{
    public class TypeOfExercicies
    {
        int Id { get; set; }
        string Name { get; set; }
        public TypeOfExercicies()
        {
          
        }
        public TypeOfExercicies(string name)
        {
            Name = name;
 
        }
        public TypeOfExercicies(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int GetId()
        {
            return Id;
        }
        public string GetExName()
        {
            return Name;
        }
        public void SetExname(string name)
        {
            Name = name;
        }
        
    }
}