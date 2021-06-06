using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        List<ColorAlgorithm> algorithmsToSelect;
        bool validationErrorThrown = false;
        Stopwatch watch;

        public MainWindow()
        {
            InitializeComponent();
            graph = new Graph();
            drawService = new DrawService(drawBoard);
            graphService = new GraphService();
            algorithmsToSelect = GetAlgorithms();
            watch = new Stopwatch();

            selectVertex1.ItemsSource = graph.Vertices;
            selectVertex2.ItemsSource = graph.Vertices;
            selectAlgorithm.ItemsSource = algorithmsToSelect;
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
            else if (selectAlgorithm.SelectedItem == null)
            {
                ThrowError("Wybierz algorytm kolorowania");
                return;
            }

            switch ((selectAlgorithm.SelectedItem as ColorAlgorithm).Type)
            {
                case AlgorithmType.BaseAlgorithm:
                    RunAlgorithm(graphService.colorGraphWithBaseAlgorithm);
                    break;

                case AlgorithmType.LFAlgorithm:
                    RunAlgorithm(graphService.colorGraphWithLFAlgorithm);
                    break;

                case AlgorithmType.SLFAlgorithm:
                    RunAlgorithm(graphService.colorGraphWithSLFAlgorithm);
                    break;
            }

        }

        private void RunAlgorithm(Func<Graph, List<int>> graphColorMethod)
        {
            // clear graph colors
            graphService.ClearGraphVerticesColors(graph);

            // run graph color algorithm and count time of work
            watch.Restart();
            var usedColors = graphColorMethod(graph);
            watch.Stop();

            // show algorithm stats
            colorGraphTimeInfo.Content = "Czas wykonania: " + watch.ElapsedMilliseconds.ToString() + " ms";
            colorGraphColorsInfo.Content = "Ilość użytych kolorów: " + usedColors.Distinct().Count().ToString();
            watch.Reset();

            // draw colored graph
            drawBoard.Children.Clear();
            drawService.DrawGraph(graph);
        }

        private List<ColorAlgorithm> GetAlgorithms()
        {
            return new List<ColorAlgorithm>()
            {
                new ColorAlgorithm()
                {
                    Type = AlgorithmType.BaseAlgorithm,
                    DisplayText = "Algorytm podstawowy (zachłanny)"
                },
                new ColorAlgorithm()
                {
                    Type = AlgorithmType.LFAlgorithm,
                    DisplayText = "Algorytm LF (largest first)"
                },
                new ColorAlgorithm()
                {
                    Type = AlgorithmType.SLFAlgorithm,
                    DisplayText = "Algorytm SLF (saturated largest first)"
                }
            };
        }
    }
}
