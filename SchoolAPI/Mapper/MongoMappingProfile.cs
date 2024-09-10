using Abstractions.DTOs;
using AutoMapper;
using Repository.Entities;

namespace API.Mapper
{
    /// <summary>
    /// Defines the AutoMapper profile for mapping between MongoDB entities and DTOs.
    /// </summary>
    public class MongoMappingProfile : Profile
    {
        public MongoMappingProfile()
        {
            CreateMap<MongoTeacher, TeacherDto>();

            CreateMap<TeacherDto, MongoTeacher>();

            CreateMap<MongoCourse, CourseDto>();

            CreateMap<CourseDto, MongoCourse>();
        }
    }
}
