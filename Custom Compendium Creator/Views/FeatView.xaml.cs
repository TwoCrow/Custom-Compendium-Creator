using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Custom_Compendium_Creator.Stores;

namespace Custom_Compendium_Creator.Views
{
    /// <summary>
    /// Interaction logic for FeatView.xaml
    /// </summary>
    public partial class FeatView
    {
        public FeatView()
        {
            InitializeComponent();

            // I really hate this, but I can't find another solution.
            // This loads in the summary text stored in the FeatDescriptionStore.
            string rtbText = RemoveColor(FeatDescriptionStore.Description);

            if (rtbText != null && FeatStore.IsExistingFeat)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(rtbText);
                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    TextRange range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                    range.Load(stream, DataFormats.Rtf);
                }
            }
        }

        string RemoveColor(string str)
        {
            if (str == null)
            {
                return null;
            }

            int firstPassIndex = str.IndexOf("{\\colortbl", 0, str.Length);
            int firstPassLength = str.Length - firstPassIndex;
            string firstPass = str.Substring(firstPassIndex, firstPassLength);

            int secondPassIndex = firstPass.IndexOf(";}", 0, firstPass.Length);
            int secondPassLength = firstPass.Length - secondPassIndex;
            string secondPass = firstPass.Substring(0, secondPassIndex + 2);

            return str.Replace(secondPass, "");
        }

        private void InsertTable(object sender, RoutedEventArgs e)
        {
            string columnText = ColumnInput.Text;
            string rowText = RowInput.Text;

            if (columnText == "" || rowText == "")
            {
                MessageBox.Show("Please specify the number of columns and rows for the table.");

                return;
            }

            int columns = Int32.Parse(ColumnInput.Text);
            int rows = Int32.Parse(RowInput.Text);

            if (columns <= 0 || rows <= 0)
            {
                MessageBox.Show("Please specify a number of columns and rows for the table greater than 0.");

                return;
            }

            rtb.BeginChange();

            var table = new Table();
            table.CellSpacing = 0;

            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add(new TableColumn());
            }

            table.RowGroups.Add(new TableRowGroup());

            // Number of iterations in this loop = number of rows
            for (int i = 0; i < rows; i++)
            {
                table.RowGroups[0].Rows.Add(new TableRow());

                // Number of iterations in this loop = number of columns
                for (int j = 0; j < columns; j++)
                {
                    table.RowGroups[0].Rows[i].Cells.Add(new TableCell() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Gray });
                }
            }

            TextPointer tp = rtb.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
            rtb.CaretPosition = tp;

            // https://stackoverflow.com/questions/71193569/richtextbox-insert-xaml-at-caret-position
            rtb.Document.Blocks.InsertAfter(rtb.CaretPosition.Paragraph, table);
            rtb.Document.Blocks.InsertAfter(table, new Paragraph());

            rtb.EndChange();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public void ConvertRichTextBox(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

            using (var stream = new MemoryStream())
            {
                textRange.Save(stream, DataFormats.Rtf);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    FeatDescriptionStore.Description = reader.ReadToEnd();
                }
            }
        }
    }
}
