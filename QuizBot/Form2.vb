Imports System.IO
Imports System.Text

Public Class Form2
    Dim ans As String
    Dim rand = New System.Random()
    Dim easybd = 5
    Dim midbd = 15
    Dim hardbd = 25
    Public now = 0
    Dim used(100) As Boolean
    Public realans As String


    Private Sub Form2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.Visible = 1

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ii As Integer
        Randomize()
        For ii = 1 To 80
            used(ii) = False
        Next
        Loadprob(1)
    End Sub
    Private Sub Loadprob(difficulty As Integer)
        Dim lc, tot, current As Integer
        ProgressBar1.Value = 0
        Label1.Text = 7
        now += 1
        Label3.Text = "进度：" + now.ToString + " / 25"
        lc = tot = 0
        If difficulty = 1 Then
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\easy.txt")
        End If
        If difficulty = 2 Then
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\mid.txt")
        End If
        If difficulty = 3 Then
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "\hard.txt")
        End If
        lc = TextBox1.Lines.Count()
        tot = lc / 6
        current = rand.Next(1, tot + 1)
        While used(current) = True
            current = rand.Next(1, tot + 1)
        End While
        Label2.Text = TextBox1.Lines.GetValue((current - 1) * 6)
        Button1.Text = "A. " + TextBox1.Lines.GetValue((current - 1) * 6 + 1)
        Button2.Text = "B. " + TextBox1.Lines.GetValue((current - 1) * 6 + 2)

        Button3.Text = "C. " + TextBox1.Lines.GetValue((current - 1) * 6 + 3)

        Button4.Text = "D. " + TextBox1.Lines.GetValue((current - 1) * 6 + 4)
        ans = TextBox1.Lines.GetValue((current - 1) * 6 + 5)
        If (ans = "A") Then realans = Button1.Text
        If (ans = "B") Then realans = Button2.Text
        If (ans = "C") Then realans = Button3.Text
        If (ans = "D") Then realans = Button4.Text
        used(current) = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.PerformStep()
        If (ProgressBar1.Value Mod 20 = 0) Then
            Label1.Text = 7 - ProgressBar1.Value / 20
        End If
        If (ProgressBar1.Value = 140) Then failedto()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (ans = "A") Then
            gonext()
        Else failedto()
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (ans = "B") Then
            gonext()
        Else failedto()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (ans = "C") Then
            gonext()
        Else failedto()
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (ans = "D") Then
            gonext()
        Else failedto()
        End If
    End Sub
    Private Sub gonext()
        Dim ii As Integer
        If (now = easybd Or now = midbd Or now = hardbd) Then
            For ii = 1 To 80
                used(ii) = False
            Next
        End If
        If (now < easybd) Then
            Loadprob(1)
        ElseIf (now < midbd) Then
            Loadprob(2)
        ElseIf (now < hardbd) Then
            Loadprob(3)
        Else
            now += 1
            Form4.Show()
        End If
    End Sub
    Private Sub failedto()
        Form3.Show()
    End Sub
End Class