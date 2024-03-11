Imports System.Data.SqlClient
Public Class Salary

    Dim Con As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Public position As String = ""
    Public Nam As String = ""
    Public total As Integer

    Private Sub fetchemployeedata()
        Con.Open()
        Dim query = "select*from Employeetale Where Empname=" & TextBox4.Text & ""
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, Con)
        Dim dt As DataTable
        dt = New DataTable
        Dim sda As SqlDataAdapter
        sda = New SqlDataAdapter(cmd)
        sda.Fill(dt)
        For Each dr As DataRow In dt.Rows
            Label2.Text = dr(1).ToString()
        Next
        Con.Close()
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
        Mainform.Show()
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Con.Open()

        Dim sql As String = "select Empname,Emppos from Employeetable where EmpId = '" & TextBox4.Text & "'"
        Dim cmd As New SqlCommand(sql, Con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader

        If myreader.Read() Then
            Label1.Text = myreader("Empname")
            ' Label13.Text = myreader("Empadd")
            ' Label11.Text = myreader("Empgender")

            Label6.Text = myreader("Emppos")
            position = myreader("Emppos")
            Nam = myreader("Empname")
            ' Label10.Text = myreader("Eblic mpphone")
            ' Label15.Text = myreader("Empeducation")
            ' Label9.Text = myreader("Empdob")
        Else
            Label1.Text = ""
            Label6.Text = ""
            position = ""
            Nam = ""
            MsgBox("Data Not found", MsgBoxStyle.Critical)
        End If

        Con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox2.Text < 1 Or TextBox2.Text > 30 Then
            MsgBox("Select date b/w 1 And 30", MsgBoxStyle.Critical)
        Else
            Dim w As Integer = TextBox2.Text
            Dim t As Integer
            If position = "Security" Then
                t = w * 500
            ElseIf position = "IT" Then
                t = w * 800
            ElseIf position = "Accountant" Then
                t = w * 750
            ElseIf position = "Cleaner" Then
                t = w * 350
            ElseIf position = "Employee" Then
                t = w * 700

            End If
            total = t




            Label12.Text = t
            Label9.Text = position
            Label7.Text = Nam
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Print.Show()
        Print.Label1.Text = Nam
        Print.Label2.Text = position
        Print.Label4.Text = total


    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MsgBox("This field will accept Numbers only", MsgBoxStyle.Critical)
        End If
    End Sub
    Public Sub salary_cal()
        '''''''''
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox4.Focus()
    End Sub

    Private Sub Salary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox4.Focus()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MsgBox("This field will accept Numbers only", MsgBoxStyle.Critical)
        End If
    End Sub
End Class