
using iTextSharp.text;
using iTextSharp.text.pdf;
using MCGA.Business;
using MCGA.Entities;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;


namespace MCGA.UI.Process
{
    public class TurnoProcess : ICrud<Turno>
    {
        private TurnoComponent component = new TurnoComponent();
        public void Create(Turno entity)
        {
            component.Create(entity);
        }

        public void Delete(Turno entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            component.Dispose();
        }

        public IList<Turno> Get()
        {
            return component.Get();
        }

        public Turno GetDetail(int? id)
        {
            return component.GetDetail(id);
        }

        public void Update(Turno entity)
        {
            throw new NotImplementedException();
        }

        public int getEspecialidadProfesionalId(int profesionalId, int especialidaId)
        {
            return component.getEspecialidadProfesionalId(profesionalId, especialidaId);
        }

        public IList<TurnoTimesDummy> GetTimes(string dia)
        {
            return component.GetTimes(dia);
        }

        public void GeneratePdf(int id)
        {
            var turno = component.GetById(id);

            var document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream($"C://Users/Connie/turno{turno.Afiliado.Apellido}.pdf", FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

            PdfPTable table = new PdfPTable(6);

            //float[] widths = new float[] { 4f, 4f, 4f, 4f };

            //table.SetWidths(widths);
            PdfPHeaderCell header = new PdfPHeaderCell();
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Turnos"))
            {
                Colspan = 6
            };
            table.AddCell(new Phrase("Afiliado"));
            table.AddCell(new Phrase("Fecha"));
            table.AddCell(new Phrase("Hora"));
            table.AddCell(new Phrase("Médico"));
            table.AddCell(new Phrase("Especialidad"));
            table.AddCell(new Phrase("Observaciones"));

            table.AddCell(new Phrase(turno.Afiliado.Nombre + " " + turno.Afiliado.Apellido));
            table.AddCell(new Phrase(turno.Fecha.ToShortDateString()));
            table.AddCell(new Phrase(turno.Hora.ToString()));
            table.AddCell(new Phrase(turno.EspecialidadesProfesional.Profesional.Nombre + " " +
                turno.EspecialidadesProfesional.Profesional.Apellido));
            table.AddCell(new Phrase(turno.EspecialidadesProfesional.Especialidad.descripcion));
            table.AddCell(new Phrase(turno.Observaciones));

            document.AddHeader("MEDICURE S.A", $"Turno de Medicure para el afiliado {turno.Afiliado.Nombre + " " + turno.Afiliado.Apellido}. Todos los derechos reservados.");
            document.AddAuthor("Medicure S.A");
            document.AddCreationDate();
            document.Add(cell);
            document.Add(table);
            document.Close();
        }

        public int[] GetByMonth()
        {
            return component.GetByMonth();
        }

        public void Pdf(int id)
        {
            //var turno = component.GetById(id);
            // Create a new PDF document
            //PdfDocument document = new PdfDocument();

            // Create an empty page
            //PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            //XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
          //  XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            // Draw the text
            //gfx.DrawString("Afiliado: " + turno.Afiliado.Nombre + " " + turno.Afiliado.Apellido, font, XBrushes.Black,
             // new XRect(0, 0, page.Width, page.Height),
             // XStringFormat.Center);

            // Save the document...
           // string filename = "Turno.pdf";
           // File.SetAttributes(filename, FileAttributes.Normal);
           // document.Save(filename);
            // ...and start a viewer.
            
            // Process.Start(filename);
        }
    }
}
