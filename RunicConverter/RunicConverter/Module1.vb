Imports System
Imports System.Windows.Forms
Module Module1
    Const arg_Err As String = "invalid arguments"
    Const main_Err As String = "Main process error"
    Const success_header As String = "Success"
    Const warn_header As String = "Failed to convert some characters"
    Const error_header As String = "error"
    Const is_normal As Int16 = 0
    Const is_warning As Int16 = 4
    Const is_error As Int16 = 8

    Public inapplicable As String

    Public ret As Int16 = is_normal


    Sub Main(args As String())
        Try

            Dim ConvStr As String

            If args.Length <> 1 Then
                Console.WriteLine(arg_Err)
                Throw New Exception(arg_Err)
            End If

            ConvStr = RunicConvert(args(0))

            If ret = is_warning Then
                MessageBox.Show("follow characters are inapplicable : " + inapplicable + vbCrLf + "---------------------------------------------" + vbCrLf + ConvStr,
                warn_header,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2)
                Console.WriteLine(RunicConvert(args(0)))
            Else
                MessageBox.Show(ConvStr,
                success_header,
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button2)
                Console.WriteLine(RunicConvert(args(0)))
            End If

        Catch ex As System.Exception
            MessageBox.Show(ex.Message,
                            error_header,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2)
            Console.WriteLine(ex.Message)
            ret = is_error

        Finally

            Environment.Exit(ret)

        End Try

    End Sub
    Function RunicConvert(arg As String) As String
        Try
            Dim str As String = ""
            For Each Chr As Char In arg
                Select Case Chr
                    Case "f"
                        str += "ᚠ"
                    Case "u"
                        str += "ᚢ"
                    Case "þ" 'pending
                        str += "ᚦ"
                    Case "a"
                        str += "ᚨ"
                    Case "r"
                        str += "ᚱ"
                    Case "k"
                        str += "ᚲ"
                    Case "g"
                        str += "ᚷ"
                    Case "w"
                        str += "ᚹ"
                    Case "h"
                        str += "ᚺ"
                    Case "n"
                        str += "ᚾ"
                    Case "i"
                        str += "ᛁ"
                    Case "j"
                        str += "ᛃ"
                    Case "y", "ü", "é"   'pending
                        str += "ᛇ"
                    Case "p"
                        str += "ᛈ"
                    Case "z"  'pending
                        str += "ᛉ"
                    Case "s"
                        str += "ᛋ"
                    Case "t"
                        str += "ᛏ"
                    Case "b"
                        str += "ᛒ"
                    Case "e"
                        str += "ᛖ"
                    Case "m"
                        str += "ᛗ"
                    Case "l"
                        str += "ᛚ"
                    Case "ŋ", "ng", "ing"
                        str += "ᛜ"
                    Case "o"
                        str += "ᛟ"
                    Case "d"
                        str += "ᛞ"
                    Case " ", "　"
                        str += Chr
                    Case Else
                        str += Chr
                        inapplicable += Chr
                        ret = is_warning
                End Select
            Next

            Return str
        Catch ex As System.Exception
            Console.WriteLine("Convert error")
            Throw
        End Try
    End Function

End Module
