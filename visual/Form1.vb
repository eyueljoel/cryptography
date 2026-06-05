Imports System.IO
Imports System.Diagnostics

Public Class Form1

    ' ========== PLACEHOLDER API ==========
    Private Declare Auto Function SendMessage Lib "user32.dll" (
        ByVal hWnd As IntPtr,
        ByVal msg As Integer,
        ByVal wParam As IntPtr,
        ByVal lParam As String) As IntPtr

    Private Const EM_SETCUEBANNER As Integer = &H1501

    Private Sub SetPlaceholder(txt As TextBox, hint As String)
        SendMessage(txt.Handle, EM_SETCUEBANNER, IntPtr.Zero, hint)
    End Sub

    ' ========== FIND PYTHON ==========
    Private Function FindPython() As String
        Dim locations As String() = {
        "C:\Users\HP\AppData\Local\Programs\Python\Python314\python.exe",
        "C:\Users\HP\AppData\Local\Programs\Python\Python313\python.exe",
        "C:\Users\HP\AppData\Local\Programs\Python\Python312\python.exe",
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Programs\Python\Python314\python.exe"),
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Programs\Python\Python312\python.exe"),
        "python",
        "py"
    }

        For Each loc As String In locations
            Try
                Dim psi As New ProcessStartInfo()
                psi.FileName = loc
                psi.Arguments = "--version"
                psi.RedirectStandardOutput = True
                psi.RedirectStandardError = True
                psi.UseShellExecute = False
                psi.CreateNoWindow = True

                Using proc As Process = Process.Start(psi)
                    proc.WaitForExit()
                    If proc.ExitCode = 0 Then
                        Return loc
                    End If
                End Using
            Catch
            End Try
        Next

        Return Nothing
    End Function

    ' ========== FIND SCRIPT ==========
    Private Function FindScript() As String
        ' Go up from visual/ folder to Cryptography/ then into backend/
        Try
            Dim visualFolder As String = Application.StartupPath

            ' During development: bin/Debug is startuppath, go up to visual/
            Dim current As String = visualFolder
            Dim scriptPath As String = ""

            ' Try going up directory levels to find backend/crypto_backend.py
            For i As Integer = 0 To 5
                scriptPath = Path.Combine(current, "backend", "crypto_backend.py")
                If File.Exists(scriptPath) Then
                    Return scriptPath
                End If
                Dim parent As DirectoryInfo = Directory.GetParent(current)
                If parent Is Nothing Then Exit For
                current = parent.FullName
            Next

            ' Fallback: hardcoded Desktop path
            Dim desktopPath As String = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "Cryptography", "backend", "crypto_backend.py")

            If File.Exists(desktopPath) Then
                Return desktopPath
            End If

        Catch ex As Exception
            ' ignore
        End Try

        Return Nothing
    End Function

    ' ========== FORM LOAD ==========
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Placeholders
        SetPlaceholder(txtEncryptPassword, "Enter encryption password...")
        SetPlaceholder(txtDecryptPassword, "Enter decryption password...")
        SetPlaceholder(txtEncryptFile, "No file selected...")
        SetPlaceholder(txtDecryptFile, "No file selected...")

        ' Password masking
        txtEncryptPassword.PasswordChar = "*"c
        txtDecryptPassword.PasswordChar = "*"c

        ' Make file path boxes read-only (filled by browse button)
        txtEncryptFile.ReadOnly = True
        txtDecryptFile.ReadOnly = True

        ' Check Python on startup
        Dim python As String = FindPython()
        If python Is Nothing Then
            MessageBox.Show(
                "Python was not found on this computer." & vbNewLine & vbNewLine &
                "Please install Python from https://www.python.org/downloads/" & vbNewLine &
                "Make sure to check 'Add Python to PATH' during install.",
                "Python Not Found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
        End If

        ' Check script on startup
        Dim script As String = FindScript()
        If script Is Nothing Then
            MessageBox.Show(
                "crypto_backend.py was not found." & vbNewLine & vbNewLine &
                "Make sure the file exists at:" & vbNewLine &
                "Cryptography\backend\crypto_backend.py",
                "Script Not Found",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
        End If
    End Sub

    ' ========== BROWSE ENCRYPT ==========
    Private Sub btnBrowseEncrypt_Click(sender As Object, e As EventArgs) Handles btnBrowseEncrypt.Click
        Using dlg As New OpenFileDialog()
            dlg.Title = "Select file to encrypt"
            dlg.Filter = "All files (*.*)|*.*"
            If dlg.ShowDialog() = DialogResult.OK Then
                txtEncryptFile.Text = dlg.FileName
            End If
        End Using
    End Sub

    ' ========== BROWSE DECRYPT ==========
    Private Sub btnBrowseDecrypt_Click(sender As Object, e As EventArgs) Handles btnBrowseDecrypt.Click
        Using dlg As New OpenFileDialog()
            dlg.Title = "Select file to decrypt"
            dlg.Filter = "Encrypted files (*.enc)|*.enc|All files (*.*)|*.*"
            If dlg.ShowDialog() = DialogResult.OK Then
                txtDecryptFile.Text = dlg.FileName
            End If
        End Using
    End Sub

    ' ========== ENCRYPT BUTTON ==========
    Private Sub btnEncrypt_Click(sender As Object, e As EventArgs) Handles btnEncrypt.Click
        If txtEncryptFile.Text = "" OrElse txtEncryptFile.Text = "No file selected..." Then
            MessageBox.Show("Please select a file to encrypt.", "Missing File",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtEncryptPassword.Text = "" Then
            MessageBox.Show("Please enter a password.", "Missing Password",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not File.Exists(txtEncryptFile.Text) Then
            MessageBox.Show("Selected file does not exist.", "File Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        btnEncrypt.Enabled = False
        btnEncrypt.Text = "Encrypting..."

        Dim result As String = RunPython("encrypt", txtEncryptFile.Text, txtEncryptPassword.Text)

        btnEncrypt.Enabled = True
        btnEncrypt.Text = "Encrypt File"

        If result.StartsWith("SUCCESS:") Then
            Dim outputFile As String = result.Replace("SUCCESS:", "").Trim()
            MessageBox.Show(
                "File encrypted successfully!" & vbNewLine & vbNewLine &
                "Saved as:" & vbNewLine & outputFile,
                "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtEncryptFile.Text = ""
            txtEncryptPassword.Text = ""
        Else
            Dim errMsg As String = result.Replace("ERROR:", "").Trim()
            MessageBox.Show("Encryption failed:" & vbNewLine & errMsg,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ========== DECRYPT BUTTON ==========
    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click
        If txtDecryptFile.Text = "" OrElse txtDecryptFile.Text = "No file selected..." Then
            MessageBox.Show("Please select a file to decrypt.", "Missing File",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtDecryptPassword.Text = "" Then
            MessageBox.Show("Please enter a password.", "Missing Password",
                MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not File.Exists(txtDecryptFile.Text) Then
            MessageBox.Show("Selected file does not exist.", "File Not Found",
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        btnDecrypt.Enabled = False
        btnDecrypt.Text = "Decrypting..."

        Dim result As String = RunPython("decrypt", txtDecryptFile.Text, txtDecryptPassword.Text)

        btnDecrypt.Enabled = True
        btnDecrypt.Text = "Decrypt File"

        If result.StartsWith("SUCCESS:") Then
            Dim outputFile As String = result.Replace("SUCCESS:", "").Trim()
            MessageBox.Show(
                "File decrypted successfully!" & vbNewLine & vbNewLine &
                "Saved as:" & vbNewLine & outputFile,
                "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDecryptFile.Text = ""
            txtDecryptPassword.Text = ""
        Else
            Dim errMsg As String = result.Replace("ERROR:", "").Trim()
            MessageBox.Show("Decryption failed:" & vbNewLine & errMsg,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ========== RUN PYTHON ==========
    Private Function RunPython(action As String, filePath As String, password As String) As String
        Dim pythonExe As String = FindPython()
        If pythonExe Is Nothing Then
            Return "ERROR:Python not found. Please install Python and add it to PATH."
        End If

        Dim scriptPath As String = FindScript()
        If scriptPath Is Nothing Then
            Return "ERROR:crypto_backend.py not found. Check your folder structure."
        End If

        Try
            Dim psi As New ProcessStartInfo()
            psi.FileName = pythonExe
            psi.Arguments = String.Format("""{0}"" ""{1}"" ""{2}"" ""{3}""",
                scriptPath, action, filePath, password)
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True
            psi.UseShellExecute = False
            psi.CreateNoWindow = True
            psi.StandardOutputEncoding = System.Text.Encoding.UTF8
            psi.StandardErrorEncoding = System.Text.Encoding.UTF8

            Using proc As Process = Process.Start(psi)
                Dim output As String = proc.StandardOutput.ReadToEnd().Trim()
                Dim errOut As String = proc.StandardError.ReadToEnd().Trim()
                proc.WaitForExit()

                If output <> "" Then
                    Return output
                ElseIf errOut <> "" Then
                    Return "ERROR:" & errOut
                Else
                    Return "ERROR:No response from Python script."
                End If
            End Using

        Catch ex As Exception
            Return "ERROR:" & ex.Message
        End Try
    End Function

End Class