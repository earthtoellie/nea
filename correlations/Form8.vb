Public Class Form8
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each item In countrylist
            CheckedListBox1.Items.Add(item)
            CheckedListBox3.Items.Add(item)
        Next
        For Each item In indicatorlist
            CheckedListBox2.Items.Add(item)
            CheckedListBox4.Items.Add(item)
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckLists(CheckedListBox1, 1)
        CheckLists(CheckedListBox2, 1)
        CheckLists(CheckedListBox3, 1)
        CheckLists(CheckedListBox4, 1)
        Dim selectedindicatora, selectedcountrya, selectedindicatorb, selectedcountryb As String
        selectedindicatora = CheckedListBox2.SelectedItem
        selectedcountrya = CheckedListBox1.SelectedItem
        selectedcountryb = CheckedListBox3.SelectedItem
        selectedindicatorb = CheckedListBox4.SelectedItem
        GenerateDataSet(selectedindicatora, selectedcountrya, datasetX)
        GenerateDataSet(selectedindicatorb, selectedcountryb, datasetY)
        graphs.Show()
        Me.Close()
    End Sub
End Class