using Abstractions.DTOs;
using AutoMapper;
using Repository;
using Repository.Entities;

namespace Business
{
    /// <summary>
    /// Provides implementation for teacher-related operations by interacting with both SQL and MongoDB repositories.
    /// This service handles retrieving and combining teacher data from both sources and adding new teachers to both databases.
    /// </summary>
    public class TeacherService : ITeacherService
    {
        private readonly ISqlRepository _sqlRepository;
        private readonly IMongoRepository _mongoRepository;
        private readonly IMapper _mapper;

        public TeacherService(ISqlRepository sqlRepository, IMongoRepository mongoRepository, IMapper mapper)
        {
            _sqlRepository = sqlRepository;
            _mongoRepository = mongoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherDto>> GetSqlTeachersAsync()
        {
            var teachers = await _sqlRepository.GetAllTeachersAsync();
            return _mapper.Map<IEnumerable<TeacherDto>>(teachers);
        }

        public async Task<IEnumerable<TeacherDto>> GetMongoTeachersAsync()
        {
            var teachers = await _mongoRepository.GetAllTeachersAsync();
            return _mapper.Map<IEnumerable<TeacherDto>>(teachers);
        }

        public async Task<IEnumerable<TeacherDto>> GetCombinedTeachersAsync()
        {
            var sqlTeachers = await _sqlRepository.GetAllTeachersAsync();
            var mongoTeachers = await _mongoRepository.GetAllTeachersAsync();

            // Map SQL and Mongo entities to TeacherDto
            var sqlTeacherDtos = _mapper.Map<IEnumerable<TeacherDto>>(sqlTeachers);
            var mongoTeacherDtos = _mapper.Map<IEnumerable<TeacherDto>>(mongoTeachers);

            // Combine both mapped lists
            var combinedTeachers = sqlTeacherDtos.Concat(mongoTeacherDtos);

            return combinedTeachers;
        }

        public async Task AddTeacherAsync(TeacherDto teacherDto)
        {
            var sqlTeacher = _mapper.Map<Teacher>(teacherDto);
            var mongoTeacher = _mapper.Map<MongoTeacher>(teacherDto);

            // Save to both SQL and MongoDB
            await _sqlRepository.AddTeacherAsync(sqlTeacher);
            await _mongoRepository.AddTeacherAsync(mongoTeacher);
        }
    }
}
