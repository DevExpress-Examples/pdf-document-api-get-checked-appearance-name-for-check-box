Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Pdf

Namespace GetCheckboxCheckedValue
    Friend Class Program

        Shared Sub Main(ByVal args() As String)

            ' Load a document with an interactive form.
            Dim processor As New PdfDocumentProcessor()
            processor.LoadDocument("..\..\InteractiveForm.pdf")

            ' Obtain interactive form data from a document.
            Dim formData As PdfFormData = processor.GetFormData()

            ' Specify a cheched value for the Female form field obtained from the GetCheckboxCheckedValue method.
            formData("Female").Value = GetCheckboxCheckedValue(processor, "Female")

            ' Apply data to the interactive form. 
            processor.ApplyFormData(formData)

            ' Save the modified document.
            processor.SaveDocument("..\..\Result.pdf")
        End Sub

        Private Shared Function GetCheckboxCheckedValue(ByVal processor As PdfDocumentProcessor, ByVal fieldName As String) As String
            If processor.Document Is Nothing OrElse processor.Document.AcroForm Is Nothing Then
                Return Nothing
            End If
            Dim button As PdfInteractiveFormField = FindCheckBox(processor.Document.AcroForm.Fields, "", fieldName)
            If button IsNot Nothing Then
                Dim appearance As PdfAnnotationAppearances = button.Widget.Appearance
                If appearance IsNot Nothing Then
                    Dim names As IList(Of String) = appearance.Normal.Forms.Keys.ToList()
                    If names.Count = 1 Then
                        Return names.First()
                    End If
                    If names.Count > 1 Then
                        Return If(names(0) = "Off", names(1), names(0))
                    End If
                End If
                Return Nothing
            End If
            Return Nothing
        End Function

        Private Shared Function FindCheckBox(ByVal fields As IEnumerable(Of PdfInteractiveFormField), ByVal partialName As String, ByVal fieldName As String) As PdfInteractiveFormField
            For Each field As PdfInteractiveFormField In fields
                If partialName & field.Name = fieldName Then
                    If field.Flags.HasFlag(PdfInteractiveFormFieldFlags.Radio) OrElse field.Flags.HasFlag(PdfInteractiveFormFieldFlags.PushButton) OrElse field.Widget Is Nothing Then
                        Return Nothing
                    End If
                    Return TryCast(field, PdfButtonFormField)
                End If
                If field.Kids IsNot Nothing Then
                    Dim intermediateResult As PdfInteractiveFormField = FindCheckBox(field.Kids, partialName & "." & field.Name, fieldName)
                    If intermediateResult IsNot Nothing Then
                        Return intermediateResult
                    End If
                End If
            Next field
            Return Nothing
        End Function
    End Class
End Namespace
