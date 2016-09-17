Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim ts3 As System.TimeSpan
        Dim tsRest As System.TimeSpan

        Dim dt1 As System.DateTime
        Dim dt2 As System.DateTime
        Dim dtNext As System.DateTime

        Dim hour1 As Integer
        Dim hour2 As Integer
        Dim mint1 As Integer
        Dim mint2 As Integer

        txt1.Text = CorrectTimeFormat(txt1.Text)
        txt2.Text = CorrectTimeFormat(txt2.Text)
        txt3.Text = CorrectTimeFormat(txt3.Text)

        hour1 = Integer.Parse(Mid(txt1.Text, 1, 2))
        mint1 = Integer.Parse(Mid(txt1.Text, 3, 2))
        hour2 = Integer.Parse(Mid(txt2.Text, 1, 2))
        mint2 = Integer.Parse(Mid(txt2.Text, 3, 2))
        tsRest = New System.TimeSpan(Mid(txt3.Text, 1, 2), Mid(txt3.Text, 3, 2), 0)

        dt1 = New DateTime(Now.Year, Now.Month, Now.Day, hour1, mint1, 0)
        If hour1.CompareTo(hour2) = 1 Then
            dtNext = Now.AddDays(1)
        Else
            dtNext = Now
        End If
        dt2 = New DateTime(dtNext.Year, dtNext.Month, dtNext.Day, hour2, mint2, 0)

        ts3 = dt2 - dt1 - tsRest
        If ts3.CompareTo(New System.TimeSpan(0, 0, 0)) = -1 Then
            ts3 = New System.TimeSpan(0, 0, 0)
        End If
        MessageBox.Show(ts3.ToString("hh'時間'mm'分'"))

    End Sub

    Private Function CorrectTimeFormat(ByVal strBef As String) As String
        Const TIME_EXP As String = "^([01]?[0-9]|2[0-3])([0-5][0-9])$"
        Dim strRet As String

        Select Case strBef.Length
            Case 0
                strRet = "0000"
            Case 1
                strRet = "0" & strBef & "00"
            Case 2
                strRet = strBef & "00"
            Case 3
                strRet = "0" & strBef
            Case 4
                strRet = strBef
            Case Else
                strRet = "0000"
        End Select

        If System.Text.RegularExpressions.Regex.IsMatch(strRet, TIME_EXP) Then
            Return strRet
        Else
            Return String.Empty
        End If

    End Function

    Private Sub txt_Leave(sender As Object, e As EventArgs) Handles txt1.Leave, txt2.Leave, txt3.Leave
        Dim txt As TextBox = DirectCast(sender, TextBox)
        txt.Text = CorrectTimeFormat(txt.Text)
    End Sub

End Class
