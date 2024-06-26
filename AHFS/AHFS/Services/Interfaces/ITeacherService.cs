﻿using AHFS.Models;
namespace AHFS.Services.Interfaces
{
    public interface ITeacherService
    {
        void CreateTeacher(Teacher teacher);
    
        void DeleteTeacher(Teacher teacher);

        void UpdateTeacher(Teacher teacher);

        List<Teacher> GetTeachers();

        Teacher GetTeacherByUserId(string id);
        Teacher GetTeacherById(int id);
    }
}

