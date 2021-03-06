﻿Imports Microsoft.Win32

Namespace SettingManager

    Module SettingManagerModule

        Private Function GetRoot() As RegistryKey

            Dim SettingKeyRoot As RegistryKey = Registry.CurrentUser.CreateSubKey("SSMSAddin")
            Dim testSettings As RegistryKey = SettingKeyRoot.CreateSubKey("Settings")

            Return testSettings

        End Function


        Function GetTemplatesFolder() As String

            Dim Folder As String = ""

            Try

                Dim RootKey = GetRoot()

                Folder = RootKey.GetValue("ScriptTemplatesFolder").ToString

            Catch ex As Exception
            End Try

            'Dim Folder = "C:\Users\abochkov\Source\Repos\ssms-addin\SSMS_Tool\QueryTemplates"
            'If My.Computer.Name = "ALEX-PC" Then
            '    Folder = "F:\_mdoc\_Projects VS 2010\SSMS_Tool\SSMS_Tool\QueryTemplates"
            'End If

            Return Folder

        End Function

        Function SaveTemplatesFolder(Folder As String) As Boolean

            Try

                Dim RootKey = GetRoot()

                RootKey.SetValue("ScriptTemplatesFolder", Folder)
                RootKey.Close()

            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function

        Function GetExcelExportFolder() As String

            Dim Folder As String = ""

            Try

                Dim RootKey = GetRoot()

                Folder = RootKey.GetValue("ExcelExportFolder").ToString

            Catch ex As Exception
            End Try

            Return Folder

        End Function

        Function SaveExcelExportFolder(Folder As String) As Boolean

            Try

                Dim RootKey = GetRoot()

                RootKey.SetValue("ExcelExportFolder", Folder)
                RootKey.Close()

            Catch ex As Exception
                Return False
            End Try

            Return True

        End Function

    End Module

End Namespace
