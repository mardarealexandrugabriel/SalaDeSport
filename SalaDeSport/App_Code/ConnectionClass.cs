using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace SalaDeSport
{
    public class ConnectionClass
    {
        static SqlConnection Conn;
        static SqlCommand command;
        static ConnectionClass()
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionS"].ConnectionString);
        }
        public static bool FindUsername(string username)
        {
            
                bool a;
                string query;
                Conn.Open();
                query = String.Format("Select count(*) from [dbo].[Users] where Username ='{0}'", username); ;
                command = new SqlCommand(query, Conn);
                int b = Convert.ToInt32(command.ExecuteScalar());
                if (b >= 1) a = true;
                else a = false;
                Conn.Close();
                return a;
            
           
        }
        public static void InsertNewUser(UserClass User)
        {
            
                Conn.Open();
                string query = String.Format("Insert into [dbo].[Users](Username,Password,Type,Firstname,Lastname) values('{0}','{1}',{2},'{3}','{4}')", User.GetUserName(), User.GetPassword(), User.GetTypeOfUser(), User.GetFirstname(), User.GetLastname());
                command = new SqlCommand(query, Conn);
                command.ExecuteNonQuery();
                Conn.Close();

           
        }
        public static int GetUserId(string username)
        {

            int Id = 0;
           
                Conn.Open();
                string query = String.Format("Select Id from [dbo].[Users] where Username ='{0}'", username);
                command = new SqlCommand(query, Conn);
                Id = Convert.ToInt32(command.ExecuteScalar());
                Conn.Close();
            
            return Id;
        }
        public static UserClass GetUserById(int id)
        {

            UserClass Usr = new UserClass();
          
                Conn.Open();
                string query = String.Format("Select * from [dbo].[Users] where Id = {0}", id);
                command = new SqlCommand(query, Conn);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Usr = new UserClass(Convert.ToInt32(reader["Id"]), reader["Username"].ToString(), reader["Password"].ToString(), reader["FirstName"].ToString(), reader["Lastname"].ToString(), Convert.ToInt32(reader["Type"]));
                Conn.Close();
           
            return Usr;

        }
        public static void AddNewExercice(TypeOfExercicies Ex)
        {
           
                Conn.Open();
                string query = String.Format("Insert into [dbo].[TypeOfExercices](Name) Values('{0}')", Ex.GetExName());
                command = new SqlCommand(query, Conn);
                command.ExecuteNonQuery();
                Conn.Close();
            
            
        }
        public static TypeOfExercicies GetExerciceById(int id)
        {
            TypeOfExercicies Ty = new TypeOfExercicies();
            Conn.Open();
            string query = String.Format("Select * from [Dbo].[TypeOfExercices] where Id={0}", id);
            command = new SqlCommand(query, Conn);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Ty = new TypeOfExercicies(Convert.ToInt32(reader["Id"]), reader["Name"].ToString());
            }
            Conn.Close();
            return Ty;
        }
        public static bool ExerciceExists(TypeOfExercicies ex)
        {
            bool Ok = true;
            
                Conn.Open();
                string query = String.Format("Select count(*) from [dbo].[TypeOfExercices] where Name='{0}'", ex.GetExName());
                command = new SqlCommand(query, Conn);
                if (Convert.ToInt32(command.ExecuteScalar()) >= 1)
                    Ok = true;
                else
                    Ok = false;

                Conn.Close();
            
            
            return Ok;
        }

        public static List<TypeOfExercicies> GetTypeOfExercices()
        {
            List<TypeOfExercicies> List = new List<TypeOfExercicies>();
            Conn.Open();
            string query = "Select * from [dbo].[TypeOfExercices]";
            command = new SqlCommand(query, Conn);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                TypeOfExercicies Ex = new TypeOfExercicies(Convert.ToInt32(reader["Id"]), reader["Name"].ToString());
                List.Add(Ex);
            }

            Conn.Close();
            return List;
 
        }
        public static void InsertNewTraining(TrainingClass Tr)
        {
            Conn.Open();
            string Query = String.Format("Insert into [dbo].[Trainings](Day,Hour,Trainer_id,Name) values ('{0}','{1}',{2},'{3}')", Tr.GetDay(), Tr.GetHour(), Tr.GetTrainerId(),Tr.GetTrainingName());
            command = new SqlCommand(Query, Conn);
            command.ExecuteNonQuery();
            Conn.Close();
        }
        public static void UpdateTraining(TrainingClass Tr)
        {
            Conn.Open();
            string Query = String.Format("Update [dbo].[Trainings] set Day='{0}', Hour='{1}' ,Trainer_id={2}, Name='{3}' where Id={4}", Tr.GetDay(), Tr.GetHour(), Tr.GetTrainerId(), Tr.GetTrainingName(), Tr.GetTrainingId());
            command = new SqlCommand(Query, Conn);
            command.ExecuteNonQuery();
            Conn.Close();
        }

        public static bool IsFree(TrainingClass Tr)
        {
            
           
            Conn.Open();
            string query = String.Format("Select count(*) from [dbo].[Trainings] where Day='{0}' and Hour={1} ", Tr.GetDay(),Tr.GetHour());
            command = new SqlCommand(query, Conn);
            int x = Convert.ToInt32(command.ExecuteScalar());
            Conn.Close();
            if (x >= 1)
                return false;
            return true;
           
        }
        public static int GetTrainingIdFromDB(TrainingClass Tr)
        {
            Conn.Open();
            string query = String.Format("Select Id from [dbo].[Trainings] where Day='{0}' and Hour='{1}'", Tr.GetDay(), Tr.GetHour());
            command = new SqlCommand(query, Conn);
            int x = Convert.ToInt32(command.ExecuteScalar());
           Conn.Close();
           return x;
        }
        public static TrainingClass GetTrainingById(int id)
        {
            TrainingClass Tr = new TrainingClass();
            Conn.Open();
            string query = String.Format("Select * from [dbo].[Trainings] where Id={0}", id);
            command = new SqlCommand(query, Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Tr = new TrainingClass(Convert.ToInt32(reader["Id"]), reader["Name"].ToString(), Convert.ToInt32(reader["Trainer_id"]), reader["Day"].ToString(), Convert.ToInt32(reader["Hour"]));
            }
            Conn.Close();
            return Tr;

        }
        public static void InsertStage(StagesClass St)
        {
            Conn.Open();
            string query = String.Format("Insert into [dbo].[Stages](NumberOfSets,NumberOfExercices,TypeOfExercices,Training_Id,TypeOfStage) values({0},{1},{2},{3},'{4}')",St.GetNumberOfSets(),St.GetNumberOfExercices(),St.GetTypeOfExercice(),St.GetTrainingId(),St.GetTypeOfStage());
            command = new SqlCommand(query, Conn);
            command.ExecuteNonQuery();
            Conn.Close();
            
        }
        public static void UpdateStage(StagesClass St)
        {
            Conn.Open();
            string query = String.Format("Update [dbo].[Stages] set NumberOfSets={0}, NumberOfExercices={1},TypeOfExercices={2} where Training_Id={3} and TypeOfStage='{4}'", St.GetNumberOfSets(), St.GetNumberOfExercices(), St.GetTypeOfExercice(), St.GetTrainingId(), St.GetTypeOfStage());
            command = new SqlCommand(query, Conn);
            command.ExecuteNonQuery();
            Conn.Close();
        
        }
        public static StagesClass GetStageByTrainingIdAndType(int TrainigId, string StageType)
        {
            StagesClass St = new StagesClass();
            Conn.Open();
            string query = String.Format("Select * from [dbo].[Stages] where Training_id={0} and TypeOfStage='{1}'", TrainigId, StageType);
            command = new SqlCommand(query, Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                St = new StagesClass(Convert.ToInt32(reader["Id"]), Convert.ToInt32(reader["NumberOfSets"]), Convert.ToInt32(reader["NumberOfExercices"]), Convert.ToInt32(reader["TypeOfExercices"]), Convert.ToInt32(reader["Training_id"]), reader["TypeOfStage"].ToString());
            }
            Conn.Close();
            return St;
        }

        public static List<TrainingClass> GetListOfTrainings()
        {
            List<TrainingClass> List = new List<TrainingClass>();
            Conn.Open();
            string query = "Select * from [dbo].[Trainings]";
            command = new SqlCommand(query, Conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TrainingClass Tr = new TrainingClass(Convert.ToInt32(reader["Id"]),reader["Name"].ToString(),Convert.ToInt32(reader["Trainer_Id"]),reader["Day"].ToString(), Convert.ToInt32(reader["Hour"].ToString()));
                List.Add(Tr);
            }


            Conn.Close();
            return List;
            
           
        }
        public static bool TrainingExists(int Id)
        {
            Conn.Open();
            string query =String.Format("Select count(*) from [dbo].[Trainings] where Id={0}",Id);
            command = new SqlCommand(query, Conn);
            int x = Convert.ToInt32(command.ExecuteScalar());
            Conn.Close();
            if (x >= 1) return true;
            return false;
        }
        public static void Attend(ParticipationClass At)
        {
            Conn.Open();
            string query = String.Format("Insert into [dbo].[Participations](User_Id,Training_Id) values({0},{1})", At.GetUserId(), At.GetTrainingId());
            command = new SqlCommand(query, Conn);
            command.ExecuteNonQuery();
            Conn.Close();
        }
        public static bool IsAttending(int UserId, int TrainingId)
        {
            Conn.Open();
            string query = String.Format("Select count(*) from [dbo].[Participations] where User_Id={0} and Training_Id={1}",UserId,TrainingId);
            command = new SqlCommand(query, Conn);
            int x = Convert.ToInt32(command.ExecuteScalar());
            Conn.Close();
            if (x >= 1) return true;
            return false;
 
        }
        public static void LeaveTraining(ParticipationClass Pc)
        {
            Conn.Open();
            string query = String.Format("Delete from [dbo].[Participations] where User_Id={0} and Training_Id={1}",Pc.GetUserId(),Pc.GetTrainingId());
            command = new SqlCommand(query, Conn);
            command.ExecuteNonQuery();
            Conn.Close();
        }
        public static void DeleteTrainingById(int id)
        {
            Conn.Open();
            string query = String.Format("Delete from [dbo].[Trainings] where Id={0}", id);
            command = new SqlCommand(query, Conn);
            command.ExecuteNonQuery();
            Conn.Close();
        }

    }
}