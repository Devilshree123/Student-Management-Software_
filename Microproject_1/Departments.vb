Imports System.Data.SqlClient
Public Class Departments
    Dim conn = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\devil\Documents\stdntmngmntsys.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Display()
        conn.open()
        Dim query = "select * from Department"
        Dim adapter As New SqlDataAdapter
        Dim cmd = New SqlCommand(query, conn)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DepDatagridview.DataSource = ds.Tables(0)
        conn.close()
    End Sub
    Private Sub reset()
        DepNameTb.Text = ""
        DepDescriptionTb.Text = ""
        DepDurationTb.Text = ""
    End Sub

    Private Sub DepSaveBtn_Click(sender As Object, e As EventArgs) Handles DepSaveBtn.Click
        If DepNameTb.Text = "" Or DepDescriptionTb.Text = "" Or DepDurationTb.Text = "" Then
            MsgBox("Missing Information")
        Else
            Try
                conn.open()
                Dim query = "insert into Department values('" & DepNameTb.Text & "','" & DepDescriptionTb.Text & "','" & DepDurationTb.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Department Saved")
                conn.close()
                Display()
                reset()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Departments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub

    Private Sub DepResetBtn_Click(sender As Object, e As EventArgs) Handles DepResetBtn.Click
        reset()
    End Sub

    Private Sub DepDeleteBtn_Click(sender As Object, e As EventArgs) Handles DepDeleteBtn.Click
        If key = 0 Then
            MsgBox("Please Seletct The Department")
        Else
            Try
                conn.open()
                Dim query = "delete from Department where Depid = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Department Deleted")
                conn.close()
                Display()
                reset()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Dim key = 0
    Private Sub DepDatagridview_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DepDatagridview.CellMouseClick
        Dim row As DataGridViewRow = DepDatagridview.Rows(e.RowIndex)
        DepNameTb.Text = row.Cells(1).Value.ToString
        DepDescriptionTb.Text = row.Cells(2).Value.ToString
        DepDurationTb.Text = row.Cells(3).Value.ToString
        If DepNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub DepEditBtn_Click(sender As Object, e As EventArgs) Handles DepEditBtn.Click
        If DepNameTb.Text = "" Or DepDescriptionTb.Text = "" Or DepDurationTb.Text = "" Then
            MsgBox("Please Select The Department")
        Else
            Try
                conn.open()
                Dim query = "update Department set  Depname='" & DepNameTb.Text & "',Dpdis='" & DepDescriptionTb.Text & "',Depdur='" & DepDurationTb.Text & "'where Depid= " & key & " "
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Department Updated")
                conn.close()
                Display()
                reset()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
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