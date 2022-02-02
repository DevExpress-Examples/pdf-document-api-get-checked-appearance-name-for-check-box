Imports DevExpress.Pdf

Namespace GetCheckboxCheckedValue

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            ' Load a document with an interactive form.
            Dim processor As PdfDocumentProcessor = New PdfDocumentProcessor()
            processor.LoadDocument("..\..\InteractiveForm.pdf")
            Dim documentFacade As PdfDocumentFacade = processor.DocumentFacade
            Dim acroForm As PdfAcroFormFacade = documentFacade.AcroForm
            ' Obtain the check box form field:
            Dim genderField As PdfCheckBoxFormFieldFacade = acroForm.GetCheckBoxFormField("Female")
            ' Specify a checked value for the Female form field:
            genderField.IsChecked = True
            ' Save the modified document.
            processor.SaveDocument("..\..\Result.pdf")
        End Sub
    End Class
End Namespace
