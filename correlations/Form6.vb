Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item In countrylist
            CheckedListBox1.Items.Add(item)
        Next
        For Each item In indicatorlist
            CheckedListBox2.Items.Add(item)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckLists(CheckedListBox1, 1)
        CheckLists(CheckedListBox2, 2)
        Dim selectedindicators As New List(Of String)
        Dim selectedcountry As String
        selectedcountry = CheckedListBox1.SelectedItem
        For Each item In CheckedListBox2.CheckedItems
            selectedindicators.Add(item)
        Next
        GenerateDataSet(selectedindicators(0), selectedcountry, datasetX)
        GenerateDataSet(selectedindicators(1), selectedcountry, datasetY)
        graphs.Show()
        Me.Close()
    End Sub
End Class