Public Class Timer

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Timer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        Label1.Text = Format(TimeOfDay, "HH:mm:ss")
        'Dim t As Date = Label2.Text
        'Dim diff As Integer = DateDiff(DateInterval.Minute, t, TimeOfDay)
        'If (diff = 5) Then
        'For z As Integer = 0 To 5
        'Console.Beep()
        'Next
        'MessageBox.Show(TextBox1.Text, " in 5 mins")

        'End If


        If (Label1.Text = Label2.Text) Then
            For x As Integer = 0 To 40
                Console.Beep()
            Next

            MessageBox.Show(TextBox1.Text)

        End If


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim i As Integer = NumericUpDown1.Value
        Dim k As Integer = NumericUpDown2.Value
        Label2.Text = DateAdd(DateInterval.Hour, i, TimeOfDay)
        Dim temp As Date = Label2.Text
        Dim temp2 As Date
        Dim filename As String = TextBox1.Text
        temp2 = DateAdd(DateInterval.Minute, k, temp)
        Label2.Text = Format(temp2, "HH:mm:ss")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Label2.Text = "00:00:00"
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        IO.File.WriteAllText("C:\users\" + Environment.UserName + "\documents\kobt\" + TextBox1.Text + ".txt", Label2.Text)
        MessageBox.Show("Saved as " + TextBox1.Text, "press ok", MessageBoxButtons.OKCancel)
    End Sub
End Class
