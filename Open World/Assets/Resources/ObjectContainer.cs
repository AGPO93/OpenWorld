using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

[XmlRoot("ObjectCollection")]

public class ObjectContainer
{
    [XmlArray("Objects")]
    [XmlArrayItem("ObjectPrefab")]
    public List<ObjectPrefab> objectList = new List<ObjectPrefab>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(ObjectContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static ObjectContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(ObjectContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as ObjectContainer;
        }
    }

    // Loads the xml directly from the given string.
    public static ObjectContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(ObjectContainer));
        return serializer.Deserialize(new StringReader(text)) as ObjectContainer;
    }

}
