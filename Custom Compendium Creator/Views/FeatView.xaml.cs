using System;
using System.Collections.Generic;
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
        }

        //private void InsertTable(object sender, RoutedEventArgs e)
        //{
        //    rtb.BeginChange();
        //    var table = new Table();
        //    var gridLenghtConvertor = new GridLengthConverter();
        //    table.Columns.Add(new TableColumn());
        //    table.Columns.Add(new TableColumn());
        //    table.Columns.Add(new TableColumn());

        //    table.RowGroups.Add(new TableRowGroup());
        //    for (int i = 0; i < 3; i++)
        //    {
        //        table.RowGroups[0].Rows.Add(new TableRow());
        //        table.RowGroups[0].Rows[i].Cells.Add(new TableCell() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black });
        //        table.RowGroups[0].Rows[i].Cells.Add(new TableCell() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black });
        //        table.RowGroups[0].Rows[i].Cells.Add(new TableCell() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black });
        //        table.RowGroups[0].Rows[i].Cells.Add(new TableCell() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black });
        //        table.RowGroups[0].Rows[i].Cells.Add(new TableCell() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black });
        //    }
        //    rtb.Document.Blocks.Add(table);
        //    rtb.EndChange();
        //}

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
                    table.RowGroups[0].Rows[i].Cells.Add(new TableCell() { BorderThickness = new Thickness(1), BorderBrush = Brushes.Black });
                }
            }

            //rtb.Document.Blocks.Add(table);
            TextPointer tp = rtb.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
            rtb.CaretPosition = tp;

            // https://stackoverflow.com/questions/71193569/richtextbox-insert-xaml-at-caret-position
            rtb.Document.Blocks.InsertAfter(rtb.CaretPosition.Paragraph, table);
            rtb.Document.Blocks.InsertAfter(table, new Paragraph());

            //tp = rtb.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
            //rtb.CaretPosition = tp;

            //rtb.CaretPosition.InsertLineBreak();

            rtb.EndChange();


            //TextPointer tp2 = rtb.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
            //rtb.CaretPosition.InsertTextInRun("test");
            //rtb.CaretPosition = tp2;
            //rtb.EndChange();

            //rtb.BeginChange();

            //TextPointer tp2 = rtb.CaretPosition.GetPositionAtOffset(0, LogicalDirection.Forward);
            //rtb.CaretPosition.InsertTextInRun("test");
            //rtb.CaretPosition = tp2;
            //rtb.EndChange();
            //Keyboard.Focus(rtb);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
