using Abstractions.DTOs;
using AutoMapper;
using Repository.Entities;

namespace Business.Mapper
{
    /// <summary>
    /// Defines the AutoMapper profile for mapping between SQL entities, MongoDB entities, and DTOs.
    /// This profile configures mappings for converting between data transfer objects (DTOs) and database entities.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // SQL to DTO mappings
            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
            CreateMap<Course, CourseDto>();

            // DTO to SQL mappings
            CreateMap<TeacherDto, Teacher>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
            CreateMap<CourseDto, Course>();

            // Mongo to DTO mappings
            CreateMap<MongoTeacher, TeacherDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
            CreateMap<MongoCourse, CourseDto>();

            // DTO to Mongo mappings
            CreateMap<TeacherDto, MongoTeacher>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
            CreateMap<CourseDto, MongoCourse>();
        }
    }
}
