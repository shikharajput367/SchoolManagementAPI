using Abstractions.DTOs;
using Repository.Entities;
using AutoMapper;

namespace API.Mapper
{
    /// <summary>
    /// Defines the AutoMapper profile for mapping between SQL entities and DTOs.
    /// </summary>
    public class SqlMappingProfile : Profile
    {
        public SqlMappingProfile()
        {
            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Courses));
        
            CreateMap<TeacherDto, Teacher>();

            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<CourseDto, Course>();
        }
    }
}
