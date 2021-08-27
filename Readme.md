<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128595612/21.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T609857)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Program.cs](./CS/GetCheckboxCheckedValue/Program.cs) (VB: [Program.vb](./VB/GetCheckboxCheckedValue/Program.vb))
<!-- default file list end -->
# How to obtain a checked appearance name for a check box

<strong>Note:</strong> with the 21.1 major release, the <b>PdfDocumentFacade</b> class allows you to change the PDF document without access to its inner structure. Use the <b>PdfDocumentFacade.AcroForm</b> property to get interactive form field options. You can change form field and appearance properties.

This example shows how to get a checked appearance name for the "Female" check box and check the check box with this value.<br><br>To accomplish this task, call the <strong>GetCheckboxCheckedValue</strong>  method using a<a href="https://documentation.devexpress.com/DocumentServer/DevExpress.Pdf.PdfDocumentProcessor.class"> PdfDocumentProcessor</a> instance and the field name. <br><br>To obtain interactive form data, call the <a href="https://documentation.devexpress.com/DocumentServer/DevExpress.Pdf.PdfDocumentProcessor.GetFormData.method">PdfDocumentProcessor.GetFormData </a>method. To check the "Female" check box, use the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfFormData.Value.property">PdfFormData.Value</a> property.

<br/>


