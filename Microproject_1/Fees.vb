Imports System.Data.SqlClient
Public Class Fees
    Dim conn = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\devil\Documents\stdntmngmntsys.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub FillStudent()
        conn.open()
        Dim query = "select * from StudentTable"
        Dim cmd As New SqlCommand(query, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        FeesStdIdCb.DataSource = Tbl
        FeesStdIdCb.DisplayMember = "StId"
        FeesStdIdCb.ValueMember = "StId"
        conn.close()
    End Sub
    Private Sub Display()
        conn.open()
        Dim query = "select * from PaymentTable"
        Dim adapter As New SqlDataAdapter
        Dim cmd = New SqlCommand(query, conn)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        FeesDatagridview.DataSource = ds.Tables(0)
        conn.close()
    End Sub
    Private Sub GetsName()
        conn.open()
        Dim query = "select * from StudentTable where StId = " & FeesStdIdCb.SelectedValue.ToString() & ""
        Dim cmd As New SqlCommand(query, conn)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            FeesStdNameTb.Text = reader(1).ToString()
        End While
        conn.close()
    End Sub
    Private Sub GetsFees()
        conn.open()
        Dim query = "select * from StudentTable where StId = " & FeesStdIdCb.SelectedValue.ToString() & ""
        Dim cmd As New SqlCommand(query, conn)
        Dim dt As New DataTable
        Dim reader As SqlDataReader
        reader = cmd.ExecuteReader()
        While reader.Read
            FeesAmtTb.Text = reader(6).ToString()
        End While
        conn.close()
    End Sub
    Private Sub clear()
        FeesAmtTb.Text = ""
        FeesStdIdCb.SelectedIndex = -1
        FeesStdNameTb.Text = ""
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub FeesPayBtn_Click(sender As Object, e As EventArgs) Handles FeesPayBtn.Click
        If FeesStdIdCb.Text = "" Or FeesAmtTb.Text = "" Then
            MsgBox("Missing Information")

        Else
            Try
                conn.open()
                Dim query = "insert into PaymentTable values('" & FeesStdIdCb.Text & "','" & FeesStdNameTb.Text & "','" & FeesAmtTb.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                conn.close()
                MsgBox("Payment Successful")
                Display()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Fees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
        FillStudent()

    End Sub

    Private Sub FeesStdIdCb_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles FeesStdIdCb.SelectionChangeCommitted
        GetsName()
        GetsFees()
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