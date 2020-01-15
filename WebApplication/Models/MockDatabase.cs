using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Models
{
    public class MockDatabase
    {
        public List<StudentModel> GetStudentsFromGroupId(int groupId)
        {
            //get the data for the student in the same group with 
            //the current logged in student
            //mock some data for moment
            List<StudentModel> sameGroupStudents = new List<StudentModel>();
            sameGroupStudents.Add(new StudentModel() {StudentId = 1, FirstName = "Ricards", LastName = "Augustauskis"});
            sameGroupStudents.Add(new StudentModel() {StudentId = 2, FirstName = "Fabio", LastName = "Queiroz"});
            sameGroupStudents.Add(new StudentModel() {StudentId = 3, FirstName = "Andrei", LastName = "Avram"});
            sameGroupStudents.Add(new StudentModel() {StudentId = 1, FirstName = "Ricards", LastName = "Augustauskis"});
            sameGroupStudents.Add(new StudentModel() {StudentId = 2, FirstName = "Fabio", LastName = "Queiroz"});
            sameGroupStudents.Add(new StudentModel() {StudentId = 3, FirstName = "Andrei", LastName = "Avram"});
            return sameGroupStudents;
        }

        /**
         * As a teacher we may want to get all the groups available in the
         * class
         * Return a List of all Groups in that class
         */
        public List<TableGroupModel> GetGroupsForTeacher(int? id)
        {
            List<TableGroupModel> tableGroups = new List<TableGroupModel>();
            tableGroups.Add(new TableGroupModel(){Id = 1,Name = "Lala Bend"});
            tableGroups.Add(new TableGroupModel(){Id = 2,Name =  "rammstein"});
            tableGroups.Add(new TableGroupModel(){Id = 3,Name = "The best"});
            tableGroups.Add(new TableGroupModel(){Id = 1,Name = "The worst"});
            return tableGroups;
        }

        /**
         * This method should create a student object
         * that has the following values
         *  FirstName, Lastname , StudentId ,Email , GroupName
         * and ClassName
         */
        public StudentModel GetStudentDetailsFromId(int id)
        {
            StudentModel studentModel = new StudentModel()
            {
                FirstName = "Ricardo",LastName = "No",StudentId = id,Email = "avramandreitiberiu@gmail.com",
                TableGroup = new TableGroupModel(){Name = "La la group", ClassName = "12 B"}
            };
            return studentModel;
        }

        public void InsertStudentIntoTheDatabase(string fullAddress)
        {
           //insert the address into the database
        }

        public object GetStudentsWithoutGroupForTeacherId(int? id)
        {
            //get all the students that are not currently in a group 
            //for that teache's class based on the teacher id 
            List<StudentModel> students = new List<StudentModel>();
            students.Add(new StudentModel(){FirstName = "Andrei"});
            students.Add(new StudentModel() {StudentId = 1, FirstName = "Ricards", LastName = "Augustauskis"});
            students.Add(new StudentModel() {StudentId = 2, FirstName = "Fabio", LastName = "Queiroz"});
            students.Add(new StudentModel() {StudentId = 3, FirstName = "Andrei", LastName = "Avram"});
            return students;
        }

        public void CreateGroup(int[] studentIDs)
        {
            //do mock things 
            //lalala 
        }

        public StudentModel GetUserProfileFromId(int? id)
        {
            StudentModel studentModel = new StudentModel();
            studentModel.FirstName = "Andrei Tiberiu";
            studentModel.LastName = "Avram";
            studentModel.Email = "avramandreitiberiu@gmail.com";
            studentModel.DateOfBirth = "15/06/1999";
            return studentModel;
        }
    }
    
}