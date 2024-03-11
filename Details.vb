Imports System.Data.SqlClient

Public Class Details

    Dim Con As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
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
            Label12.Text = dr(1).ToString()
        Next
        Con.Close()

    End Sub
    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Con.Open()

        Dim sql As String = "select Empname,Empadd,Empgender,Emppos,Empphone,Empeducation,Empdob from Employeetable where EmpId = '" & TextBox4.Text & "'"
        Dim cmd As New SqlCommand(sql, Con)
        Dim myreader As SqlDataReader
        myreader = cmd.ExecuteReader
        If myreader.Read() Then

            Label12.Text = myreader("Empname")
            Label13.Text = myreader("Empadd")
            Label11.Text = myreader("Empgender")
            Label14.Text = myreader("Emppos")
            Label10.Text = myreader("Empphone")
            Label15.Text = myreader("Empeducation")
            Label9.Text = myreader("Empdob")

        Else

            Label12.Text = ""
            Label13.Text = ""
            Label11.Text = ""
            Label14.Text = ""
            Label10.Text = ""
            Label15.Text = ""
            Label9.Text = ""
            MessageBox.Show("Data Not Found")
        End If
        Con.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
        Mainform.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub


    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not e.KeyChar = Chr(Keys.Space) Then
            e.Handled = True
            MessageBox.Show("This field will accept Numbers only")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Print.Show()

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub
End Class