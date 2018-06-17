Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = "您取得的成绩是：" + (Form2.now - 1).ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Close()
        Form3.Close()
        Me.Close()
    End Sub
End Class