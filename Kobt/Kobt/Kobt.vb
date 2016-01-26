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

    Private Sub LoadToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim Window As New Timer
            Window.MdiParent = Me
            Window.TextBox1.Text = OpenFileDialog1.SafeFileName
            Window.Label2.Text = IO.File.ReadAllText(OpenFileDialog1.FileName)

            Window.Show()

        End If
    End Sub

    Private Sub LoadMultipleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LoadMultipleToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim k As Integer = OpenFileDialog1.FileNames.Count - 1
            For i As Integer = 0 To k
                Dim Window As New Boss
                Window.MdiParent = Me
                Window.Label2.Text = OpenFileDialog1.SafeFileNames(i)
                Window.Label1.Text = IO.File.ReadAllText(OpenFileDialog1.FileNames(i))
                Window.Text = OpenFileDialog1.SafeFileNames(i)
                Dim dt As Date = Window.Label1.Text
                Dim dt2 As Date = TimeOfDay
                Window.Show()

            Next
            MessageBox.Show("Files Load Succesful", "Succes")

        End If
    End Sub

    Public Sub InitializeOpenFileDialog()
        OpenFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 2

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
    End Sub
End Class
