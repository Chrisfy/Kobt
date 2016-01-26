Public Class Kobt

    Private Sub Kobt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitializeOpenFileDialog()
        Timer1.Start()


    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim Window As New Timer
        Window.MdiParent = Me
        Window.Show()

    End Sub

    Private Sub LoadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LoadToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim Window As New Timer
            Window.MdiParent = Me
            Window.TextBox1.Text = OpenFileDialog1.SafeFileName
            Window.Label2.Text = IO.File.ReadAllText(OpenFileDialog1.FileName)

            Window.Show()

        End If
    End Sub

    Private Sub LoadMultipleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LoadMultipleToolStripMenuItem.Click
        ' OpenFileDialog1.Multiselect = True
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            'Dim file As String
            'For Each File In OpenFileDialog1.FileNames
            'Dim Window As New Timer
            'Dim loadedTime As String = IO.File.ReadAllText(OpenFileDialog1.FileName)
            ' Window.MdiParent = Me
            'Window.TextBox1.Text = OpenFileDialog1.SafeFileName
            'Window.Label2.Text = loadedTime
            Dim k As Integer = OpenFileDialog1.FileNames.Count - 1
            'Dim ar() As String = OpenFileDialog1.FileNames
            For i As Integer = 0 To k
                Dim Window As New Timer
                Window.MdiParent = Me
                Window.TextBox1.Text = OpenFileDialog1.SafeFileNames(i)
                Window.Label2.Text = IO.File.ReadAllText(OpenFileDialog1.FileNames(i))
                Dim dt As Date = Window.Label2.Text
                Dim dt2 As Date = TimeOfDay
                Dim diff As Integer = DateDiff(DateInterval.Hour, dt, dt2)
                If diff < 6 Then
                    Window.Label2.ForeColor = Color.Red
                End If
                Window.Show()

            Next
            MessageBox.Show("Succes")

            'Next

            'Window.Show()
            ' Next File
        End If
    End Sub

    Public Sub InitializeOpenFileDialog()
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 2


        ' Allow the user to select multiple images.
        Me.OpenFileDialog1.Multiselect = True
        Me.OpenFileDialog1.Title = "Select Files"
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
        End

    End Sub

    Private Sub HorizontalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = Format(TimeOfDay, "HH:mm:ss")
    End Sub
End Class
