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
        public string Smena;
        public string Master;
        public string OTKController;
        public string Brig;
        public string Uchastok;
        public string Date;


        public MyPage(string smena, string brigada, string uchastok, string otkcontroller, string master, string date)
        {
            //ProgClass a = new ProgClass();

            InitializeComponent();
            pickerNormatDock.SelectedIndex = 0;
            pickerЕhread.SelectedIndex = 0;
            pickerEndurance.SelectedIndex = 0;

            GEN.Clicked += generatePDF;
            Smena = smena;
            Brig = brigada;
            Uchastok = uchastok;
            OTKController = otkcontroller;
            Master = master;
            Date = date;
            initVars();
        }

        private void initVars() {
            diam.Text = "0";
            wall.Text = "0";
            orderNum.Text = "0";
            partNum.Text = "0";
            plavka.Text = "0";
            all.Text = "0";
            usable.Text = "0";
            brak.Text = "0";
            tape.Text = "0";
            blackness.Text = "0";
            clogged.Text = "0";
            tugaya.Text = "0";

            

        }
        private async void usableChanged(object sender, System.EventArgs e) {
            if (String.IsNullOrWhiteSpace(all.Text)) {
                await DisplayAlert("Ошибка", "Поле Всего не должно быть пустым", "OК");
                return;
            }
            if (String.IsNullOrWhiteSpace(all.Text))
            {
                await DisplayAlert("Ошибка", "Поле Годных не должно быть пустым", "OК");
                return;
            }
            if (0 >= Int64.Parse(all.Text))
            {
                await DisplayAlert("Ошибка", "Поле Всего не может быть меньше либо равно 0", "OК");
                return;
            }
            if (Int64.Parse(usable.Text) > Int64.Parse(all.Text))
            {
                await DisplayAlert("Ошибка", "Поле Годных не может быть больше поля Всего", "OК");
                return;
            }
            if (Int64.Parse(usable.Text) <= Int64.Parse(all.Text) && 0 <= Int64.Parse(usable.Text))
            {
                brak.Text = Convert.ToString(Int64.Parse(all.Text) - Int64.Parse(usable.Text));
            }
        }

        private bool anyFieldIsEmpty() {
            if (String.IsNullOrWhiteSpace(diam.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(wall.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(orderNum.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(partNum.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(plavka.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(all.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(usable.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(brak.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(tape.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(blackness.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(clogged.Text))
            {
                return true;
            }
            if (String.IsNullOrWhiteSpace(tugaya.Text))
            {
                return true;
            }
            return false;
        }

        public async void generatePDF(object sender, System.EventArgs e)
        {

            if (anyFieldIsEmpty()) {
                await DisplayAlert("Ошибка", "Все поля должны быть заполнены", "OК");
                return;
            }

            if (brak.Text != "0") {
                if ((Int64.Parse(tape.Text) +
                    Int64.Parse(blackness.Text) +
                    Int64.Parse(clogged.Text) +
                    Int64.Parse(tugaya.Text)) != Int64.Parse(brak.Text))
                {
                    await DisplayAlert("Ошибка", "Сумма полей типов брака должна быть равна количеству отбракованных", "OК");
                    return;
                }
            }

            //Create a new PDF document
            PdfDocument document = new PdfDocument();

            //Add a new PDF page
            PdfPage page = document.Pages.Add();

            //Get the font file as stream
            Stream fontStream = typeof(MainPage).GetTypeInfo().Assembly.GetManifestResourceStream("ProjectNastya.Assets.arial.ttf");

            //Create a new PdfTrueTypeFont instance
            PdfTrueTypeFont font = new PdfTrueTypeFont(fontStream, 8);
            PdfTrueTypeFont middleFont = new PdfTrueTypeFont(fontStream, 12);

            PdfTrueTypeFont fontUnderLine = new PdfTrueTypeFont(fontStream, 8, PdfFontStyle.Underline);
           

            PdfTrueTypeFont middleFontUnderLine = new PdfTrueTypeFont(fontStream, 12, PdfFontStyle.Underline);


            //Create a new bold stylePdfTrueTypeFont instance
            PdfTrueTypeFont boldFont = new PdfTrueTypeFont(fontStream, 8, PdfFontStyle.Bold);
            PdfTrueTypeFont bigFont = new PdfTrueTypeFont(fontStream, 16, PdfFontStyle.Bold);


            PdfTextElement textEl = new PdfTextElement("В-п участок");
            textEl.Font = font;
            textEl.Draw(page, new PointF(0, 0));

            
            PdfTextElement textEl2 = new PdfTextElement("Форма ТР-66");
            textEl2.Font = fontUnderLine;
            textEl2.Draw(page, new PointF(430, 0));

            PdfTextElement textEl3 = new PdfTextElement("ОТК");
            textEl3.Font = font;
            textEl3.Draw(page, new PointF(448, 8));

            PdfTextElement textEl4 = new PdfTextElement("Сведения");
            textEl4.Font = bigFont;
            textEl4.Draw(page, new PointF(220, 30));

            PdfTextElement textEl5 = new PdfTextElement("С: ");
            textEl5.Font = middleFont;
            textEl5.Draw(page, new PointF(0, 75));

            PdfTextElement textEl6 = new PdfTextElement(Uchastok);
            textEl6.Font = middleFontUnderLine;
            textEl6.Draw(page, new PointF(15, 75));

            PdfTextElement textEl7 = new PdfTextElement("М-р: ");
            textEl7.Font = middleFont;
            textEl7.Draw(page, new PointF(350, 75));

            PdfTextElement textEl8 = new PdfTextElement(Master);
            textEl8.Font = middleFontUnderLine;
            textEl8.Draw(page, new PointF(380, 75));



            PdfTextElement textEl9 = new PdfTextElement("Дата: " + Date);
            textEl9.Font = middleFont;
            textEl9.Draw(page, new PointF(20, 200));

            PdfTextElement textEl10 = new PdfTextElement("Контролер ОТК:");
            textEl10.Font = middleFont;
            textEl10.Draw(page, new PointF(300, 200));

            PdfTextElement textEl11 = new PdfTextElement(OTKController);
            textEl11.Font = middleFontUnderLine;
            textEl11.Draw(page, new PointF(395, 200));

            //Declare a PdfLightTable
            PdfLightTable pdfLightTable = new PdfLightTable();



            //Set the Data source as direct
            pdfLightTable.DataSourceType = PdfLightTableDataSourceType.TableDirect;

            //Create columns
            PdfColumn op = new PdfColumn("Наименование операции");
            op.Width = 50;
            pdfLightTable.Columns.Add(op);
            
            pdfLightTable.Columns.Add(new PdfColumn("Смена"));
           
            pdfLightTable.Columns.Add(new PdfColumn("Всего осмотренно"));
            pdfLightTable.Columns.Add(new PdfColumn("Годных"));
            pdfLightTable.Columns.Add(new PdfColumn("Брак"));
            pdfLightTable.Columns.Add(new PdfColumn("плена"));
            pdfLightTable.Columns.Add(new PdfColumn("чернота"));
            pdfLightTable.Columns.Add(new PdfColumn("забитая"));
            pdfLightTable.Columns.Add(new PdfColumn("тугая"));


            pdfLightTable.ColumnProportionalSizing = true;

            //Add rows
           
            pdfLightTable.Rows.Add(new object[] {
             pickerNormatDock.SelectedItem.ToString() + " " +
             pickerЕhread.SelectedItem.ToString() + " " +
             pickerEndurance.SelectedItem.ToString() + " Ø" + diam.Text + "x" + wall.Text +
              " №:" + orderNum.Text + "\n #" + partNum.Text + " п" + plavka.Text,
             Brig + " " + Smena ,
            all.Text,
            usable.Text,
            brak.Text,
            tape.Text,
            blackness.Text,
            clogged.Text,
            tugaya.Text,});

            //pdfLightTable.Rows.Add(new object[] { "#E02", "@Thomas", "$2000" });

            pdfLightTable.Style.ShowHeader = true;

            pdfLightTable.Style.HeaderStyle = new PdfCellStyle();
            pdfLightTable.Style.HeaderStyle.Font = boldFont;

            pdfLightTable.Style.DefaultStyle = new PdfCellStyle();
            pdfLightTable.Style.DefaultStyle.Font = font;

            //Draw the PdfLightTable
            pdfLightTable.Draw(page, new PointF(0, 100));

            MemoryStream stream = new MemoryStream();

            //Save the document
            document.Save(stream);

            //Close the document
            document.Close(true);

            stream.Position = 0;

            //Save the stream as a file in the device and invoke it for viewing
            Xamarin.Forms.DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
          
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