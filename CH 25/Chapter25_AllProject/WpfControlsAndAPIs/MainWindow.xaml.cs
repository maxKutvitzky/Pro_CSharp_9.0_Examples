using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WpfControlsAndAPIs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IConfiguration _configuration;
        private ApplicationDbContext _context;
        public MainWindow()
        {
            InitializeComponent();
            GetConfigurationAndDbContext();
            ConfigureGrid();
            // Be in Ink mode by default.
            this.MyInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.inkRadio.IsChecked = true;
            this.comboColors.SelectedIndex = 0;
        }
        private void ConfigureGrid()
        {
            using var repo = new CarRepo(_context);
            gridInventory.ItemsSource = repo
            .GetAllIgnoreQueryFilters()
            .ToList()
            .Select(x => new {
                x.Id,
                Make = x.MakeName,
                x.Color,
                x.PetName
            });
        }
        private void GetConfigurationAndDbContext()
        {
            _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var optionsBuilder =
            new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString =
            _configuration.GetConnectionString("AutoLotFinal");
            optionsBuilder.UseSqlServer(connectionString,
            sqlOptions => sqlOptions.EnableRetryOnFailure());
            _context = new ApplicationDbContext(optionsBuilder.Options);
        }
        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            this.MyInkCanvas.EditingMode = (sender as RadioButton)?.Content.ToString() switch
            {
                // These strings must be the same as the Content values for each
                // RadioButton.
                "Ink Mode!" => InkCanvasEditingMode.Ink,
                "Erase Mode!" => InkCanvasEditingMode.EraseByStroke,
                "Select Mode!" => InkCanvasEditingMode.Select,
                _ => this.MyInkCanvas.EditingMode
            };
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the Tag of the selected StackPanel.
            string colorToUse = (this.comboColors.SelectedItem as StackPanel).Tag.ToString();
            // Change the color used to render the strokes.
            this.MyInkCanvas.DefaultDrawingAttributes.Color =
            (Color)ColorConverter.ConvertFromString(colorToUse);
        }
        private void SaveData(object sender, RoutedEventArgs e)
        {
            // Save all data on the InkCanvas to a local file.
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Create))
            {
                this.MyInkCanvas.Strokes.Save(fs);
                fs.Close();
            }
            MessageBox.Show("Image Saved", "Saved");
        }
        private void LoadData(object sender, RoutedEventArgs e)
        {
            // Fill StrokeCollection from file.
            using (FileStream fs = new FileStream("StrokeData.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokes = new StrokeCollection(fs);
                this.MyInkCanvas.Strokes = strokes;
            }            
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            // Clear all strokes.
            this.MyInkCanvas.Strokes.Clear();
        }
    }
}
