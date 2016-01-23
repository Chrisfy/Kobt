Public Class Kobt

    Private Sub NewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim Window As New Timer
        Window.MdiParent = Me
        Window.Show()

    End Sub
End Class
