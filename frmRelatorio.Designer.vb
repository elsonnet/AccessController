<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelatorio
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ddlEvento = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Acessos = New System.Windows.Forms.GroupBox
        Me.btnAcLote = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Acessos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ddlEvento)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Acessos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(288, 111)
        Me.Panel1.TabIndex = 0
        '
        'ddlEvento
        '
        Me.ddlEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddlEvento.FormattingEnabled = True
        Me.ddlEvento.Location = New System.Drawing.Point(4, 22)
        Me.ddlEvento.Name = "ddlEvento"
        Me.ddlEvento.Size = New System.Drawing.Size(186, 24)
        Me.ddlEvento.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Evento"
        '
        'Acessos
        '
        Me.Acessos.Controls.Add(Me.btnAcLote)
        Me.Acessos.Location = New System.Drawing.Point(4, 52)
        Me.Acessos.Name = "Acessos"
        Me.Acessos.Size = New System.Drawing.Size(275, 50)
        Me.Acessos.TabIndex = 0
        Me.Acessos.TabStop = False
        Me.Acessos.Text = "Acessos"
        '
        'btnAcLote
        '
        Me.btnAcLote.Location = New System.Drawing.Point(7, 19)
        Me.btnAcLote.Name = "btnAcLote"
        Me.btnAcLote.Size = New System.Drawing.Size(76, 23)
        Me.btnAcLote.TabIndex = 5
        Me.btnAcLote.Text = "Por Lote"
        Me.btnAcLote.UseVisualStyleBackColor = True
        '
        'frmRelatorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 116)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "frmRelatorio"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relatório"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Acessos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Acessos As System.Windows.Forms.GroupBox
    Friend WithEvents ddlEvento As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAcLote As System.Windows.Forms.Button
End Class
