using System.Collections.Generic;
using System.Linq;
using DevExpress.Pdf;

namespace GetCheckboxCheckedValue {
    class Program {

        static void Main(string[] args) {

            // Load a document with an interactive form.
            PdfDocumentProcessor processor = new PdfDocumentProcessor();
            processor.LoadDocument("..\\..\\InteractiveForm.pdf");

            // Obtain interactive form data from a document.
            PdfFormData formData = processor.GetFormData();

            // Specify a cheched value for the Female form field obtained from the GetCheckboxCheckedValue method.
            formData["Female"].Value = GetCheckboxCheckedValue(processor, "Female");

            // Apply data to the interactive form. 
            processor.ApplyFormData(formData);

            // Save the modified document.
            processor.SaveDocument("..\\..\\Result.pdf");
        }

        static string GetCheckboxCheckedValue(PdfDocumentProcessor processor, string fieldName) {
            if (processor.Document == null || processor.Document.AcroForm == null)
                return null;
            PdfInteractiveFormField button = FindCheckBox(processor.Document.AcroForm.Fields, "", fieldName);
            if (button != null) {
                PdfAnnotationAppearances appearance = button.Widget.Appearance;
                if (appearance != null) {
                    IList<string> names = appearance.Normal.Forms.Keys.ToList();
                    if (names.Count == 1)
                        return names.First();
                    if (names.Count > 1)
                        return names[0] == "Off" ? names[1] : names[0];
                }
                return null;
            }
            return null;
        }

        static PdfInteractiveFormField FindCheckBox(IEnumerable<PdfInteractiveFormField> fields, string partialName, string fieldName) {
            foreach (PdfInteractiveFormField field in fields) {
                if (partialName + field.Name == fieldName) {
                    if (field.Flags.HasFlag(PdfInteractiveFormFieldFlags.Radio) || field.Flags.HasFlag(PdfInteractiveFormFieldFlags.PushButton) || field.Widget == null)
                        return null;
                    return field as PdfButtonFormField;
                }
                if (field.Kids != null) {
                    PdfInteractiveFormField intermediateResult = FindCheckBox(field.Kids, partialName + "." + field.Name, fieldName);
                    if (intermediateResult != null)
                        return intermediateResult;
                }
            }
            return null;
        }
    }
}
