Imports BLOGCQRS.Domain
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders

Public Class UserMapping
    Implements IEntityTypeConfiguration(Of User)

    Public Sub Configure(builder As EntityTypeBuilder(Of User)) Implements IEntityTypeConfiguration(Of User).Configure
        builder.ToTable("USERS")

        builder.HasKey(Function(x) x.Id)

        builder.Property(Function(x) x.Id).IsRequired.HasColumnName("USER_ID")

        builder.Property(Function(x) x.IsDelete).HasColumnName("IS_DELETE").HasDefaultValueSql(0)

        builder.Property(Function(x) x.CreatedDate).HasColumnName("CREATED_DATE")

        builder.Property(Function(x) x.CreatedBy).HasColumnName("CREATED_BY")

        builder.Property(Function(x) x.ModifiedBy).HasColumnName("MODEFIED_BY")

        builder.Property(Function(x) x.ModifiedDate).HasColumnName("MODEFIED_DATE")

        builder.Property(Function(x) x.Name).HasColumnName("USER_NAME")


    End Sub
End Class
