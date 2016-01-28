Imports System.IO

Public Class Timer

    Public flag As Boolean = False
    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Timer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MdiParent = Kobt
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Date.Now.ToString("dd/MM/yyyy")


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim i As Integer = NumericUpDown1.Value
        Dim k As Integer = NumericUpDown2.Value
        Label2.Text = DateAdd(DateInterval.Hour, i, TimeOfDay)
        Dim temp As Date = Label2.Text
        Dim temp2 As Date
        temp2 = DateAdd(DateInterval.Minute, k, temp)
        Label2.Text = temp2

        '*****SAVE CODE TO SET BUTTON'S FUNCTION TO SAVE & SET *****

        Dim currentuser As String = Environment.UserName
        Dim strFolder = "C:\users\" + currentuser + "\documents\kobt\"
        Dim filepath As String = Path.Combine(strFolder, TextBox1.Text)
        If String.IsNullOrEmpty(TextBox1.Text) Then
            MessageBox.Show("Boss Name can't be empty!", "Empty Boss Name", MessageBoxButtons.OK)
        ElseIf String.IsNullOrWhiteSpace(TextBox1.Text) Then
            MessageBox.Show("Boss Name can't be Space!", "Space as Boss Name", MessageBoxButtons.OK)
        Else
            If Not System.IO.Directory.Exists(strFolder) Then
                System.IO.Directory.CreateDirectory(strFolder)
                Dim ind As Integer = ComboBox1.SelectedIndex
                
                Using sw As StreamWriter = New StreamWriter(filepath)
                    sw.WriteLine(Label2.Text)
                    sw.WriteLine(Label1.Text)
                    sw.WriteLine(ind)
                End Using
                'IO.File.WriteAllText(strFolder + TextBox1.Text, Label2.Text)
                'MessageBox.Show("Saved as " + TextBox1.Text, "Succes", MessageBoxButtons.OK)
            Else
                If System.IO.File.Exists(filepath) Then
                    MessageBox.Show("File " + TextBox1.Text + "  exists. (Input the zone after the Boss name)", "Warning")

                Else
                    Dim ind As Integer = ComboBox1.SelectedIndex
                    Using sw As StreamWriter = New StreamWriter(filepath)
                        sw.WriteLine(Label2.Text)
                        sw.WriteLine(Label1.Text)
                        sw.WriteLine(ind)
                    End Using
                    'IO.File.WriteAllText(strFolder + TextBox1.Text, Label2.Text)
                    'MessageBox.Show("Saved as " + TextBox1.Text, "Succes", MessageBoxButtons.OK) 
                End If

            End If
        End If




        '***** FUNCTION UPDATE ENDS HERE *****
        If Not System.IO.File.Exists(filepath) Then
            Dim tray As New Boss
            tray.MdiParent = Kobt
            tray.Label2.Text = Me.TextBox1.Text
            Dim traytime As Date = Label2.Text
            tray.Label1.Text = Format(traytime, "HH:mm:ss")
            tray.Text = Me.TextBox1.Text
            tray.Button2.Text = Me.Label1.Text
            If ComboBox1.SelectedIndex() = 1 Then
                tray.BackColor = Color.DodgerBlue
            ElseIf ComboBox1.SelectedIndex() = 2 Then
                tray.BackColor = Color.Firebrick
            ElseIf ComboBox1.SelectedIndex() = 3 Then
                tray.BackColor = Color.Green
            ElseIf ComboBox1.SelectedIndex() = 4 Then
                tray.BackColor = Color.DarkBlue
            ElseIf ComboBox1.SelectedIndex() = 5 Then
                tray.BackColor = Color.Indigo
            ElseIf ComboBox1.SelectedIndex() = 6 Then
                tray.BackColor = Color.HotPink

            End If
            Me.Close()
            tray.Show()
        End If


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
                Using sw As StreamWriter = New StreamWriter(TextBox1.Text)

                End Using
                IO.File.WriteAllText(strFolder + TextBox1.Text, Label2.Text)
                'MessageBox.Show("Saved as " + TextBox1.Text, "press ok", MessageBoxButtons.OK)
            Else
                IO.File.WriteAllText(strFolder + TextBox1.Text, Label2.Text)
                'MessageBox.Show("Saved as " + TextBox1.Text, "press ok", MessageBoxButtons.OK)
            End If

        End If

    End Sub

End Class
