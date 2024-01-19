Imports BLOGCQRS.Domain
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders

Public Class AccountInfoMapping
    Implements IEntityTypeConfiguration(Of AccountInfo)

    Public Sub Configure(builder As EntityTypeBuilder(Of AccountInfo)) Implements IEntityTypeConfiguration(Of AccountInfo).Configure
        builder.ToTable("ACCOUNT_INFOS")

        builder.HasKey(Function(x) x.Id)

        builder.Property(Function(x) x.Id).HasColumnName("ACCOUNT_INFO_ID")

        builder.Property(Function(x) x.IsDelete).HasColumnName("IS_DELETED").HasDefaultValueSql(0)

        builder.Property(Function(x) x.Password).HasColumnName("ACCOUNT_INFO_PASSWORD")

        builder.Property(Function(x) x.Username).HasColumnName("ACCOUNT_INFO_USERNAME")

    End Sub
End Class
