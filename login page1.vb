Public Class login_page1

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

        Dim name = TextBox1.Text()
        Dim password = TextBox2.Text()
        If (name = "Varun" And password = "1234" Or name = "Nethravati" And password = "2345" Or name = "Sneha" And password = "3456") Then
            Mainform.Show()
            Me.Hide()

        Else
            TextBox2.Text = ""
            MsgBox("The enter user Id or Password in invalid", MsgBoxStyle.Critical)
        End If

        

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then

            TextBox2.UseSystemPasswordChar = False
        Else

            TextBox2.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Application.Exit()
    End Sub

    Private Sub login_page1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
    End Sub
End Class