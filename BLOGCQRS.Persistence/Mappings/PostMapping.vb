Imports BLOGCQRS.Domain
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata.Builders

Public Class PostMapping
    Implements IEntityTypeConfiguration(Of Post)

    Public Sub Configure(builder As EntityTypeBuilder(Of Post)) Implements IEntityTypeConfiguration(Of Post).Configure
        builder.ToTable("POSTS")

        builder.HasKey(Function(x) x.Id)

        builder.Property(Function(x) x.Id).IsRequired.HasColumnName("POST_ID")

        builder.Property(Function(x) x.IsDelete).HasColumnName("IS_DELETE").HasDefaultValueSql(0)

        builder.Property(Function(x) x.CreatedDate).HasColumnName("CREATED_DATE")

        builder.Property(Function(x) x.CreatedBy).HasColumnName("CREATED_BY")

        builder.Property(Function(x) x.ModifiedBy).HasColumnName("MODEFIED_BY")

        builder.Property(Function(x) x.ModifiedDate).HasColumnName("MODEFIED_DATE")

        builder.Property(Function(x) x.Tittle).HasColumnName("POST_TITTLE")

        builder.Property(Function(x) x.Content).HasColumnName("POST_CONTENT")

        builder.HasOne(Function(x) x.Author).WithMany(Function(x) x.Posts).HasForeignKey(Function(x) x.UserId)

    End Sub
End Class
