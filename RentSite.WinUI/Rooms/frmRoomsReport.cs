using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentSite.WinUI.Rooms
{
    public partial class frmRoomsReport : Form
    {
        private readonly APIService _roomsRentedService = new APIService("RoomsReport");
        private readonly APIService _rentedRoomsService = new APIService("RoomsNoFIlterReport");


        public frmRoomsReport()
        {
            InitializeComponent();
            this.dgvRoomsReport.DataError += this.DataGridView_DataError;
        }
        void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private async void frmRoomsReport_Load(object sender, EventArgs e)
        {
            var listForCountAll = await _rentedRoomsService.Get<List<Model.RoomsNoFilterReport>>();
            dgvRoomsReport.DataSource = listForCountAll;
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                if (int.TryParse(tytFilterByYear.Text, out int year))
                {
                    if (year > 0)
                    {
                        YearSearchRequest searchRequest = new YearSearchRequest()
                        {
                            Year = year
                        };
                        var list = await _roomsRentedService.Get<List<Model.RoomsReport>>(searchRequest);
                        int? totalForSelectedYears = 0;
                        foreach (var x in list)
                        {
                            totalForSelectedYears += int.Parse(x.TotalPrice.ToString());
                        }
                        txtSelected.Text = totalForSelectedYears.ToString();
                        dgvRoomsReport.DataSource = list;
                        errorProvider1.SetError(tytFilterByYear, null);
                    }
                    else
                    {
                        errorProvider1.SetError(tytFilterByYear, "Year must be greater than 0!");
                    }

                }
                else
                {
                    errorProvider.SetError(tytFilterByYear, "You must enter number!");
                }
            }
        }

        private void tytFilterByYear_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tytFilterByYear.Text))
            {

                decimal val;
                var isNumeric = decimal.TryParse(tytFilterByYear.Text, out val);

                if (!isNumeric)
                {
                    errorProvider.SetError(tytFilterByYear, "You must enter number!");
                    e.Cancel = true;
                }
            }
            else
            {
                errorProvider.SetError(tytFilterByYear, null);
            }
        }

        PrintPreviewDialog printPreview = new PrintPreviewDialog();
        PrintDocument printDocument = new PrintDocument();

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            Print(this.panelPrinting1);
        }

        public void Print(Panel panelPrinting)
        {
            PrinterSettings ps = new PrinterSettings();
            panelPrinting1 = panelPrinting;
            GetPrintingArea(panelPrinting);
            printPreview.Document = printDocument;
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_printPage);
            printPreview.ShowDialog();
        }

        public void printDocument_printPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryImage, (pagearea.Width / 2) - (this.panelPrinting1.Width / 2), this.panelPrinting1.Location.Y);
        }

        Bitmap memoryImage;
        public void GetPrintingArea(Panel panelPrinting)
        {
            memoryImage = new Bitmap(panelPrinting.Width, panelPrinting.Height);
            panelPrinting.DrawToBitmap(memoryImage, new Rectangle(0, 0, panelPrinting.Width, panelPrinting.Height));

        }
    }
}
