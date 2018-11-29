using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class ObjectPrefab
{
    [XmlAttribute("name")]
    public string name;

    //[XmlAttribute("position")]
    public Vector3 position;

   // [XmlAttribute("rotation")]
    public Vector3 rotation;

    //[XmlAttribute("scale")]
    public Vector3 scale;
}


