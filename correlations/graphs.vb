Public Class graphs
    Private Sub graphs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x() As Integer = {1, 2, 3, 4, 5}
        Dim y() As Integer = {2, 1, 7, 3, 3}
        Chart1.Series("Series1").Points.DataBindXY(datasetX, datasetY)
    End Sub
End Class