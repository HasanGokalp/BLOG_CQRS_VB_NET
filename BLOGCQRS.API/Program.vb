Imports BLOGCQRS.Application
Imports BLOGCQRS.Persistence
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Module Program
    Sub Main(args As String())
        Dim builder As WebApplicationBuilder = WebApplication.CreateBuilder(args)

        ' Add services to the container.
        builder.Services.AddControllers()

        ' Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer()
        builder.Services.AddSwaggerGen()

        builder.Services.AddScoped(GetType(IUnitWork), GetType(UnitWork))

        builder.Services.AddScoped(GetType(IWriteRepository(Of)), GetType(WriteRepository(Of)))

        builder.Services.AddDbContext(Of VBCQRSContext)

        '    ' Assuming GetAllCarHandler is in a namespace that needs to be imported
        builder.Services.AddMediatR(Function(cfg) cfg.RegisterServicesFromAssembly(GetType(CreateUserHandler).Assembly))


        'builder.Services.AddScoped(GetType(ReadRepository))

        Dim app As WebApplication = builder.Build()

        ' Configure the HTTP request pipeline.
        If app.Environment.IsDevelopment() Then
            app.UseSwagger()
            app.UseSwaggerUI()
        End If

        app.UseHttpsRedirection()

        app.UseAuthorization()

        app.MapControllers()

        app.Run()
    End Sub
End Module
