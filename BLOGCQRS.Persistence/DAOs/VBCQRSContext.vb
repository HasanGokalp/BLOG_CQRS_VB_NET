Imports System.Reflection
Imports BLOGCQRS.Domain
Imports Microsoft.EntityFrameworkCore

Public Class VBCQRSContext
    Inherits DbContext

    'Props
    Public Property Post As DbSet(Of Post)
    Public Property Users As DbSet(Of User)
    Public Property AccountInfos As DbSet(Of AccountInfo)

    ''' <summary>
    ''' Yeni bir Data Accsess Object üretilmesi için constructor.
    ''' </summary>
    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Database default ayarlarını özelleştirmek için örneğin bağlantı stringi.
    ''' </summary>
    ''' <param name="optionsBuilder"></param>
    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        If Not optionsBuilder.IsConfigured Then
            MyBase.OnConfiguring(optionsBuilder)
            optionsBuilder.UseSqlServer("Server=.\SQLEXPRESS;Database=VBCQRS_BLOG;Trusted_Connection=True;TrustServerCertificate=True")
            optionsBuilder.EnableSensitiveDataLogging()
        End If
    End Sub

    ''' <summary>
    ''' Databasein verileri default olarak atamasının yerine bizim confıgure ettiğimiz veri şeması ile.
    ''' </summary>
    ''' <param name="modelBuilder"></param>
    Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly)
    End Sub

End Class
