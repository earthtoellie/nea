Public Class Form7
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item In countrylist
            CheckedListBox1.Items.Add(item)
        Next
        For Each item In indicatorlist
            CheckedListBox2.Items.Add(item)
        Next
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckLists(CheckedListBox1, 2)
        CheckLists(CheckedListBox2, 1)
        selectedindicator = CheckedListBox2.SelectedItem
        For Each item In CheckedListBox1.CheckedItems
            selectedcountries.Add(item)
        Next
        GenerateDataSet(selectedindicator, selectedcountries(0), datasetX)
        GenerateDataSet(selectedindicator, selectedcountries(1), datasetY)
        graphs.Show()
        Me.Close()
    End Sub
End Class