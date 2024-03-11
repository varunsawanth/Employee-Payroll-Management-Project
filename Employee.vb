Imports System.Data.SqlClient

Public Class Employee
    Dim Con As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Dim a As String = ""
    Dim dt As String = ""

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        auto()

        Populate()
        WindowState = FormWindowState.Maximized
    End Sub
    Public Sub auto()
        Con.Open()
        Dim sqlstr As String = "select Max(EmpId) + 1 from Employeetable "
        Dim cmd As SqlCommand = New SqlCommand(sqlstr, Con)
        Dim dr1 As SqlDataReader = cmd.ExecuteReader

        If dr1.Read Then
            a = IIf(IsDBNull(dr1(0)), 1, dr1(0))

        End If

        Con.Close()
    End Sub
    Public Sub Populate()
        Con.Open()
        Dim sql = "select * from Employeetable"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, Con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        EmployeeDVG.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Con.Open()
        Dim Query As String
        Query = "insert into Employeetable values('" & a & "','" & Empname.Text() & "','" & Empadd.Text() & "','" & Empgender.SelectedItem.ToString() & "','" & Emppos.SelectedItem.ToString() & "','" & Empphone.Text() & "','" & Empeducation.SelectedItem.ToString() & "','" & Empdob.Value() & "' )"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(Query, Con)
        cmd.ExecuteNonQuery()
        If MsgBox("Employee Added") Then

        Else
            MessageBox.Show("Please Fill The All The Deatils")
        End If


        Con.Close()
        Populate()
    End Sub
    Dim key = 0
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim q As Integer = InputBox("Please Enter the Employee ID ")
        If (MsgBox("Do you want to Delete this Employee ", vbYesNo + vbQuestion) = vbYes) Then
            Con.Open()
            Dim cmd = New SqlCommand("delete from Employeetable where EmpId ='" & q & "'", Con)
            cmd.ExecuteNonQuery()
            Con.Close()
            MsgBox("Employee Sucessfully Deleted ", vbInformation)
        End If

        Populate()




    End Sub



    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        edit()






    End Sub
    Public Sub edit()
        Con.Open()

        Dim sql As String = "update  Employeetable set Empname = '" & Empname.Text() & "',Empadd='" & Empadd.Text() & "',Empgender='" & Empgender.SelectedItem.ToString() & "',Emppos='" & Emppos.SelectedItem.ToString() & "',Empphone='" & Empphone.Text() & "',Empeducation ='" & Empeducation.SelectedItem.ToString() & "',Empdob = '" & Empdob.Value() & "' where Empid='" & TextBox1.Text & "' "

        Dim cmd As New SqlCommand(sql, Con)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Employee updated SucessFully .... ", "SuccesssFull", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Con.Close()
        Populate()


    End Sub

    Private Sub EmployeeDVG_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles EmployeeDVG.CellClick
        Dim index As Integer
        index = e.RowIndex


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Mainform.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Con.Open()

        Dim sql As String = "select Empname,Empadd,Empgender,Emppos,Empphone,Empeducation,Empdob from Employeetable where EmpId = '" & TextBox1.Text & "'"
        Dim cmd As New SqlCommand(sql, Con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        If myreader.Read() Then
            Empname.Text = myreader("Empname")
            Empadd.Text = myreader("Empadd")
            Empgender.Text = myreader("Empgender")
            Emppos.Text = myreader("Emppos")
            Empphone.Text = myreader("Empphone")
            Empeducation.Text = myreader("Empeducation")
            Empdob.Text = myreader("Empdob")

        Else

            Empname.Text = ""
            Empadd.Text = ""
            Empgender.Text = ""
            Emppos.Text = ""
            Empphone.Text = ""
            Empeducation.Text = ""
            Empdob.Text = ""
            MsgBox("Data Not Found", MsgBoxStyle.Critical)
        End If

        Con.Close()


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.SelectAll()
    End Sub

    Private Sub Empname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Empname.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MsgBox("This field will accept Letters only", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub Empphone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Empphone.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MsgBox("This field will accept Numbers only", MsgBoxStyle.Critical)
        End If
        If (Empphone.Text.Length >= 10) Then
            If e.KeyChar <> ControlChars.Back Then
                MsgBox("Phone Numbers Should Not Be More Than 10 Numbers", MsgBoxStyle.Critical)


            End If
        End If

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MsgBox("This field will accept Numbers only", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Hide()
        Dim login_page1 = New login_page1
        login_page1.Show()
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Me.Hide()
        Dim login_page1 = New login_page1
        login_page1.Show()
    End Sub

    Private Sub Empname_TextChanged(sender As Object, e As EventArgs) Handles Empname.TextChanged

    End Sub
End Class