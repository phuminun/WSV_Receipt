Imports Microsoft.VisualBasic

Public Class TrayClass
    Public ID As String
    Public TrayNo As Integer
    Public Amount As Decimal
    Public Estimate As Decimal
    Public BranchId As Integer
    Public BranchName As String
    Public listOfSet As New List(Of SetInTray)
    Public ResultStatus As String
End Class

Public Class SetInTray
    Public SetID As String
    Public No As Integer
    Public PriceSum As Decimal
    Public Quantity As Integer
    Public Weight As Decimal
    Public Estimate As Decimal
    Public isTray As Integer
    Public isSales As Integer
    Public listOfTicket As New List(Of Tickets)
End Class
Public Class Tickets
    Public bookNo As Integer
    Public Amount As Decimal
    Public Estimate As Decimal
End Class
