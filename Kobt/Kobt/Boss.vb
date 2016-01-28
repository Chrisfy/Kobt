Public Class Boss

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim backtimer As New Timer
        backtimer.MdiParent = Kobt
        backtimer.TextBox1.Text = Me.Label2.Text
        backtimer.Label2.Text = Me.Label1.Text
        backtimer.Text = Label2.Text
        Me.Close()
        backtimer.Show()

    End Sub

    Private Sub Boss_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        MdiParent = Kobt
        Timer1.Start()
    End Sub
    Public flag As Boolean = False
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        Dim d As Date = Label1.Text
        Dim tn As Date = TimeOfDay
        Dim left As TimeSpan = tn - d
        Dim minDiff As Integer = Math.Abs(left.Minutes)
        Dim secDiff As Integer = Math.Abs(left.Seconds)

        If flag = False Then
            If minDiff = 5 And secDiff = 0 Then
                For i As Integer = 0 To 5
                    Console.Beep()
                Next
                Dim a As String = " Is respawning in 5 minutes..."
                Label1.ForeColor = Color.Orange
                Button1.BackColor = Color.Orange
                Button1.ForeColor = Color.White
                MessageBox.Show(Label2.Text + a, "Attention Bitch")
                flag = True
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
            flag = True

        End If

        Dim datecheck As String = Button2.Text
        Dim dDiff As Date = Date.ParseExact(datecheck, "dd/MM/yyyy",
            System.Globalization.DateTimeFormatInfo.InvariantInfo)
        If DateDiff(DateInterval.Day, Date.Now, dDiff) <= -1 Then
            Button2.BackColor = Color.Red

        End If

    End Sub
End Class