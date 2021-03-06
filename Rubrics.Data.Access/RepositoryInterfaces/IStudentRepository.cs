﻿using Rubrics.Data.JoinModels;
using Rubrics.General.Business.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rubrics.Data.Access.RepositoryInterfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        List<Join> GetJoinsUsingLinq();
        Task<IEnumerable<Join>> GetJoinsUsingDapper();
        void RegisterNewStudent(Student newStudent);
        List<string> GetStudentLoginDetailsByEmail(string email);
        Student GetStudentById(int studentId);
        Student GetStudentByEmail(string email);
        //Student GetStudentById(int id);
        Task<IEnumerable<Student>> GetStudentsBySchoolClass(int teacherClassId);
        public bool DeleteStudentByEmail(string email);
        SchoolClass GetClassNameById(int id);
        //Task<IEnumerable<Student>> GetStudentsBySchoolClass(int teacherClassId);
        void UpdateStudentInDb(Student student);
        void UpdateStudentPassword(Student student);
        public void ChangeStudentClass(Student student, int classId);

    }
}
