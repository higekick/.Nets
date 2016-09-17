<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvSolFolder = New System.Windows.Forms.DataGridView()
        Me.colFolder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSolution = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvProgram = New System.Windows.Forms.DataGridView()
        Me.colBat = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dgvSolFolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProgram, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSolFolder
        '
        Me.dgvSolFolder.AllowUserToAddRows = False
        Me.dgvSolFolder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSolFolder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFolder, Me.colSolution})
        Me.dgvSolFolder.Location = New System.Drawing.Point(12, 47)
        Me.dgvSolFolder.Name = "dgvSolFolder"
        Me.dgvSolFolder.RowHeadersVisible = False
        Me.dgvSolFolder.Size = New System.Drawing.Size(420, 231)
        Me.dgvSolFolder.TabIndex = 0
        '
        'colFolder
        '
        Me.colFolder.HeaderText = "Folder"
        Me.colFolder.Name = "colFolder"
        Me.colFolder.Width = 200
        '
        'colSolution
        '
        Me.colSolution.HeaderText = "Solution"
        Me.colSolution.Name = "colSolution"
        Me.colSolution.Width = 200
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvProgram
        '
        Me.dgvProgram.AllowUserToAddRows = False
        Me.dgvProgram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProgram.ColumnHeadersVisible = False
        Me.dgvProgram.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBat})
        Me.dgvProgram.Location = New System.Drawing.Point(460, 47)
        Me.dgvProgram.Name = "dgvProgram"
        Me.dgvProgram.RowHeadersVisible = False
        Me.dgvProgram.Size = New System.Drawing.Size(123, 231)
        Me.dgvProgram.TabIndex = 2
        '
        'colBat
        '
        Me.colBat.HeaderText = "Bat"
        Me.colBat.Name = "colBat"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 301)
        Me.Controls.Add(Me.dgvProgram)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvSolFolder)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgvSolFolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProgram, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvSolFolder As System.Windows.Forms.DataGridView
    Friend WithEvents colFolder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSolution As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvProgram As System.Windows.Forms.DataGridView
    Friend WithEvents colBat As System.Windows.Forms.DataGridViewButtonColumn

End Class
