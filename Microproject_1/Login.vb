Public Class Login
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        usrnameTB.Text = ""
        psswrdTb.Text = ""
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        If usrnameTB.Text = "" Or psswrdTb.Text = "" Then
            MsgBox("Missing Information")
        ElseIf usrnameTB.Text = "Shreyas" And psswrdTb.Text = "DRIPTS" Then
            Dim obj = New Dashboard()
            obj.Show()
            Me.Hide()
        Else
            MsgBox("Wrong Username and Password")
            usrnameTB.Text = ""
            psswrdTb.Text = ""
        End If
    End Sub
End Class