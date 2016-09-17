Imports System.Data
Public Class Form1

    ''' <summary>
    ''' Form_ロード
    ''' </summary>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim dtTbl As New Data.DataTable
        Dim dr As DataRow
        Dim column1 As DataColumn
        Dim column2 As DataColumn
        Dim keys(1) As DataColumn

        column1 = New DataColumn("日付", GetType(String))
        column2 = New DataColumn("やること", GetType(String))

        dtTbl.Columns.Add(column1)
        dtTbl.Columns.Add(column2)

        dr = dtTbl.NewRow
        dr("日付") = "2016/06/01"
        dr("やること") = "ランニング"
        dtTbl.Rows.Add(dr)

        dr = dtTbl.NewRow
        dr("日付") = "2016/06/03"
        dr("やること") = "読書"
        dtTbl.Rows.Add(dr)

        dr = dtTbl.NewRow
        dr("日付") = "2016/06/05"
        dr("やること") = "買い物"
        dtTbl.Rows.Add(dr)


        '日付をキーにする
        keys(0) = column1
        'DataTableにキーをセット
        dtTbl.PrimaryKey = keys
        'DataTableの内容をCommitする。(これ以降に変更した履歴を取得できる。)
        dtTbl.AcceptChanges()
        'DataGridViewに割り当て
        DataGridView1.AutoGenerateColumns = False 'DataSourceから列名を反映しない
        DataGridView1.Columns(colTodoDate.Name).DataPropertyName = "日付"
        DataGridView1.Columns(colTodoItem.Name).DataPropertyName = "やること"
        DataGridView1.DataSource = dtTbl
    End Sub
#Region "行イベント"
    ''' <summary>
    ''' 行追加イベント
    ''' </summary>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim dtTbl As Data.DataTable
        Dim dr As DataRow
        Try

            dtTbl = DirectCast(DataGridView1.DataSource, Data.DataTable)
            'TextBoxの内容をdatatblに反映させる
            dr = dtTbl.NewRow
            dr("日付") = TextBox1.Text
            dr("やること") = TextBox2.Text
            dtTbl.Rows.InsertAt(dr, 0)

        Catch ex As ConstraintException
            '一意制約エラーの場合、メッセージで通知
            MessageBox.Show("key has already.")
        End Try

    End Sub

    ''' <summary>
    ''' 更新イベント
    ''' </summary>
    Private Sub btnUpd_Click(sender As Object, e As EventArgs) Handles btnUpd.Click
        Dim dtTbl As Data.DataTable
        Dim dr As DataRow

        dtTbl = DirectCast(DataGridView1.DataSource, Data.DataTable)
        'DataGridViewの選択した行からキーである日付の値を取得する。
        dr = dtTbl.Rows.Find(DataGridView1.SelectedRows(0).Cells("日付").Value)
        '取得した行を変更
        dr("やること") = TextBox2.Text

    End Sub

    ''' <summary>
    ''' 削除イベント
    ''' </summary>
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim dtTbl As Data.DataTable
        Dim dr As DataRow

        dtTbl = DirectCast(DataGridView1.DataSource, Data.DataTable)
        'DataGridViewの選択した行からキーである日付の値を取得する。
        dr = dtTbl.Rows.Find(DataGridView1.SelectedRows(0).Cells(colTodoDate.Name).Value)
        '取得した行を削除
        dr.Delete()
        dtTbl.Rows.Remove(dr)
    End Sub
#End Region
    ''' <summary>
    ''' DataTableの履歴表示
    ''' </summary>
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Dim dtTbl As Data.DataTable
        Dim strHistory As String = String.Empty
        Dim strState As String = String.Empty

        dtTbl = DirectCast(DataGridView1.DataSource, Data.DataTable)
        '変更履歴を表示
        For Each row As DataRow In dtTbl.Rows
            Select Case row.RowState
                Case DataRowState.Added
                    strState = "追加"
                Case DataRowState.Modified
                    strState = "修正"
                Case DataRowState.Deleted
                    strState = "削除"
                Case DataRowState.Unchanged
                    strState = "不変"
            End Select
            If row.RowState = DataRowState.Deleted Then
                'Deletedの場合、現在のデータにアクセスするとDeletedRowInaccessibleExceptionが発生するのでOriginalにアクセスする
                strHistory += row("日付", DataRowVersion.Original) + " " + row.RowState.ToString + " " + strState + vbCrLf
            Else
                strHistory += row("日付") + " " + row.RowState.ToString + " " + strState + vbCrLf
            End If
        Next

        MessageBox.Show(strHistory)

    End Sub

    ''' <summary>
    ''' DGV選択時、上部に反映
    ''' </summary>
    Private Sub DataGridView1_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowEnter

        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(colTodoDate.Name).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(colTodoItem.Name).Value

    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim strCheck As String = String.Empty

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(colCheck.Name).Value IsNot Nothing Then
                strCheck += row.Cells(colCheck.Name).Value.ToString + vbCrLf
            Else
                strCheck += "Nothing" + vbCrLf
            End If
        Next

        MessageBox.Show(strCheck)

    End Sub
End Class
