
Imports Microsoft.VisualBasic
Imports System.Data
Imports Oracle.DataAccess.Client
Imports System.IO
Imports System.Exception
Public Class WSvReceiptDataAccessClass
    Public con As OracleConnection

    Public Shared Function getConnection() As OracleConnection
        Dim con As New OracleConnection(ConfigurationManager.ConnectionStrings("PawnShopData").ToString)
        con.Open()
        Return con
    End Function
    Public Shared Function getPwAssetConnection() As OracleConnection
        Dim con As New OracleConnection(ConfigurationManager.ConnectionStrings("PawnAsset").ToString)
        con.Open()
        Return con
    End Function

    '------------Tray----------
    Public Shared Function getTrayInfoByEvent(ByVal eventID As String, ByVal branchId As Integer, ByVal trayNo As Integer) As DataTable
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter
        Dim con As New OracleConnection
        Dim cmd As New OracleCommand
        con = getPwAssetConnection()
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = """WSV_getTrayByEvent"""
        cmd.Parameters.Add(New OracleParameter("vEventID", OracleDbType.Varchar2)).Value = eventID
        cmd.Parameters.Add(New OracleParameter("vBranchId", OracleDbType.Int32)).Value = branchId
        cmd.Parameters.Add(New OracleParameter("vTrayNo", OracleDbType.Int32)).Value = trayNo
        cmd.Parameters.Add(New OracleParameter("TicketInfo", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

        Try
            da.SelectCommand = cmd
            da.Fill(dt)
        Catch ex As Exception

        Finally
            con.Close()
        End Try

        Return dt
    End Function

    Public Shared Function getSetByEventByTray(ByVal eventID As String, ByVal branchId As Integer, ByVal trayNo As Integer) As DataTable
        Dim dt As New DataTable
        Dim da As New OracleDataAdapter
        Dim con As New OracleConnection
        Dim cmd As New OracleCommand
        con = getPwAssetConnection()
        cmd.Connection = con
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = """WSV_getSetByEventByTray"""
        cmd.Parameters.Add(New OracleParameter("vEventID", OracleDbType.Varchar2)).Value = eventID
        cmd.Parameters.Add(New OracleParameter("vBranchId", OracleDbType.Int32)).Value = branchId
        cmd.Parameters.Add(New OracleParameter("vTrayNo", OracleDbType.Int32)).Value = trayNo
        cmd.Parameters.Add(New OracleParameter("TicketInfo", OracleDbType.RefCursor)).Direction = ParameterDirection.Output

        Try
            da.SelectCommand = cmd
            da.Fill(dt)
        Catch ex As Exception

        Finally
            con.Close()
        End Try

        Return dt
    End Function

End Class
