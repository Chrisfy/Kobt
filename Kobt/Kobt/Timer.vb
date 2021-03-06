Imports System.IO

Public Class Timer


    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Timer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MdiParent = Kobt
        Label1.Text = Format(Now(), "short date")
        OvFlag = Kobt.OvFlag2
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick



    End Sub
    Dim SaveFlag As Boolean
    Public OvFlag As Boolean
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim i As Integer = NumericUpDown1.Value
        Dim k As Integer = NumericUpDown2.Value
        Label2.Text = DateAdd(DateInterval.Hour, i, TimeOfDay)
        Dim temp As Date = Label2.Text
        Dim temp2 As Date
        temp2 = DateAdd(DateInterval.Minute, k, temp)
        Label2.Text = Format(temp2, "HH:mm:ss")

        '*****----SAVE CODE TO SET BUTTON'S FUNCTION TO SAVE & SET---- *****

        '#####Variable and path assign 
        Dim currentuser As String = Environment.UserName
        Dim strFolder = "C:\users\" + currentuser + "\documents\kobt\"
        Dim filepath As String = Path.Combine(strFolder, TextBox1.Text)
        '########Variable and path assign ends

        '##############Cheking Directory and Save parameters Condition
        If String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrWhiteSpace(TextBox1.Text) Or String.IsNullOrEmpty(ComboBox1.SelectedItem) Then
            MessageBox.Show("Boss and Zone Name can't be empty or space", "Wrong Parameters", MessageBoxButtons.OK)

        ElseIf OvFlag = False And Not System.IO.Directory.Exists(strFolder) Then
            System.IO.Directory.CreateDirectory(strFolder)
            '##############Check ends here
        ElseIf OvFlag = True Then
            Dim ind As Integer = ComboBox1.SelectedIndex
            Using sw As StreamWriter = New StreamWriter(filepath)
                sw.WriteLine(Label2.Text)
                sw.WriteLine(Label1.Text)
                sw.WriteLine(ind)
                sw.WriteLine(NumericUpDown1.Value)
                sw.WriteLine(NumericUpDown2.Value)
                SaveFlag = True
                Kobt.ToolStripStatusLabel16.Text = "Saved as " + TextBox1.Text
                Kobt.Timer2.Start()
            End Using
            '############ Checking File condition 
        ElseIf OvFlag = False And System.IO.File.Exists(filepath) Then
            Kobt.ToolStripStatusLabel16.Text = "Change Boss Name"
            Kobt.Timer2.Start()
            If MessageBox.Show("File " + TextBox1.Text + "  exists. Are you sure to Overwrite it?", "Warning", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
                SaveFlag = False
            Else
                Dim ind As Integer = ComboBox1.SelectedIndex
                Using sw As StreamWriter = New StreamWriter(filepath)
                    sw.WriteLine(Label2.Text)
                    sw.WriteLine(Label1.Text)
                    sw.WriteLine(ind)
                    sw.WriteLine(NumericUpDown1.Value)
                    sw.WriteLine(NumericUpDown2.Value)
                    SaveFlag = True
                    Kobt.ToolStripStatusLabel16.Text = "Saved as " + TextBox1.Text
                    Kobt.Timer2.Start()
                End Using
            End If

            '####### File Check Ends here

            '####### Actions If file not exists

        ElseIf OvFlag = False And Not System.IO.File.Exists(filepath) Then
            Dim ind As Integer = ComboBox1.SelectedIndex
            Using sw As StreamWriter = New StreamWriter(filepath)
                sw.WriteLine(Label2.Text)
                sw.WriteLine(Label1.Text)
                sw.WriteLine(ind)
                sw.WriteLine(NumericUpDown1.Value)
                sw.WriteLine(NumericUpDown2.Value)
                SaveFlag = True
                Kobt.ToolStripStatusLabel16.Text = "Saved as " + TextBox1.Text
                Kobt.Timer2.Start()
            End Using



        End If
        '###### Actions if file not exists ends here




        '***** FUNCTION UPDATE ENDS HERE *****

        If SaveFlag = True Then
            Dim tray As New Boss
            tray.MdiParent = Kobt
            tray.Label2.Text = Me.TextBox1.Text
            Dim traytime As Date = Label2.Text
            tray.Label1.Text = Format(traytime, "HH:mm:ss")
            tray.Text = Me.TextBox1.Text
            tray.Button2.Text = Me.Label1.Text
            tray.Label4.Text = NumericUpDown1.Value
            tray.Label5.Text = NumericUpDown2.Value
            tray.Label6.Text = ComboBox1.SelectedIndex
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
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Label2.Text = "00:00:00"
    End Sub
End Class
