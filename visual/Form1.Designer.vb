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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBrowseEncrypt = New System.Windows.Forms.Button()
        Me.btnBrowseDecrypt = New System.Windows.Forms.Button()
        Me.txtEncryptFile = New System.Windows.Forms.TextBox()
        Me.txtDecryptFile = New System.Windows.Forms.TextBox()
        Me.btnEncrypt = New System.Windows.Forms.Button()
        Me.btnDecrypt = New System.Windows.Forms.Button()
        Me.txtEncryptPassword = New System.Windows.Forms.TextBox()
        Me.txtDecryptPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(196, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(484, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "File Encryption and Decryption"
        '
        'btnBrowseEncrypt
        '
        Me.btnBrowseEncrypt.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnBrowseEncrypt.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnBrowseEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseEncrypt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseEncrypt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnBrowseEncrypt.Location = New System.Drawing.Point(13, 196)
        Me.btnBrowseEncrypt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowseEncrypt.Name = "btnBrowseEncrypt"
        Me.btnBrowseEncrypt.Size = New System.Drawing.Size(393, 38)
        Me.btnBrowseEncrypt.TabIndex = 2
        Me.btnBrowseEncrypt.Text = "Click to Browse"
        Me.btnBrowseEncrypt.UseVisualStyleBackColor = False
        '
        'btnBrowseDecrypt
        '
        Me.btnBrowseDecrypt.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.btnBrowseDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseDecrypt.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseDecrypt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnBrowseDecrypt.Location = New System.Drawing.Point(463, 196)
        Me.btnBrowseDecrypt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowseDecrypt.Name = "btnBrowseDecrypt"
        Me.btnBrowseDecrypt.Size = New System.Drawing.Size(393, 38)
        Me.btnBrowseDecrypt.TabIndex = 7
        Me.btnBrowseDecrypt.Text = "Click to Browse"
        Me.btnBrowseDecrypt.UseVisualStyleBackColor = False
        '
        'txtEncryptFile
        '
        Me.txtEncryptFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtEncryptFile.Location = New System.Drawing.Point(31, 270)
        Me.txtEncryptFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEncryptFile.Name = "txtEncryptFile"
        Me.txtEncryptFile.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEncryptFile.Size = New System.Drawing.Size(354, 31)
        Me.txtEncryptFile.TabIndex = 8
        '
        'txtDecryptFile
        '
        Me.txtDecryptFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtDecryptFile.Location = New System.Drawing.Point(504, 270)
        Me.txtDecryptFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDecryptFile.Name = "txtDecryptFile"
        Me.txtDecryptFile.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtDecryptFile.Size = New System.Drawing.Size(281, 31)
        Me.txtDecryptFile.TabIndex = 9
        '
        'btnEncrypt
        '
        Me.btnEncrypt.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEncrypt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEncrypt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(18, Byte), Integer))
        Me.btnEncrypt.Location = New System.Drawing.Point(106, 392)
        Me.btnEncrypt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnEncrypt.Name = "btnEncrypt"
        Me.btnEncrypt.Size = New System.Drawing.Size(170, 91)
        Me.btnEncrypt.TabIndex = 10
        Me.btnEncrypt.Text = "Encrypt File 🔐"
        Me.btnEncrypt.UseVisualStyleBackColor = False
        '
        'btnDecrypt
        '
        Me.btnDecrypt.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDecrypt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDecrypt.ForeColor = System.Drawing.Color.White
        Me.btnDecrypt.Location = New System.Drawing.Point(562, 392)
        Me.btnDecrypt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDecrypt.Name = "btnDecrypt"
        Me.btnDecrypt.Size = New System.Drawing.Size(163, 91)
        Me.btnDecrypt.TabIndex = 10
        Me.btnDecrypt.Text = "Decrypt File🔓"
        Me.btnDecrypt.UseVisualStyleBackColor = False
        '
        'txtEncryptPassword
        '
        Me.txtEncryptPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtEncryptPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtEncryptPassword.Location = New System.Drawing.Point(51, 330)
        Me.txtEncryptPassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEncryptPassword.Name = "txtEncryptPassword"
        Me.txtEncryptPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEncryptPassword.Size = New System.Drawing.Size(281, 31)
        Me.txtEncryptPassword.TabIndex = 8
        '
        'txtDecryptPassword
        '
        Me.txtDecryptPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtDecryptPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtDecryptPassword.Location = New System.Drawing.Point(504, 330)
        Me.txtDecryptPassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDecryptPassword.Name = "txtDecryptPassword"
        Me.txtDecryptPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtDecryptPassword.Size = New System.Drawing.Size(281, 31)
        Me.txtDecryptPassword.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Gray
        Me.Label1.Font = New System.Drawing.Font("Snap ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(118, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 36)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Encrypt"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Gray
        Me.Label3.Font = New System.Drawing.Font("Snap ITC", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(614, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 36)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = " "
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(24, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(889, 562)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDecrypt)
        Me.Controls.Add(Me.btnEncrypt)
        Me.Controls.Add(Me.txtDecryptPassword)
        Me.Controls.Add(Me.txtDecryptFile)
        Me.Controls.Add(Me.txtEncryptPassword)
        Me.Controls.Add(Me.txtEncryptFile)
        Me.Controls.Add(Me.btnBrowseDecrypt)
        Me.Controls.Add(Me.btnBrowseEncrypt)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents btnBrowseEncrypt As Button
    Friend WithEvents btnBrowseDecrypt As Button
    Friend WithEvents txtEncryptFile As TextBox
    Friend WithEvents txtDecryptFile As TextBox
    Friend WithEvents btnEncrypt As Button
    Friend WithEvents btnDecrypt As Button
    Friend WithEvents txtEncryptPassword As TextBox
    Friend WithEvents txtDecryptPassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
