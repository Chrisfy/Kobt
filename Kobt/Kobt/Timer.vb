Public Class Timer

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Timer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        '##old----Label1.Text = Format(TimeOfDay, "HH:mm:ss")
        Dim t As Date = Label2.Text
        Dim diff As Integer = DateDiff(DateInterval.Minute, t, TimeOfDay)
        If diff = 5 Then
            For z As Integer = 0 To 5
                Console.Beep()
            Next
            MessageBox.Show(TextBox1.Text, " in 5 mins..")

        End If

        If (TimeOfDay = Label2.Text) Then
            For x As Integer = 0 To 10
                Console.Beep()
            Next

            MessageBox.Show(TextBox1.Text, " is respawning!")

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
        Label1.Text = TimeOfDay.Date

        Label2.Text = Format(temp2, "HH:mm:ss")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Label2.Text = "00:00:00"
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim currentuser As String = Environment.UserName
        Dim strFolder = "C:\users\" + currentuser + "\documents\kobt\"
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Boss Name can't be empty!", "Empty Boss Name", MessageBoxButtons.OK)
        ElseIf String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Boss Name can't be Space!", "Space as Boss Name", MessageBoxButtons.OK)
        Else
            If Not System.IO.Directory.Exists(strFolder) Then
                System.IO.Directory.CreateDirectory(strFolder)
                IO.File.WriteAllText(strFolder + TextBox1.Text, Label2.Text)
                MessageBox.Show("Saved as " + TextBox1.Text, "press ok", MessageBoxButtons.OK)
            Else
                IO.File.WriteAllText(strFolder + TextBox1.Text, Label2.Text)
                MessageBox.Show("Saved as " + TextBox1.Text, "press ok", MessageBoxButtons.OK)
            End If

        End If

    End Sub

    'Public Sub Button4_Click(sender As System.Object, e As System.EventArgs)
    ' If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    ' TextBox1.Text = OpenFileDialog1.SafeFileName
    ' Label2.Text = IO.File.ReadAllText(OpenFileDialog1.FileName)
    ' MessageBox.Show("Respawn Time is: " + Label2.Text, "Loaded Boss: " + TextBox1.Text, MessageBoxButtons.OK)
    'End If
    ' End Sub
End Class
