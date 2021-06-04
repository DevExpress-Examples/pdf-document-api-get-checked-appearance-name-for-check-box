using DevExpress.Pdf;

namespace GetCheckboxCheckedValue
{
    class Program
    {

        static void Main(string[] args)
        {
            // Load a document with an interactive form.
            PdfDocumentProcessor processor = new PdfDocumentProcessor();
            processor.LoadDocument("..\\..\\InteractiveForm.pdf");

            PdfDocumentFacade documentFacade = processor.DocumentFacade;
            PdfAcroFormFacade acroForm = documentFacade.AcroForm;

            // Obtain the check box form field:
            PdfCheckBoxFormFieldFacade genderField = acroForm.GetCheckBoxFormField("Female");

            // Specify a checked value for the Female form field:
            genderField.IsChecked = true;

            // Save the modified document.
            processor.SaveDocument("..\\..\\Result.pdf");
        }

    }
}
