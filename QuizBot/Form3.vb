Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = Form2.realans
        If (Form2.now > 15) Then button1.visible=False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form4.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.ProgressBar1.Value = 0
        Form2.Label1.Text = 7
        Me.Close()
    End Sub
End Class