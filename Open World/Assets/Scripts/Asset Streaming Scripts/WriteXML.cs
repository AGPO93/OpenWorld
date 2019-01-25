using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteXML : MonoBehaviour
{
    public List<GameObject> assetsToLoad = new List<GameObject>();
    ObjectContainer xmlContainer = new ObjectContainer();
    ObjectPrefab xmlObject = new ObjectPrefab();

    private void Start()
    {
        //This writes the object in scene to the xml file
        foreach (GameObject objectPrefab in assetsToLoad)
        {
            xmlObject.name = objectPrefab.name;
            xmlObject.position = objectPrefab.transform.position;
            xmlObject.rotation = objectPrefab.transform.rotation.eulerAngles;
            xmlObject.scale = objectPrefab.transform.localScale;

            xmlContainer.objectList.Add(xmlObject);
            xmlContainer.Save("Assets/TextFiles/xmlFile.xml");
        }

        xmlContainer = ObjectContainer.Load("Assets/TextFiles/xmlFile.xml");
    }
}
