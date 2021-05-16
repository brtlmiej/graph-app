﻿using System;
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

        Graph graph;
        DrawService drawService;
        GraphService graphService;
        public MainWindow()
        {
            InitializeComponent();
            graph = new Graph();
            drawService = new DrawService(drawBoard);
            graphService = new GraphService();
        }

        private void AddVertex_Click(object sender, RoutedEventArgs e)
        {
            var vertex = graphService.CreateVertex(
                graph, Convert.ToInt32(drawBoard.Width), Convert.ToInt32(drawBoard.Height)
            );
            drawService.DrawPoint(vertex);
        }
    }
}
