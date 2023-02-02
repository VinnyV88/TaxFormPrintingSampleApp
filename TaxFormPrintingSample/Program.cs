using Syncfusion.Licensing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;

// Use your Syncfusion License Key Here
//SyncfusionLicenseProvider.RegisterLicense("");

string path = Directory.GetCurrentDirectory(); 

PdfDocument document = new PdfDocument();

//Set EnableMemoryOptimization to true
document.EnableMemoryOptimization = true;

string fileName = $"{path}\\PDFs\\SyncFusion_W2_2022_01[1_to_250].pdf";
//Create output file stream.
using (FileStream outputFileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
{
    for (int i = 1; i <= 250; i++)
    {
        Stream fileIn = new FileStream($"{path}\\Template\\w2_template.pdf", FileMode.Open, FileAccess.Read, FileShare.Read);
        // Create a byte array of file stream length  
        byte[] pdfData = new byte[fileIn.Length];
        //Read block of bytes from stream into the byte array   
        fileIn.Read(pdfData, 0, Convert.ToInt32(pdfData.Length));
        // Load the byte array 
        PdfLoadedDocument loadedDocument = new PdfLoadedDocument(pdfData);
        loadedDocument.Compression = PdfCompressionLevel.Best;
        //Get the loaded form
        PdfLoadedForm loadedForm = loadedDocument.Form;

        (loadedForm.Fields["WSSN"] as PdfLoadedTextBoxField).Text = "123456789";
        (loadedForm.Fields["WYEAR"] as PdfLoadedTextBoxField).Text = "2022";
        (loadedForm.Fields["WCNTRLNUM"] as PdfLoadedTextBoxField).Text = i.ToString("D8");
        (loadedForm.Fields["WEMPIDNUM"] as PdfLoadedTextBoxField).Text = "111222333444";
        (loadedForm.Fields["WEMPNAME1"] as PdfLoadedTextBoxField).Text = "EMPLOYER NAME 1";
        (loadedForm.Fields["WEMPNAME2"] as PdfLoadedTextBoxField).Text = "EMPLOYER NAME 2";
        (loadedForm.Fields["WEADDLN1"] as PdfLoadedTextBoxField).Text = "ADDRESS LINE 1";
        (loadedForm.Fields["WEADDLN2"] as PdfLoadedTextBoxField).Text = "ADDRESS LINE 2";
        (loadedForm.Fields["WMUSNAME"] as PdfLoadedTextBoxField).Text = "EMPLOYEE NAME";
        (loadedForm.Fields["WMADDLN1"] as PdfLoadedTextBoxField).Text = "ADDRESS LINE 1";
        (loadedForm.Fields["WMADDLN2"] as PdfLoadedTextBoxField).Text = "ADDRESS LINE 2";
        (loadedForm.Fields["WMADDLN3"] as PdfLoadedTextBoxField).Text = "ADDRESS LINE 3";
        (loadedForm.Fields["WMADDLN4"] as PdfLoadedTextBoxField).Text = "ADDRESS LINE 4";
        (loadedForm.Fields["WMADDLN5"] as PdfLoadedTextBoxField).Text = "ADDRESS LINE 5";
        (loadedForm.Fields["WFEDWAGTPS"] as PdfLoadedTextBoxField).Text = "50,000.00";
        (loadedForm.Fields["WFEDINCTAX"] as PdfLoadedTextBoxField).Text = "5,000.00";
        (loadedForm.Fields["WSSWAGES"] as PdfLoadedTextBoxField).Text = "50,000.00";
        (loadedForm.Fields["WSSTAX"] as PdfLoadedTextBoxField).Text = "500.00";
        (loadedForm.Fields["WMEDWAGTPS"] as PdfLoadedTextBoxField).Text = "50,000.00";
        (loadedForm.Fields["WMEDWAGTAX"] as PdfLoadedTextBoxField).Text = "500.00"; ;
        (loadedForm.Fields["WSTATE"] as PdfLoadedTextBoxField).Text = "NY";
        (loadedForm.Fields["WSTAIDNUM"] as PdfLoadedTextBoxField).Text = "987654321";
        (loadedForm.Fields["WSTAWAGTPS"] as PdfLoadedTextBoxField).Text = "50,000.00"; 
        (loadedForm.Fields["WSTAWAGTAX"] as PdfLoadedTextBoxField).Text = "200.00";
        (loadedForm.Fields["WLOCNAMES"] as PdfLoadedTextBoxField).Text = "NEW YORK";
        (loadedForm.Fields["WLOCWAGTPS"] as PdfLoadedTextBoxField).Text = "0.00";
        (loadedForm.Fields["WLOCWAGTAX"] as PdfLoadedTextBoxField).Text = "0.00";
        (loadedForm.Fields["WOTHER"] as PdfLoadedTextBoxField).Text = "25.75      NYUI";

        //Flatten the whole form.
        loadedForm.Flatten = true;
        document.Append(loadedDocument);
        Console.WriteLine($"Append document {i}");
        loadedDocument.Close(true);

    }
    Console.WriteLine("Save File!");
    document.Save(outputFileStream);
    document.Close(true);
}
Console.WriteLine("FINISHED!!!");

