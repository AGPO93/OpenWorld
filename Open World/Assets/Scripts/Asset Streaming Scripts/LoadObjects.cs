using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjects : MonoBehaviour
{
    public List<GameObject> assetsToLoad = new List<GameObject>();
    public GameObject prefab; 
    private GameObject objToInstantiate;
    ObjectContainer xmlContainer = new ObjectContainer();
    ObjectPrefab xmlObject = new ObjectPrefab();

    void Start()
    {
        //xmlObject.name = prefab.name;
        //xmlObject.position = prefab.transform.position;
        //xmlObject.rotation = prefab.transform.rotation.eulerAngles;
        //xmlObject.scale = prefab.transform.localScale;

        //xmlContainer.objectList.Add(xmlObject);
        //xmlContainer.Save("Assets/TextFiles/xmlFile.xml");
        xmlContainer = ObjectContainer.Load("Assets/TextFiles/xmlFile.xml"); // must load the file first before the objects in the container can be created.

        // This writes the object in scene to the xml file
        //foreach (GameObject objectPrefab in assetsToLoad)
        //{
        //    xmlObject.name = objectPrefab.name;
        //    xmlObject.position = objectPrefab.transform.position;
        //    xmlObject.rotation = objectPrefab.transform.rotation.eulerAngles;
        //    xmlObject.scale = objectPrefab.transform.localScale;

        //    xmlContainer.objectList.Add(xmlObject);
        //    xmlContainer.Save("Assets/TextFiles/xmlFile.xml");
        //    xmlContainer = ObjectContainer.Load("Assets/TextFiles/xmlFile.xml");
        //}

        foreach (ObjectPrefab object_prefab in xmlContainer.objectList)
        {
            createObject(object_prefab.name, object_prefab.position, object_prefab.scale);
        }
        // Need to create the objects during run time, perhaps based on player position.
    }

    void createObject(string name, Vector3 position, Vector3 scale) // Must separate the 2 processes. Loading the assets must go in a different script.
    {
        objToInstantiate = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;
        objToInstantiate.transform.position = position;
        objToInstantiate.transform.localScale = scale;
    }
}
