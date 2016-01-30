Imports System.IO
Public Class Boss
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim backtimer As New Timer
        Kobt.ToolStripStatusLabel16.Text = "Reset timer"
        Kobt.Timer2.Start()
        backtimer.MdiParent = Kobt
        backtimer.NumericUpDown1.Value = System.Convert.ToDecimal(Label4.Text)
        backtimer.NumericUpDown2.Value = System.Convert.ToDecimal(Label5.Text)
        backtimer.TextBox1.Text = Me.Label2.Text
        backtimer.Label2.Text = Me.Label1.Text
        backtimer.ComboBox1.SelectedIndex = Label6.Text
        backtimer.Text = Label2.Text
        Me.Close()
        backtimer.Show()

    End Sub

    Private Sub Boss_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Kobt.OvFlag2 = True
        MaximizeBox = False
        MinimizeBox = False
        MdiParent = Kobt
        Timer1.Start()
    End Sub
    Public flag As Boolean = False
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        Dim d As Date = Label1.Text
        Dim tn As Date = TimeOfDay
        Dim left As TimeSpan = tn - d
        Dim hdiff As Integer = Math.Abs(left.Hours)
        Dim minDiff As Integer = Math.Abs(left.Minutes)
        Dim secDiff As Integer = Math.Abs(left.Seconds)

        If flag = False Then
            If hdiff = 0 And minDiff = 5 And secDiff = 0 Then
                For i As Integer = 0 To 5
                    Console.Beep()
                Next
                Dim a As String = " Is respawning in 5 minutes..."
                Label1.ForeColor = Color.Orange
                Button1.BackColor = Color.Orange
                Button1.ForeColor = Color.White
                MessageBox.Show(Label2.Text + a, "Attention Bitch")
            End If
        End If
        If (TimeOfDay = Label1.Text) Then
            For x As Integer = 0 To 15
                Console.Beep()
            Next
            Dim a As String = " is respawning!! "
            Label1.ForeColor = Color.Red
            Button1.BackColor = Color.Red
            Button1.ForeColor = Color.Black
            MessageBox.Show(Label2.Text + a, "Run Bitch")

        End If

        'Dim datecheck As String = Button2.Text
        Dim dDiff As Date = Button2.Text
        'Date.ParseExact(datecheck, "dd/MM/yyyy",
        'System.Globalization.DateTimeFormatInfo.InvariantInfo)
        If DateDiff(DateInterval.Day, Date.Now, dDiff) <= -1 Then
            Button2.BackColor = Color.Red
            Button2.ForeColor = Color.Red

        End If

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        MessageBox.Show("Killed on " + Button2.Text, "Date Killed", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Label1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDoubleClick
        Dim i As Integer = Label4.Text
        Dim k As Integer = Label5.Text
        Dim hadd As Date = DateAdd(DateInterval.Hour, i, TimeOfDay)

        Dim madd As Date = DateAdd(DateInterval.Minute, k, hadd)
        Label1.Text = Format(madd, "HH:mm:ss")

        '#####Variable and path assign 
        Dim currentuser As String = Environment.UserName
        Dim strFolder = "C:\users\" + currentuser + "\documents\kobt\"
        Dim filepath As String = Path.Combine(strFolder, Label2.Text)
        '########Variable and path assign ends

        Using sw As StreamWriter = New StreamWriter(filepath)
            sw.WriteLine(Label1.Text)
            sw.WriteLine(Button2.Text)
            sw.WriteLine(Label6.Text)
            sw.WriteLine(Label4.Text)
            sw.WriteLine(Label5.Text)
            Kobt.ToolStripStatusLabel16.Text = "Saved as " + Label2.Text
            Kobt.Timer2.Start()
        End Using

    End Sub
End Class