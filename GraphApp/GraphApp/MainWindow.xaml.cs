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
    /// Logical interaction with MainWindow class
    /// </summary>
    public partial class MainWindow : Window
    {

        Graph graph;
        DrawService drawService;
        GraphService graphService;
        bool validationErrorThrown = false;
        public MainWindow()
        {
            InitializeComponent();
            graph = new Graph();
            drawService = new DrawService(drawBoard);
            graphService = new GraphService();
            InitializeVerticesLists();
        }

        private void AddVertex_Click(object sender, RoutedEventArgs e)
        {
            ClearError();

            var vertex = graphService.CreateVertex(
                graph, Convert.ToInt32(drawBoard.Width), Convert.ToInt32(drawBoard.Height)
            );
            drawService.DrawVertex(vertex);
        }

        private void AddConnection_Click(object sender, RoutedEventArgs e)
        {
            ClearError();

            if (selectVertex1.SelectedItem == null || selectVertex2.SelectedItem == null)
            {
                ThrowError("Proszę wybrać wierzchołek");
            } 
            else if (selectVertex1.SelectedItem == selectVertex2.SelectedItem)
            {
                ThrowError("Wybrano nieprawidłowy wierzchołek");
            }
            else if ((selectVertex1.SelectedItem as Vertex).ConnectionWithVertexExists(selectVertex2.SelectedItem as Vertex))
            {
                ThrowError("Wybrane połącze nie już istnieje");
            }
            else
            {
                var connection = graphService.CreateConnection(
                    graph,
                    selectVertex1.SelectedItem as Vertex,
                    selectVertex2.SelectedItem as Vertex
                );

                drawService.DrawConnection(connection);
            }
        }

        private void InitializeVerticesLists()
        {
            selectVertex1.ItemsSource = graph.Vertices;
            selectVertex2.ItemsSource = graph.Vertices;
        }

        private void ThrowError(string message)
        {
            validationErrorThrown = true;
            errorBlock.Text = message;
        }

        private void ClearError()
        {
            if(validationErrorThrown)
            {
                validationErrorThrown = false;
                errorBlock.Text = "";
            }
        }

        private void DeleteGraph_Click(object sender, RoutedEventArgs e)
        {
            ClearError();
            graph.Clear();
            drawBoard.Children.Clear();
        }

        private void ColorGraph_Click(object sender, RoutedEventArgs e)
        {
            ClearError();
            if (graph.Vertices.Count == 0)
            {
                ThrowError("Graf jest pusty");
                return;
            }

            // clear graph colors
            graphService.ClearGraphVerticesColors(graph);

            // run graph color algorithm and count time of work
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var usedColors = graphService.colorGraphWithBaseAlgorithm(graph);
            watch.Stop();

            colorGraphTimeInfo.Content = "Czas wykonania: " + watch.ElapsedMilliseconds.ToString() + " ms";
            colorGraphColorsInfo.Content = "Ilość użytych kolorów: " + usedColors.Distinct().Count().ToString();

            // draw colored graph
            drawBoard.Children.Clear();
            drawService.DrawGraph(graph);
        }
    }
}
