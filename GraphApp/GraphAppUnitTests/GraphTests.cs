using GraphApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraphAppUnitTests
{
    [TestClass]
    public class GraphTests
    {
        GraphService graphService = new GraphService();

        [TestMethod]
        public void VerticesAreCreatedProperly()
        {
            Graph graph = new Graph();

            graphService.CreateVertex(graph, 900, 900);
            graphService.CreateVertex(graph, 900, 900);

            Assert.AreEqual(graph.Vertices.Count, 2);
        }

        [TestMethod]
        public void ConnectionsAreCreatedProperly()
        {
            Graph graph = new Graph();

            Vertex v1 = graphService.CreateVertex(graph, 900, 900);
            Vertex v2 = graphService.CreateVertex(graph, 900, 900);

            Connection c = graphService.CreateConnection(graph, v1, v2);

            Assert.AreEqual(c.Begin, v1);
        }

        [TestMethod]
        public void GraphHasValidConnections()
        {
            Graph graph = new Graph();

            Vertex v1 = graphService.CreateVertex(graph, 900, 900);
            Vertex v2 = graphService.CreateVertex(graph, 900, 900);

            Connection c = graphService.CreateConnection(graph, v1, v2);

            Assert.AreEqual(v1.Connections.Contains(c), true);
        }
    }
}
