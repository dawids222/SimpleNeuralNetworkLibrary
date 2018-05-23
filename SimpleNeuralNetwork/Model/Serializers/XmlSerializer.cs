using NeuralNetwork.Helpers;
using System.IO;

public class XmlSerializer : ISerializer
{
    public HelperNetwork Deserialize(string filename)
    {
        using (var reader = new StreamReader(filename))
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(HelperNetwork));
            return serializer.Deserialize(reader) as HelperNetwork;
        }
    }

    public void Serialize(HelperNetwork network, string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(network.GetType());
            serializer.Serialize(writer, network);
        }
    }
}
