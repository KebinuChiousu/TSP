Module RandomColors
    Private m_Rnd As New Random

    ' Return a random QB color.
    Public Function RandomQBColor() As Color
        Dim color_num As Integer = m_Rnd.Next(0, 15)
        Return Color.FromArgb(QBColor(color_num) + _
            &HFF000000)
    End Function

    ' Return a random RGB color.
    Public Function RandomRGBColor() As Color
        Return Color.FromArgb(255, _
            m_Rnd.Next(0, 255), _
            m_Rnd.Next(0, 255), _
            m_Rnd.Next(0, 255))
    End Function
End Module

