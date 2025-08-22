using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.IO;

namespace Training_CS.Classes
{
    internal class PdfGen
    {
        public void Generate(string filePath)
        {
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);

            try
            {
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                Font titleFont = FontFactory.GetFont("Arial", 22, Font.BOLD);
                Font headerFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                Font baseFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
                Font labelFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                Font smallFont = FontFactory.GetFont("Arial", 10, Font.ITALIC, BaseColor.GRAY);

                Paragraph title = new Paragraph("Job Application Form", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 25f;
                document.Add(title);

                Paragraph applicantHeader = new Paragraph("Personal Information", headerFont);
                applicantHeader.SpacingAfter = 15f;
                document.Add(applicantHeader);

                LineSeparator line = new LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, -1);
                document.Add(line);
                document.Add(new Chunk("\n"));

                PdfPTable personalTable = new PdfPTable(2);
                personalTable.WidthPercentage = 100;
                personalTable.SetWidths(new float[] { 30f, 70f });
                personalTable.SpacingAfter = 20f;

                AddPersonalField(personalTable, "Full Name:");
                AddPersonalField(personalTable, "Date of Birth:");
                AddPersonalField(personalTable, "Phone Number:");
                AddPersonalField(personalTable, "Email Address:");
                AddPersonalField(personalTable, "Current Address:");
                AddPersonalField(personalTable, "City, State, ZIP:");
                AddPersonalField(personalTable, "Country:");

                document.Add(personalTable);

                Paragraph educationHeader = new Paragraph("Education Background", headerFont);
                educationHeader.SpacingAfter = 15f;
                document.Add(educationHeader);
                document.Add(line);
                document.Add(new Chunk("\n"));

                PdfPTable educationTable = new PdfPTable(4);
                educationTable.WidthPercentage = 100;
                educationTable.SetWidths(new float[] { 30f, 25f, 20f, 25f });

                AddTableHeader(educationTable, "Institution", labelFont);
                AddTableHeader(educationTable, "Degree", labelFont);
                AddTableHeader(educationTable, "Year", labelFont);
                AddTableHeader(educationTable, "Grade/Score", labelFont);

                for (int i = 0; i < 3; i++)
                {
                    AddEmptyCell(educationTable);
                    AddEmptyCell(educationTable);
                    AddEmptyCell(educationTable);
                    AddEmptyCell(educationTable);
                }

                document.Add(educationTable);
                document.Add(new Chunk("\n"));

                Paragraph skillsHeader = new Paragraph("Skills & Qualifications", headerFont);
                skillsHeader.SpacingAfter = 15f;
                document.Add(skillsHeader);
                document.Add(line);
                document.Add(new Chunk("\n"));

                for (int i = 0; i < 5; i++)
                {
                    document.Add(CreateLabelAndLine("Skill " + (i + 1) + ":"));
                }

                Paragraph employmentHeader = new Paragraph("Employment History", headerFont);
                employmentHeader.SpacingAfter = 15f;
                document.Add(employmentHeader);
                document.Add(line);
                document.Add(new Chunk("\n"));

                PdfPTable historyTable = new PdfPTable(4);
                historyTable.WidthPercentage = 100;
                historyTable.SetWidths(new float[] { 30f, 25f, 20f, 25f });

                AddTableHeader(historyTable, "Company Name", labelFont);
                AddTableHeader(historyTable, "Position", labelFont);
                AddTableHeader(historyTable, "Duration", labelFont);
                AddTableHeader(historyTable, "Responsibilities", labelFont);

                for (int i = 0; i < 4; i++)
                {
                    AddEmptyCell(historyTable);
                    AddEmptyCell(historyTable);
                    AddEmptyCell(historyTable);
                    AddEmptyCell(historyTable);
                }

                document.Add(historyTable);
                document.Add(new Chunk("\n"));

                Paragraph referenceHeader = new Paragraph("References", headerFont);
                referenceHeader.SpacingAfter = 15f;
                document.Add(referenceHeader);
                document.Add(line);
                document.Add(new Chunk("\n"));

                for (int i = 0; i < 2; i++)
                {
                    document.Add(CreateLabelAndLine("Reference " + (i + 1) + " Name:"));
                    document.Add(CreateLabelAndLine("Reference " + (i + 1) + " Position:"));
                    document.Add(CreateLabelAndLine("Reference " + (i + 1) + " Contact:"));
                    document.Add(new Chunk("\n"));
                }

                PdfPTable signatureTable = new PdfPTable(2);
                signatureTable.WidthPercentage = 100;
                signatureTable.SpacingAfter = 20f;

                PdfPCell signatureCell = new PdfPCell(new Phrase("Applicant Signature:\n\n\n___________________", baseFont));
                signatureCell.Border = PdfPCell.NO_BORDER;
                signatureCell.Padding = 10;
                signatureTable.AddCell(signatureCell);

                PdfPCell dateCell = new PdfPCell(new Phrase("Date: ___________________", baseFont));
                dateCell.Border = PdfPCell.NO_BORDER;
                dateCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                dateCell.Padding = 10;
                signatureTable.AddCell(dateCell);

                document.Add(signatureTable);
                Console.WriteLine($"PDF generated successfully at: {filePath}");
            }
            catch (DocumentException de)
            {
                throw new System.Exception("PDF generation error: " + de.Message);
            }
            catch (IOException ioe)
            {
                throw new System.Exception("File operation error: " + ioe.Message);
            }
            finally
            {
                document.Close();
            }
        }

        private void AddPersonalField(PdfPTable table, string label)
        {
            Font labelFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            Font valueFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            PdfPCell labelCell = new PdfPCell(new Phrase(label, labelFont));
            labelCell.Border = PdfPCell.NO_BORDER;
            labelCell.Padding = 5;
            table.AddCell(labelCell);

            PdfPCell valueCell = new PdfPCell(new Phrase("_________________________________________________", valueFont));
            valueCell.Border = PdfPCell.NO_BORDER;
            valueCell.Padding = 5;
            table.AddCell(valueCell);
        }

        private void AddTableHeader(PdfPTable table, string text, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 8;
            table.AddCell(cell);
        }

        private void AddEmptyCell(PdfPTable table)
        {
            PdfPCell cell = new PdfPCell(new Phrase(" "));
            cell.Padding = 8;
            table.AddCell(cell);
        }

        private Paragraph CreateLabelAndLine(string labelText)
        {
            Font labelFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var paragraph = new Paragraph();
            paragraph.Add(new Chunk(labelText + " ", labelFont));
            paragraph.Add(new Chunk("________________________________________________________________________"));
            paragraph.SpacingAfter = 8f;
            return paragraph;
        }
    }
}