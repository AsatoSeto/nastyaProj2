using System;
using System.Collections.Generic;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Xamarin.Forms;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Tables;
using System.Reflection;

namespace ProjectNastya
{
    
    public partial class MyPage : ContentPage
    {
        public MyPage()
        {
            InitializeComponent();
            GEN.Clicked += generatePDF;
        }
        public void generatePDF(object sender, System.EventArgs e)
        {

            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a new PDF page
            PdfPage page = document.Pages.Add();

            //Get the font file as stream
            Stream fontStream = typeof(MainPage).GetTypeInfo().Assembly.GetManifestResourceStream("ProjectNastya.Assets.arial.ttf");

            //Create a new PdfTrueTypeFont instance
            PdfTrueTypeFont font = new PdfTrueTypeFont(fontStream, 10);

            //Create a new bold stylePdfTrueTypeFont instance
            PdfTrueTypeFont boldFont = new PdfTrueTypeFont(fontStream, 10, PdfFontStyle.Bold);
            //Create PdfGrid
            PdfGrid pdfGrid = new PdfGrid();

            ProgClass a = new ProgClass();
            

            //Draw grid to the page of PDF document
            PdfGridLayoutResult result = pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, 20));

            //Declare a PdfLightTable
            PdfLightTable pdfLightTable = new PdfLightTable();

            //Set the Data source as direct
            pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

            //Create columns
            pdfLightTable.Columns.Add(new PdfColumn("Наименование операции"));
            
            pdfLightTable.Columns.Add(new PdfColumn("Смена"));
           
            pdfLightTable.Columns.Add(new PdfColumn("Всего осмотренно"));
            pdfLightTable.Columns.Add(new PdfColumn("Годных"));
            pdfLightTable.Columns.Add(new PdfColumn("Брак"));
            pdfLightTable.Columns.Add(new PdfColumn("плена"));
            pdfLightTable.Columns.Add(new PdfColumn("чернота"));
            pdfLightTable.Columns.Add(new PdfColumn("забитая"));
            pdfLightTable.Columns.Add(new PdfColumn("тугая"));


            //Add rows
           
            pdfLightTable.Rows.Add(new object[] { pickerNormatDock.SelectedItem.ToString(),
              a.OPA()  ,
            "1",
            "1",
            "1",
            "1",
            "1",
            "1",
            "1",});

            //pdfLightTable.Rows.Add(new object[] { "#E02", "@Thomas", "$2000" });

            pdfLightTable.Style.ShowHeader = true;

            pdfLightTable.Style.HeaderStyle = new PdfCellStyle();
            pdfLightTable.Style.HeaderStyle.Font = boldFont;

            pdfLightTable.Style.DefaultStyle = new PdfCellStyle();
            pdfLightTable.Style.DefaultStyle.Font = font;

            //Draw the PdfLightTable
            pdfLightTable.Draw(result.Page, new PointF(0, result.Bounds.Bottom + 30));

            MemoryStream stream = new MemoryStream();

            //Save the document
            document.Save(stream);

            //Close the document
            document.Close(true);

            stream.Position = 0;

            //Save the stream as a file in the device and invoke it for viewing
            Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
            //Customer customer = new Customer();
            ////Create a new PDF document.
            //PdfDocument doc = new PdfDocument();
            ////Add a page.
            //PdfPage page = doc.Pages.Add();
            ////Create a PdfGrid.
            //PdfLightTable pdfGrid = new PdfLightTable();
            ////Add values to list
            //List<object> data = new List<object>();
            //Object row1 = new  { Operation = "Operation", Smena = "Smena", All = "Osmotrenno", Godno = "Godnih", Brak = "Brak", Plena = "Plena", Chernota = "Chernota", Zabita = "Zabita", Tugaya = "Tugaya" };
            //Object row2 = new { ID = "E02", Name = "Thomas" };
            //Object row3 = new { ID = "E03", Name = "Andrew" };
            //Object row4 = new { ID = "E04", Name = "Paul" };
            //Object row5 = new { ID = "E05", Name = "Gray" };
            //data.Add(row1);
            ////data.Add(row2);
            ////data.Add(row3);
            ////data.Add(row4);
            ////data.Add(row5);
            ////Add list to IEnumerable
            //IEnumerable<object> dataTable = data;
            ////Assign data source.
            //pdfGrid.DataSource = dataTable;
            ////Draw grid to the page of PDF document.
            //pdfGrid.Draw(page, new PointF(10, 10));
            //pdfGrid.Style.ShowHeader = true;
            ////Save the PDF document to stream.
            //MemoryStream stream = new MemoryStream();
            //doc.Save(stream);
            ////Close the document.
            //doc.Close(true);

            ////Save the stream as a file in the device and invoke it for viewing
            //Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
        }

       
    }

}
public class Customer
{
    public string Operation { get; set; }
    public string Smena { get; set; }
    public int All { get; set; }
    public int Godno { get; set; }
    public int Brak { get; set; }
    public int Plena { get; set; }
    public int Chernota { get; set; }
    public int Zabita { get; set; }
    public int Tugaya { get; set; }

}