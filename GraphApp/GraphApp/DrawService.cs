using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using GraphApp.Constants;

namespace GraphApp
{
    public class DrawService
    {
        Canvas canvas;
        List<Color> colors;
        Random random;
        public DrawService(Canvas canvas)
        {
            this.canvas = canvas;
            random = new Random();
            this.InitializeColors();
        }
        public void DrawGraph(Graph graph)
        {

        }

        public void DrawVertex(Vertex vertex)
        {
            Ellipse ellipse = new Ellipse()
            {
                Width = DrawConstants.ELLIPSE_SIZE,
                Height = DrawConstants.ELLIPSE_SIZE,
                StrokeThickness = 1,
                Stroke = Brushes.Black,
                Fill = new SolidColorBrush(this.GetOrCreateColor(vertex.Id))
            };
            Canvas.SetLeft(ellipse, vertex.X);
            Canvas.SetTop(ellipse, vertex.Y);

            TextBlock txt = new TextBlock()
            {
                Text = vertex.Id.ToString()
            };
            Canvas.SetLeft(txt, vertex.X + (DrawConstants.ELLIPSE_SIZE/2));
            Canvas.SetTop(txt, vertex.Y + DrawConstants.ELLIPSE_SIZE);

            canvas.Children.Add(ellipse);
            canvas.Children.Add(txt);
        }

        public void DrawLine()
        {

        }

        private Color GetOrCreateColor(int index)
        {
            if (index >= 0 && index < colors.Count)
                return colors[index];
            var color = Color.FromRgb(
                Convert.ToByte(random.Next(150, 255)), Convert.ToByte(random.Next(150, 255)), Convert.ToByte(random.Next(150, 255))
            );
            colors.Add(color);
            return color;
        }

        private void InitializeColors()
        {
            colors = new List<Color>();
            colors.Add(Color.FromRgb(255, 255, 255));
            colors.Add(Color.FromRgb(255, 0, 0));
            colors.Add(Color.FromRgb(0, 0, 255));
            colors.Add(Color.FromRgb(255, 255, 0));
            colors.Add(Color.FromRgb(0, 255, 255));
            colors.Add(Color.FromRgb(255, 0, 255));
            colors.Add(Color.FromRgb(192, 192, 192));
            colors.Add(Color.FromRgb(128, 128, 128));
            colors.Add(Color.FromRgb(128, 0, 0));
            colors.Add(Color.FromRgb(128, 128, 0));
            colors.Add(Color.FromRgb(0, 128, 0));
            colors.Add(Color.FromRgb(128, 0, 128));
            colors.Add(Color.FromRgb(0, 128, 128));
            colors.Add(Color.FromRgb(0, 0, 128));
        }
    }
}
