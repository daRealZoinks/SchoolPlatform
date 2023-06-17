using System;
using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using View.Models;
using View.Models.Repositories;
using View.ViewModels.Services;

namespace View;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private readonly Ioc _ioc = new();

    public App()
    {
        Services = ConfigureSettings();
        _ioc.ConfigureServices(Services);

        InitializeServices();
    }

    public new static App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    private void InitializeServices()
    {
        Services.GetService<IAbsenceCollectionService>()?.GetAll();
        Services.GetService<IAverageCollectionService>()?.GetAll();
        Services.GetService<IClassCollectionService>()?.GetAll();
        Services.GetService<IGradeCollectionService>()?.GetAll();
        Services.GetService<ISpecializationCollectionService>()?.GetAll();
        Services.GetService<IStudentCollectionService>()?.GetAll();
        Services.GetService<ISubjectClassCollectionService>()?.GetAll();
        Services.GetService<ISubjectCollectionService>()?.GetAll();
        Services.GetService<ITeacherCollectionService>()?.GetAll();
        Services.GetService<IUserCollectionService>()?.GetAll();
        Services.GetService<IYearCollectionService>()?.GetAll();
    }

    private static IServiceProvider ConfigureSettings()
    {
        IServiceCollection serviceCollection = new ServiceCollection();

        serviceCollection.AddDbContext<AppDbContext>();

        serviceCollection.AddScoped<AbsenceRepository>();
        serviceCollection.AddScoped<AverageRepository>();
        serviceCollection.AddScoped<ClassRepository>();
        serviceCollection.AddScoped<GradeRepository>();
        serviceCollection.AddScoped<SpecializationRepository>();
        serviceCollection.AddScoped<StudentRepository>();
        serviceCollection.AddScoped<SubjectClassRepository>();
        serviceCollection.AddScoped<SubjectRepository>();
        serviceCollection.AddScoped<TeacherRepository>();
        serviceCollection.AddScoped<UserRepository>();
        serviceCollection.AddScoped<YearRepository>();

        serviceCollection.AddSingleton<UnitOfWork>();

        serviceCollection.AddScoped<IAbsenceCollectionService, AbsenceCollectionService>();
        serviceCollection.AddScoped<IAverageCollectionService, AverageCollectionService>();
        serviceCollection.AddScoped<IClassCollectionService, ClassCollectionService>();
        serviceCollection.AddScoped<IGradeCollectionService, GradeCollectionService>();
        serviceCollection.AddScoped<ISpecializationCollectionService, SpecializationCollectionService>();
        serviceCollection.AddScoped<IStudentCollectionService, StudentCollectionService>();
        serviceCollection.AddScoped<ISubjectClassCollectionService, SubjectClassCollectionService>();
        serviceCollection.AddScoped<ISubjectCollectionService, SubjectCollectionService>();
        serviceCollection.AddScoped<ITeacherCollectionService, TeacherCollectionService>();
        serviceCollection.AddScoped<IUserCollectionService, UserCollectionService>();
        serviceCollection.AddScoped<IYearCollectionService, YearCollectionService>();

        return serviceCollection.BuildServiceProvider();
    }
}