<!-- default file list -->
*Files to look at*:

* [Program.cs](./CS/GetCheckboxCheckedValue/Program.cs) (VB: [Program.vb](./VB/GetCheckboxCheckedValue/Program.vb))
<!-- default file list end -->
# How to obtain a checked appearance name for a check box

<strong>Note:</strong> with the 21.1 major release, the <b>PdfDocumentFacade</b> class allows you to change the PDF document without access to its inner structure. Use the <b>PdfDocumentFacade.AcroForm</b> property to get interactive form field options. You can change form field and appearance properties.

This example shows how to get a checked appearance name for the "Female" check box and check the check box with this value.<br><br>To accomplish this task, call the <strong>GetCheckboxCheckedValue</strong>  method using a<a href="https://documentation.devexpress.com/DocumentServer/DevExpress.Pdf.PdfDocumentProcessor.class"> PdfDocumentProcessor</a> instance and the field name. <br><br>To obtain interactive form data, call the <a href="https://documentation.devexpress.com/DocumentServer/DevExpress.Pdf.PdfDocumentProcessor.GetFormData.method">PdfDocumentProcessor.GetFormData </a>method. To check the "Female" check box, use the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfFormData.Value.property">PdfFormData.Value</a> property.

<br/>


