﻿namespace YZCollege.Domain.Dtos.Response
{
    public class CourseResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TeacherResponseDto Teacher { get; set; }
    }
}
