Imports System
Imports Microsoft.EntityFrameworkCore.Migrations

Namespace Global.BLOGCQRS.Persistence.Migrations
    ''' <inheritdoc />
    Partial Public Class FIRST
        Inherits Migration

        ''' <inheritdoc />
        Protected Overrides Sub Up(migrationBuilder As MigrationBuilder)
            migrationBuilder.CreateTable(
                name:="ACCOUNT_INFOS",
                columns:=Function(table) New With {
                    .ACCOUNT_INFO_ID = table.Column(Of Integer)(type:="int", nullable:=False).
                        Annotation("SqlServer:Identity", "1, 1"),
                    .ACCOUNT_INFO_USERNAME = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .ACCOUNT_INFO_PASSWORD = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .IS_DELETED = table.Column(Of Boolean)(type:="bit", nullable:=False, defaultValueSql:="0")
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_ACCOUNT_INFOS", Function(x) x.ACCOUNT_INFO_ID)
                End Sub)

            migrationBuilder.CreateTable(
                name:="USERS",
                columns:=Function(table) New With {
                    .USER_ID = table.Column(Of Integer)(type:="int", nullable:=False).
                        Annotation("SqlServer:Identity", "1, 1"),
                    .Auth = table.Column(Of Integer)(type:="int", nullable:=False),
                    .USER_NAME = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .LoginInfosId = table.Column(Of Integer)(type:="int", nullable:=True),
                    .IS_DELETE = table.Column(Of Boolean)(type:="bit", nullable:=False, defaultValueSql:="0"),
                    .CREATED_DATE = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .CREATED_BY = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .MODEFIED_DATE = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .MODEFIED_BY = table.Column(Of String)(type:="nvarchar(max)", nullable:=True)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_USERS", Function(x) x.USER_ID)
                    table.ForeignKey(
                        name:="FK_USERS_ACCOUNT_INFOS_LoginInfosId",
                        column:=Function(x) x.LoginInfosId,
                        principalTable:="ACCOUNT_INFOS",
                        principalColumn:="ACCOUNT_INFO_ID")
                End Sub)

            migrationBuilder.CreateTable(
                name:="POSTS",
                columns:=Function(table) New With {
                    .POST_ID = table.Column(Of Integer)(type:="int", nullable:=False).
                        Annotation("SqlServer:Identity", "1, 1"),
                    .POST_TITTLE = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .POST_CONTENT = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .UserId = table.Column(Of Integer)(type:="int", nullable:=False),
                    .IS_DELETE = table.Column(Of Boolean)(type:="bit", nullable:=False, defaultValueSql:="0"),
                    .CREATED_DATE = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .CREATED_BY = table.Column(Of String)(type:="nvarchar(max)", nullable:=True),
                    .MODEFIED_DATE = table.Column(Of Date)(type:="datetime2", nullable:=False),
                    .MODEFIED_BY = table.Column(Of String)(type:="nvarchar(max)", nullable:=True)
                },
                constraints:=Sub(table)
                    table.PrimaryKey("PK_POSTS", Function(x) x.POST_ID)
                    table.ForeignKey(
                        name:="FK_POSTS_USERS_UserId",
                        column:=Function(x) x.UserId,
                        principalTable:="USERS",
                        principalColumn:="USER_ID",
                        onDelete:=ReferentialAction.Cascade)
                End Sub)

            migrationBuilder.CreateIndex(
                name:="IX_POSTS_UserId",
                table:="POSTS",
                column:="UserId")

            migrationBuilder.CreateIndex(
                name:="IX_USERS_LoginInfosId",
                table:="USERS",
                column:="LoginInfosId")
        End Sub

        ''' <inheritdoc />
        Protected Overrides Sub Down(migrationBuilder As MigrationBuilder)
            migrationBuilder.DropTable(
                name:="POSTS")

            migrationBuilder.DropTable(
                name:="USERS")

            migrationBuilder.DropTable(
                name:="ACCOUNT_INFOS")
        End Sub
    End Class
End Namespace
