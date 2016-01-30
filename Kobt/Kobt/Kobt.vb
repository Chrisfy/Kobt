Public Class Kobt
    Public Function ReadLine(lineNumber As Integer, lines As List(Of String)) As String
        Return lines(lineNumber - 1)
    End Function
    Public OvFlag2 As Boolean

    Private Sub Kobt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitializeOpenFileDialog()
        Timer1.Start()
        OvFlag2 = False
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click
        Dim Window As New Timer
        Window.MdiParent = Me
        OvFlag2 = False
        ToolStripStatusLabel16.Text = "Set up new timer"
        Timer2.Start()
        Window.Show()




    End Sub

    Private Sub LoadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LOad2ToolStripMenuItem.Click, OpenToolStripButton.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim k As Integer = OpenFileDialog1.FileNames.Count - 1
            For i As Integer = 0 To k
                Dim bckgr As Integer
                Dim reader As New System.IO.StreamReader(OpenFileDialog1.FileNames(i))
                Dim allLines As List(Of String) = New List(Of String)
                Dim Window As New Boss
                Window.MdiParent = Me
                Do While Not reader.EndOfStream
                    allLines.Add(reader.ReadLine)
                Loop
                reader.Close()
                Window.Text = OpenFileDialog1.SafeFileNames(i)
                Window.Label2.Text = OpenFileDialog1.SafeFileNames(i)
                Window.Label1.Text = ReadLine(1, allLines)
                Window.Button2.Text = ReadLine(2, allLines)
                bckgr = ReadLine(3, allLines)
                Window.Label4.Text = ReadLine(4, allLines)
                Window.Label5.Text = ReadLine(5, allLines)
                Window.Label6.Text = bckgr
                If bckgr = 0 Then
                    Window.BackColor = Color.Black
                ElseIf bckgr = 1 Then
                    Window.BackColor = Color.DodgerBlue
                ElseIf bckgr = 2 Then
                    Window.BackColor = Color.Firebrick
                ElseIf bckgr = 3 Then
                    Window.BackColor = Color.Green
                ElseIf bckgr = 4 Then
                    Window.BackColor = Color.DarkBlue
                ElseIf bckgr = 5 Then
                    Window.BackColor = Color.Indigo
                ElseIf bckgr = 6 Then
                    Window.BackColor = Color.HotPink
                End If


                Window.Show()
            Next
            HorizontalToolStripMenuItem.PerformClick()
            MessageBox.Show("All files were load succesfully.", "Load Completed", MessageBoxButtons.OK)



        End If
    End Sub

    Public Sub InitializeOpenFileDialog()
        Dim currentuser As String = Environment.UserName
        Dim strFolder = "C:\users\" + currentuser + "\documents\kobt\"
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.InitialDirectory = strFolder
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "Select Files"
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
        End

    End Sub

    Private Sub HorizontalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = Format(TimeOfDay, "HH:mm:ss")
        ToolStripStatusLabel17.Text = MdiChildren.Count

    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
    End Sub

   
    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        ToolStripStatusLabel16.Text = "Status "
        Timer2.Stop()
    End Sub

    Private Sub HelpToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles HelpToolStripButton.Click
        MessageBox.Show("Its simple Biatch why you ask for help? ", "Bitch, please", MessageBoxButtons.OK)
    End Sub
End Class
