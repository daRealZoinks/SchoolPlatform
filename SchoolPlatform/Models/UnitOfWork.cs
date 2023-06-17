using System;
using System.Windows;
using View.Models.Repositories;

namespace View.Models;

public class UnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext,
        AbsenceRepository absenceRepository,
        AverageRepository averageRepository,
        ClassRepository classRepository,
        GradeRepository gradeRepository,
        SpecializationRepository specializationRepository,
        StudentRepository studentsRepository,
        SubjectClassRepository subjectClassRepository,
        SubjectRepository subjectRepository,
        TeacherRepository teacherRepository,
        UserRepository userRepository,
        YearRepository yearRepository)
    {
        _appDbContext = appDbContext;
        AbsenceRepository = absenceRepository;
        AverageRepository = averageRepository;
        ClassRepository = classRepository;
        GradeRepository = gradeRepository;
        SpecializationRepository = specializationRepository;
        StudentsRepository = studentsRepository;
        SubjectClassRepository = subjectClassRepository;
        SubjectRepository = subjectRepository;
        TeacherRepository = teacherRepository;
        UserRepository = userRepository;
        YearRepository = yearRepository;
    }

    public AbsenceRepository AbsenceRepository { get; }
    public AverageRepository AverageRepository { get; }
    public ClassRepository ClassRepository { get; }
    public GradeRepository GradeRepository { get; }
    public SpecializationRepository SpecializationRepository { get; }
    public StudentRepository StudentsRepository { get; }
    public SubjectClassRepository SubjectClassRepository { get; }
    public SubjectRepository SubjectRepository { get; }
    public TeacherRepository TeacherRepository { get; }
    public UserRepository UserRepository { get; }
    public YearRepository YearRepository { get; }

    public void SaveChanges()
    {
        try
        {
            _appDbContext.SaveChanges();
        }
        catch (Exception exception)
        {
            MessageBox.Show(@$"Error saving changes to database:

            {exception.Message} 

            {exception.InnerException}

            {exception.StackTrace}");
        }
    }
}