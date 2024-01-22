Imports BLOGCQRS.Domain

Public Class GetByIdUserResponse
    Public Property Auth As Authority
    Public Property Name As String
    Public Property LoginInfos As AccountInfo

    Public Property Posts As ICollection(Of Post)
End Class
