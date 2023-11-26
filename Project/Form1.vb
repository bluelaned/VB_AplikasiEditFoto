Public Class Form1

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Dim form2Instance As New Form2()
        form2Instance.MdiParent = Me
        form2Instance.Show()
    End Sub
    '----------------------------
    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        If ActiveMdiChild IsNot Nothing Then
            Dim activeChildForm As Form = ActiveMdiChild
            SaveForm(activeChildForm)
        End If
    End Sub
    Private Sub SaveForm(ByVal formToSave As Form)

        If TypeOf formToSave Is Form2 Then
            Dim form2Instance As Form2 = DirectCast(formToSave, Form2)
            form2Instance.SaveFunction()
        End If
    End Sub
    '----------------------------
    Private Sub RatarataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RatarataToolStripMenuItem.Click
        ApplyRatarataFilter()
    End Sub
    Private Sub ApplyRatarataFilter()
        If ActiveMdiChild IsNot Nothing Then
            Dim activeChildForm As Form = ActiveMdiChild
            If TypeOf activeChildForm Is Form2 Then
                Dim form2Instance As Form2 = DirectCast(activeChildForm, Form2)
                form2Instance.ApplyRatarataFilterToPictureBox1()
            End If
        End If
    End Sub
    '----------------------------
    Private Sub BatasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatasToolStripMenuItem.Click
        ApplyBatasFilter()
    End Sub
    Private Sub ApplyBatasFilter()
        If ActiveMdiChild IsNot Nothing Then
            Dim activeChildForm As Form = ActiveMdiChild
            If TypeOf activeChildForm Is Form2 Then
                Dim form2Instance As Form2 = DirectCast(activeChildForm, Form2)
                form2Instance.ApplyBatasFilterToPictureBox1()
            End If
        End If
    End Sub
    '----------------------------
    Private Sub MedianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MedianToolStripMenuItem.Click
        ApplyMedianFilter()
    End Sub

    Private Sub ApplyMedianFilter()
        If ActiveMdiChild IsNot Nothing Then
            Dim activeChildForm As Form = ActiveMdiChild
            If TypeOf activeChildForm Is Form2 Then
                Dim form2Instance As Form2 = DirectCast(activeChildForm, Form2)
                form2Instance.ApplyMedianFilterToPictureBox1()
            End If
        End If
    End Sub
    '----------------------------
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Form2.MdiParent = Me
        Form2.Show()
    End Sub
    '----------------------------
    Private Sub GrayscaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrayscaleToolStripMenuItem.Click
        ApplyGrayscaleFilter()
    End Sub
    Private Sub ApplyGrayscaleFilter()
        If ActiveMdiChild IsNot Nothing Then
            Dim activeChildForm As Form = ActiveMdiChild
            If TypeOf activeChildForm Is Form2 Then
                Dim form2Instance As Form2 = DirectCast(activeChildForm, Form2)
                form2Instance.ApplyGrayscaleFilterToPictureBox1()
            End If

        End If
    End Sub

    Private Sub AboutMeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutMeToolStripMenuItem.Click
        Dim url As String = "https://github.com/bluelaned"
        System.Diagnostics.Process.Start(url)
    End Sub
    '----------------------------
End Class
