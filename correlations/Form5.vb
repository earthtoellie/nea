Imports System
Imports Microsoft.VisualBasic.FileIO.TextFieldParser
Imports System.Globalization
Public Module GlobalVaraibles
    Public countries As New List(Of List(Of Country))
    Public Indicators As New List(Of List(Of Indicator))
    Public countrylist As New List(Of String)
    Public indicatorlist As New List(Of String)
    Public selectedindicator As String
    Public selectedcountries As New List(Of String)
    Public datasetX, datasetY As New List(Of Decimal)
    Public Sub CheckLists(ByVal checklist As CheckedListBox, ByVal maximum As Integer)
        Try
            Dim count As Integer = 0
            For Each chkbox In checklist.Items
                If chkbox.selected Then
                    count += 1
                End If
                If count > maximum Then
                    Exit For
                End If
            Next
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()
        End Try
    End Sub
    Public Sub GenerateDataSet(ByVal indicator As String, ByVal country As String, ByRef dataset As List(Of Decimal))
        Dim countryindex, multi, start, finish, x As Integer
        Dim found As Boolean = False
        multi = countries.Count()
        x = 0
        While found = False
            If countrylist(x) = country Then
                countryindex = x
                found = True
            Else
                x += 1
            End If
        End While
        start = multi * (countryindex)
        finish = start + multi
        For y = start To finish
            For z = 0 To 55
                If Indicators(y)(z).indicatorname = indicator Then
                    dataset.Add(countries(y)(z).number)
                End If
            Next
        Next
    End Sub
End Module
Public Class Form5
    Public Sub Form5_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim afile As FileIO.TextFieldParser = New FileIO.TextFieldParser("C:\Users\New\Downloads\WDI_csv\WDI_data.csv")
        Dim CurrentRecord As String()
        Dim firstline As String
        Dim firstlinearray As String()
        firstline = afile.ReadLine()
        firstlinearray = firstline.Split(New Char() {","c})
        afile.TextFieldType = FileIO.FieldType.Delimited
        afile.Delimiters = New String() {","}
        afile.HasFieldsEnclosedInQuotes = True
        Do Until afile.EndOfData = True
            Try
                CurrentRecord = afile.ReadFields()
                Dim tempindicators As New List(Of Indicator)
                Dim tempcountries As New List(Of Country)
                If countrylist.Contains(CurrentRecord(0)) = False Then
                    countrylist.Add(CurrentRecord(0))
                End If
                If indicatorlist.Contains(CurrentRecord(2)) = False Then
                    indicatorlist.Add(CurrentRecord(2))
                End If
                For x = 0 To 55
                    Dim i As New Indicator
                    Dim c As New Country
                    i.indicatorname = CurrentRecord(3)
                    i.year = Int(firstlinearray(x + 5))
                    i.number = (Decimal.Parse(CurrentRecord(x + 5), NumberStyles.AllowExponent))
                    c.countryname = CurrentRecord(0)
                    c.year = Int(firstlinearray(x + 5))
                    c.number = (CurrentRecord(x + 5))
                    tempcountries.Add(c)
                    tempindicators.Add(i)
                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Console.ReadLine()
                Continue Do
            End Try
        Loop
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            If RadioButton1.Checked And RadioButton2.Checked = False And RadioButton3.Checked = False Then
                Form6.Show()
                Me.Close()
            End If
            If RadioButton2.Checked And RadioButton1.Checked = False And RadioButton3.Checked = False Then
                Form7.Show()
                Me.Close()
            End If
            If RadioButton3.Checked And RadioButton2.Checked = False And RadioButton1.Checked = False Then
                Form8.Show()
                Me.Close()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.ReadLine()
        End Try
    End Sub
End Class
Public Class Country
    Inherits Value
    Public countryname As String
End Class
Public Class Indicator
    Inherits Value
    Public indicatorname As String
End Class
Public Class Value
    Public year As Integer
    Public number As String
End Class
Public Class Correlations
    Function PearsonsCorrelation(ByRef firstset As Array, ByRef secondset As Array)
        Dim sxx, sxy, syy, r, sx, sy, sxsq, sysq, sxesq, syesq, ssxy As Long
        For x = 1 To firstset.Length
            sx += firstset(x)
            sxsq = firstset(x) ^ 2
            sxesq += firstset(x) ^ 2
            ssxy += firstset(x) * secondset(x)
        Next
        For y = 1 To secondset.Length
            sy += secondset(y)
            sysq = secondset(y) ^ 2
            syesq += secondset(y) ^ 2
        Next
        sxy = ssxy - ((sx * sy) / firstset.Length)
        sxx = (sxsq - ((sx ^ 2) / firstset.Length))
        syy = (sysq - ((sy ^ 2) / secondset.Length))
        r = (sxy / (sxx * syy))
        Return r
    End Function
End Class
