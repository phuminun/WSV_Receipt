Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports TrayClass
Imports System.Data
Imports WSvReceiptDataAccessClass



' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WSVReceipt
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function getTrayInfo(ByVal EventID As String, ByVal BranchId As Integer, ByVal TrayNo As Integer) As TrayClass

        Dim dtTray As New DataTable
        dtTray = getTrayInfoByEvent(EventID, BranchId, TrayNo)

        Dim dtSetInTray As New DataTable
        dtSetInTray = getSetByEventByTray(EventID, BranchId, TrayNo)

        Dim trayObj As New TrayClass
        trayObj.ID = dtTray.Rows(0)("ID").ToString()
        trayObj.TrayNo = Integer.Parse(dtTray.Rows(0)("TrayNo").ToString())
        trayObj.Amount = Decimal.Parse(dtTray.Rows(0)("Amount").ToString())
        trayObj.Estimate = Decimal.Parse(dtTray.Rows(0)("Estimate").ToString())
        trayObj.BranchId = Decimal.Parse(dtTray.Rows(0)("BranchId").ToString())
        trayObj.BranchName = dtTray.Rows(0)("BranchName").ToString()



        If dtSetInTray.Rows.Count > 0 Then
            For i As Integer = 0 To dtSetInTray.Rows.Count - 1

                Dim setWithTray As New SetInTray
                setWithTray.SetID = dtSetInTray.Rows(i)("SetID").ToString()
                setWithTray.No = Integer.Parse(dtSetInTray.Rows(i)("No").ToString())
                setWithTray.PriceSum = Decimal.Parse(dtSetInTray.Rows(i)("PriceSum").ToString())
                setWithTray.Quantity = Integer.Parse(dtSetInTray.Rows(i)("Quantity").ToString())
                setWithTray.Weight = Decimal.Parse(dtSetInTray.Rows(i)("Weight").ToString())
                setWithTray.Estimate = Decimal.Parse(dtSetInTray.Rows(i)("SecondEstimate").ToString())
                setWithTray.isTray = Integer.Parse(dtSetInTray.Rows(i)("IsTray").ToString())
                setWithTray.isSales = Integer.Parse(dtSetInTray.Rows(i)("IsSale").ToString())

                trayObj.listOfSet.Add(setWithTray)
            Next

            trayObj.ResultStatus = "Success"
        Else
            trayObj.ResultStatus = "Fail"
        End If

        Return trayObj


    End Function

End Class