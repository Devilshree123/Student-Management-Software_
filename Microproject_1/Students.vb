Imports System.Data.SqlClient
Public Class Students
    Dim conn = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\devil\Documents\stdntmngmntsys.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub clear()
        StdNameTb.Text = ""
        StdGenderCb.SelectedIndex = -1
        StdPhoneTb.Text = ""
        StdDepartmentCb.SelectedIndex = -1
        StdFeesTb.Text = ""
    End Sub
    Private Sub Display()
        conn.open()
        Dim query = "select * from StudentTable"
        Dim adapter As New SqlDataAdapter
        Dim cmd = New SqlCommand(query, conn)
        adapter = New SqlDataAdapter(cmd)
        Dim builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        StdDatagridview.DataSource = ds.Tables(0)
        conn.close()
    End Sub
    Private Sub FillDepartment()
        conn.open()
        Dim query = "select * from Department"
        Dim cmd As New SqlCommand(query, conn)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        StdDepartmentCb.DataSource = Tbl
        StdDepartmentCb.DisplayMember = "Depname"
        StdDepartmentCb.ValueMember = "Depname"
        conn.close()
    End Sub
    Private Sub StdSaveBtn_Click(sender As Object, e As EventArgs) Handles StdSaveBtn.Click
        If StdNameTb.Text = "" Or StdFeesTb.Text = "" Or StdPhoneTb.Text = "" Or StdGenderCb.SelectedIndex = -1 Or StdDepartmentCb.SelectedIndex = -1 Then
            MsgBox("Missing Information")
        Else
            Try
                conn.open()
                Dim query = "insert into StudentTable values('" & StdNameTb.Text & "','" & StdGenderCb.SelectedItem.ToString() & "','" & StdDOB.Value.Date.Year.ToString() & "','" & StdPhoneTb.Text & "','" & StdDepartmentCb.SelectedItem.ToString() & "','" & StdFeesTb.Text & "')"
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Student Info Saved")
                conn.close()
                Display()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Students_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
        FillDepartment()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Application.Exit()
    End Sub

    Private Sub StdDeleteBtn_Click(sender As Object, e As EventArgs) Handles StdDeleteBtn.Click
        If key = 0 Then
            MsgBox("Please Seletct The Student")
        Else
            Try
                conn.open()
                Dim query = "delete from StudentTable where stid = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Student Deleted")
                conn.close()
                Display()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub StdResetBtn_Click(sender As Object, e As EventArgs) Handles StdResetBtn.Click
        clear()
    End Sub

    Dim key = 0
    Private Sub StdDatagridview_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles StdDatagridview.CellMouseClick
        Dim row As DataGridViewRow = StdDatagridview.Rows(e.RowIndex)
        StdNameTb.Text = row.Cells(1).Value.ToString
        StdGenderCb.SelectedItem = row.Cells(2).Value.ToString
        StdDOB.Text = row.Cells(3).Value.ToString
        StdPhoneTb.Text = row.Cells(4).Value.ToString
        StdDepartmentCb.SelectedItem = row.Cells(5).Value.ToString
        StdFeesTb.Text = row.Cells(6).Value.ToString
        If StdNameTb.Text = "" Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub StdEditBtn_Click(sender As Object, e As EventArgs) Handles StdEditBtn.Click
        If StdNameTb.Text = "" Or StdFeesTb.Text = "" Or StdPhoneTb.Text = "" Or StdGenderCb.SelectedIndex = -1 Or StdDepartmentCb.SelectedIndex = -1 Then
            MsgBox("Please Select The Student")
        Else
            Try
                conn.open()
                Dim query = "update StudentTable set  StName='" & StdNameTb.Text & "',StGender='" & StdGenderCb.SelectedItem.ToString & "',StDOB='" & StdDOB.Text & "',StPhone='" & StdPhoneTb.Text & "',StDep='" & StdDepartmentCb.SelectedItem.ToString & "',StFees='" & StdFeesTb.Text & "' where StId= " & key & " "
                Dim cmd As SqlCommand
                cmd = New SqlCommand(query, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Department Updated")
                conn.close()
                Display()
                clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
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