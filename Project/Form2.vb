Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If OpenFileDialog1.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Dim FileUpload = My.Computer.FileSystem.GetFileInfo(OpenFileDialog1.FileName)
            Dim FileSize As Integer = FileUpload.Length
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
        PictureBox1.Refresh()
    End Sub
    '----------------------------
    Public Sub SaveFunction()
        If PictureBox1.Image IsNot Nothing Then
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files|*.*"
            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image.Save(saveFileDialog.FileName)
            End If
        Else
            MessageBox.Show("No image to save.")
        End If
    End Sub

    '----------------------------
    Public Sub ApplyGrayscaleFilterToPictureBox1()
        Dim img As New Bitmap(PictureBox1.Image)
        Dim temp As Integer
        Dim merah, hijau, biru As Integer
        Dim baris, kolom As Integer
        For baris = 0 To img.Height - 1
            For kolom = 0 To img.Width - 1
                merah = img.GetPixel(kolom, baris).R
                hijau = img.GetPixel(kolom, baris).G
                biru = img.GetPixel(kolom, baris).B
                temp = CInt((merah + hijau + biru) / 3)
                img.SetPixel(kolom, baris, Color.FromArgb(temp, temp, temp))
            Next
        Next
        PictureBox1.Image = img
        PictureBox1.Refresh()
    End Sub

    '----------------------------
    Public Sub ApplyBatasFilterToPictureBox1()
        Dim img As New Bitmap(PictureBox1.Image)
        Dim temp As Integer
        Dim merah, hijau, biru As Integer
        Dim baris, kolom As Integer

        For baris = 0 To img.Height - 1
            For kolom = 0 To img.Width - 1
                merah = img.GetPixel(kolom, baris).R
                hijau = img.GetPixel(kolom, baris).G
                biru = img.GetPixel(kolom, baris).B

                merah = 255 - merah
                hijau = 255 - hijau
                biru = 255 - biru

                img.SetPixel(kolom, baris, Color.FromArgb(merah, hijau, biru))
            Next
        Next

        PictureBox1.Image = img
        PictureBox1.Refresh()
    End Sub

    '----------------------------
    Public Sub ApplyRatarataFilterToPictureBox1()
        Dim img As New Bitmap(PictureBox1.Image)
        Dim tempR, tempG, tempB As Integer
        Dim sumR, sumG, sumB As Integer
        Dim avgR, avgG, avgB As Integer
        Dim baris, kolom, i, j As Integer
        Dim kernelSize As Integer = 3

        For baris = 0 To img.Height - 1
            For kolom = 0 To img.Width - 1
                sumR = 0
                sumG = 0
                sumB = 0

                For i = -kernelSize \ 2 To kernelSize \ 2
                    For j = -kernelSize \ 2 To kernelSize \ 2
                        If baris + i >= 0 AndAlso baris + i < img.Height AndAlso kolom + j >= 0 AndAlso kolom + j < img.Width Then
                            tempR = img.GetPixel(kolom + j, baris + i).R
                            tempG = img.GetPixel(kolom + j, baris + i).G
                            tempB = img.GetPixel(kolom + j, baris + i).B

                            sumR += tempR
                            sumG += tempG
                            sumB += tempB
                        End If
                    Next
                Next

                avgR = sumR \ (kernelSize * kernelSize)
                avgG = sumG \ (kernelSize * kernelSize)
                avgB = sumB \ (kernelSize * kernelSize)

                img.SetPixel(kolom, baris, Color.FromArgb(avgR, avgG, avgB))
            Next
        Next

        PictureBox1.Image = img
        PictureBox1.Refresh()
    End Sub

    '----------------------------
    Public Sub ApplyMedianFilterToPictureBox1()
        Dim img As New Bitmap(PictureBox1.Image)
        Dim neighborhoodSize As Integer = 3

        Dim tempRed, tempGreen, tempBlue As Integer
        Dim redValues(neighborhoodSize * neighborhoodSize - 1) As Integer
        Dim greenValues(neighborhoodSize * neighborhoodSize - 1) As Integer
        Dim blueValues(neighborhoodSize * neighborhoodSize - 1) As Integer

        Dim halfNeighborhood As Integer = neighborhoodSize \ 2

        For y As Integer = halfNeighborhood To img.Height - 1 - halfNeighborhood
            For x As Integer = halfNeighborhood To img.Width - 1 - halfNeighborhood
                Dim index As Integer = 0

                For j As Integer = -halfNeighborhood To halfNeighborhood
                    For i As Integer = -halfNeighborhood To halfNeighborhood
                        redValues(index) = img.GetPixel(x + i, y + j).R
                        greenValues(index) = img.GetPixel(x + i, y + j).G
                        blueValues(index) = img.GetPixel(x + i, y + j).B
                        index += 1
                    Next
                Next

                Array.Sort(redValues)
                Array.Sort(greenValues)
                Array.Sort(blueValues)

                tempRed = redValues(redValues.Length \ 2)
                tempGreen = greenValues(greenValues.Length \ 2)
                tempBlue = blueValues(blueValues.Length \ 2)

                img.SetPixel(x, y, Color.FromArgb(tempRed, tempGreen, tempBlue))
            Next
        Next

        PictureBox1.Image = img
        PictureBox1.Refresh()
    End Sub

End Class