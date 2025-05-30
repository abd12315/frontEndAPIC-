using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;

namespace FrontEndAPI
{
    public static class Submit
    {
        public static void SaveToDoc(string userInput, string username, string imagePath)
        {
            // Define the target directory
            string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "doc", "response");

            // Ensure the directory exists
            Directory.CreateDirectory(targetDirectory);

            // Define the file path
            string fileName = $"Response_{DateTime.Now:yyyyMMdd_HHmmss}.doc";
            string filePath = Path.Combine(targetDirectory, fileName);

            // Create a new document using Spire.Doc
            Document document = new Document();
            Section section = document.AddSection();

            // Add the username as a heading, centered
            Paragraph headingParagraph = section.AddParagraph();
            headingParagraph.AppendText(username);
            headingParagraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Center;
            headingParagraph.ApplyStyle(BuiltinStyle.Heading1);

            // Add user input to the document
            Paragraph paragraph = section.AddParagraph();
            paragraph.AppendText(userInput);

            // Add the image to the document and position it in the top right corner
            if (File.Exists(imagePath))
            {
                DocPicture picture = section.AddParagraph().AppendPicture(Image.FromFile(imagePath));
                picture.TextWrappingStyle = TextWrappingStyle.Behind;
                picture.HorizontalAlignment = ShapeHorizontalAlignment.Right;
                picture.VerticalAlignment = ShapeVerticalAlignment.Top;
            }

            // Save the document to the specified path
            document.SaveToFile(filePath, FileFormat.Doc);

            Console.WriteLine($"File saved to: {filePath}");
        }
    }
}
