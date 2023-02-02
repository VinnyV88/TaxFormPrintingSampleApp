using IronPdf;
// Don't necessarily need a license key, but wanted to show apples to apples. 
// I removed my trial license key
//License.LicenseKey = "";

string path = Directory.GetCurrentDirectory();

string fileName = $"{path}\\PDFs\\IronPDF_W2_2022_01[1_to_250].pdf";

var pdfs = new List<PdfDocument>();


using (FileStream outputFileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
{
    for (int i = 1; i <= 250; i++)
    {
        PdfDocument doc = PdfDocument.FromFile($"{path}\\Template\\w2_template.pdf");

        var loadedForm = doc.Form;

        loadedForm.GetFieldByName("WSSN").Value = "123456789";
        loadedForm.GetFieldByName("WYEAR").Value = "2022";
        loadedForm.GetFieldByName("WCNTRLNUM").Value = i.ToString("D8");
        loadedForm.GetFieldByName("WEMPIDNUM").Value = "111222333444";
        loadedForm.GetFieldByName("WEMPNAME1").Value = "EMPLOYER NAME 1";
        loadedForm.GetFieldByName("WEMPNAME2").Value = "EMPLOYER NAME 2";
        loadedForm.GetFieldByName("WEADDLN1").Value = "ADDRESS LINE 1";
        loadedForm.GetFieldByName("WEADDLN2").Value = "ADDRESS LINE 2";
        loadedForm.GetFieldByName("WMUSNAME").Value = "EMPLOYEE NAME";
        loadedForm.GetFieldByName("WMADDLN1").Value = "ADDRESS LINE 1";
        loadedForm.GetFieldByName("WMADDLN2").Value = "ADDRESS LINE 2";
        loadedForm.GetFieldByName("WMADDLN3").Value = "ADDRESS LINE 3";
        loadedForm.GetFieldByName("WMADDLN4").Value = "ADDRESS LINE 4";
        loadedForm.GetFieldByName("WMADDLN5").Value = "ADDRESS LINE 5";
        loadedForm.GetFieldByName("WFEDWAGTPS").Value = "50,000.00";
        loadedForm.GetFieldByName("WFEDINCTAX").Value = "5,000.00";
        loadedForm.GetFieldByName("WSSWAGES").Value = "50,000.00";
        loadedForm.GetFieldByName("WSSTAX").Value = "500.00";
        loadedForm.GetFieldByName("WMEDWAGTPS").Value = "50,000.00";
        loadedForm.GetFieldByName("WMEDWAGTAX").Value = "500.00"; ;
        loadedForm.GetFieldByName("WSTATE").Value = "NY";
        loadedForm.GetFieldByName("WSTAIDNUM").Value = "987654321";
        loadedForm.GetFieldByName("WSTAWAGTPS").Value = "50,000.00"; 
        loadedForm.GetFieldByName("WSTAWAGTAX").Value = "200.00";
        loadedForm.GetFieldByName("WLOCNAMES").Value = "NEW YORK";
        loadedForm.GetFieldByName("WLOCWAGTPS").Value = "0.00";
        loadedForm.GetFieldByName("WLOCWAGTAX").Value = "0.00";
        loadedForm.GetFieldByName("WOTHER").Value = "25.75      NYUI";

        doc.Flatten();
        pdfs.Add(doc);
        Console.WriteLine($"Append document {i}");

    }
    var pdf = PdfDocument.Merge(pdfs);

    Console.WriteLine("Save File!");
    outputFileStream.Write(pdf.BinaryData);
}
Console.WriteLine("FINISHED!!!");
