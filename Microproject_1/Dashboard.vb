Imports System.Data.SqlClient
Public Class Dashboard
    Dim conn = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\devil\Documents\stdntmngmntsys.mdf;Integrated Security=True;Connect Timeout=30")

    Private Sub countstud()
        Dim stdnum As Integer
        conn.open()
        Dim sql = "select count(*) from StudentTable"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, conn)
        stdnum = cmd.ExecuteScalar
        stdlbl.Text = stdnum
        conn.close()
    End Sub
    Private Sub countdepartment()
        Dim depnum As Integer
        conn.open()
        Dim sql = "select count(*) from Department"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, conn)
        depnum = cmd.ExecuteScalar
        Departmentslbl.Text = depnum
        conn.close()
    End Sub
    Private Sub Countfees()
        Dim feesnum As Integer
        conn.open()
        Dim sql = "select Sum(Amount) from PaymentTable"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(sql, conn)
        Dim Am As String
        feesnum = cmd.ExecuteScalar
        Feeslbl.Text = feesnum
        conn.close()
    End Sub
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        countstud()
        countdepartment()
        Countfees()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Dim obj = New Login()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim obj = New Students()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Dim obj = New Departments()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Dim obj = New Fees()
        obj.Show()
        Me.Hide()
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Dim obj = New Dashboard()
        obj.Show()
        Me.Hide()
    End Sub
End Class