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
        Me.txtUnidad = New System.Windows.Forms.TextBox
        Me.btnObtenerUnidadDisco = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtUnidad
        '
        Me.txtUnidad.Location = New System.Drawing.Point(156, 124)
        Me.txtUnidad.Name = "txtUnidad"
        Me.txtUnidad.ReadOnly = True
        Me.txtUnidad.Size = New System.Drawing.Size(100, 20)
        Me.txtUnidad.TabIndex = 3
        '
        'btnObtenerUnidadDisco
        '
        Me.btnObtenerUnidadDisco.Location = New System.Drawing.Point(36, 122)
        Me.btnObtenerUnidadDisco.Name = "btnObtenerUnidadDisco"
        Me.btnObtenerUnidadDisco.Size = New System.Drawing.Size(96, 23)
        Me.btnObtenerUnidadDisco.TabIndex = 2
        Me.btnObtenerUnidadDisco.Text = "ObtenerUnidad"
        Me.btnObtenerUnidadDisco.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.txtUnidad)
        Me.Controls.Add(Me.btnObtenerUnidadDisco)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtUnidad As System.Windows.Forms.TextBox
    Private WithEvents btnObtenerUnidadDisco As System.Windows.Forms.Button

End Class
