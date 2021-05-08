using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace GraphApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int CANVAS_MARGIN = 20;

        Graph graph;
        Random randomizer;
        DrawService drawService;
        public MainWindow()
        {
            graph = new Graph();
            randomizer = new Random();
            drawService = new DrawService(drawBoard);
            InitializeComponent();
        }

        private void AddVertex_Click(object sender, SelectionChangedEventArgs e)
        {
            var vertex = graph.AddVertex(
                randomizer.Next(CANVAS_MARGIN, Convert.ToInt32(drawBoard.Width) - CANVAS_MARGIN),
                randomizer.Next(CANVAS_MARGIN, Convert.ToInt32(drawBoard.Height) - CANVAS_MARGIN)
            );
            drawService.DrawPoint(vertex);
        }
    }
}
