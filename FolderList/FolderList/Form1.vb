Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvSolFolder.Rows.Clear()
        dgvProgram.Rows.Clear()

        For Each stDirPath As String In System.IO.Directory.GetDirectories("C:\Users\User\NET")
            Dim rowIndex As Integer = dgvSolFolder.Rows.Add()
            dgvSolFolder.Rows(rowIndex).Cells(colFolder.Name).Value = stDirPath
            dgvSolFolder.Rows(rowIndex).Cells(colSolution.Name).Value = System.IO.Directory.GetFiles(stDirPath, "*.sln")(0)
        Next stDirPath

        For Each stBatPath As String In System.IO.Directory.GetFiles("C:\Users\User\NET", "*.bat")
            Dim rowIndex As Integer = dgvProgram.Rows.Add()
            dgvProgram.Rows(rowIndex).Cells(colBat.Name).Value = stBatPath
        Next stBatPath

    End Sub

    Private Sub dgvProgram_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProgram.CellClick
        If e.RowIndex >= 0 Then
            Dim content As String = dgvProgram.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim col As DataGridViewColumn = dgvProgram.Columns(e.ColumnIndex)
            System.Diagnostics.Process.Start(content)
        End If
    End Sub

    Private Sub dgvSolFolder_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSolFolder.CellClick

        If e.RowIndex >= 0 Then
            Dim content As String = dgvSolFolder.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            Dim col As DataGridViewColumn = dgvSolFolder.Columns(e.ColumnIndex)
            System.Diagnostics.Process.Start(content)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bat As String = "C:\Users\User\NET\test.bat"
        'System.Diagnostics.Process.Start(bat)

        'Processオブジェクトを作成
        Dim p As New System.Diagnostics.Process()

        'ComSpec(cmd.exe)のパスを取得して、FileNameプロパティに指定
        p.StartInfo.FileName = bat
        '出力を読み取れるようにする
        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardInput = False
        'ウィンドウを表示しないようにする
        p.StartInfo.CreateNoWindow = False
        'コマンドラインを指定（"/c"は実行後閉じるために必要）
        p.StartInfo.Arguments = "/c "

        '起動
        p.Start()

        '出力を読み取る
        Dim results As String = p.StandardOutput.ReadToEnd()

        'プロセス終了まで待機する
        'WaitForExitはReadToEndの後である必要がある
        '(親プロセス、子プロセスでブロック防止のため)
        p.WaitForExit()
        p.Close()

        'Shift JISで書き込む
        '書き込むファイルが既に存在している場合は、上書きする
        Dim logName As String = "log.log"
        Dim sw As New System.IO.StreamWriter(logName, _
            False, _
            System.Text.Encoding.GetEncoding("shift_jis"))
        sw.Write(results)
        '閉じる
        sw.Close()

        System.Diagnostics.Process.Start(logName)

    End Sub
End Class
