using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjects : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> trees_list = new List<GameObject>();
    [SerializeField]
    private List<GameObject> terrain_list = new List<GameObject>();
    private GameObject objToInstantiate;
    ObjectContainer xmlContainer = new ObjectContainer();
    ObjectPrefab xmlObject = new ObjectPrefab();

    private void Start()
    {
        //WriteXML();
        xmlContainer = ObjectContainer.Load("Assets/TextFiles/xmlFile.xml"); 

        foreach (ObjectPrefab object_prefab in xmlContainer.objectList)
        {
            createObject(object_prefab.name, object_prefab.position, object_prefab.scale);
        }
    }

    private void createObject(string name, Vector3 position, Vector3 scale)
    {
        objToInstantiate = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;
        objToInstantiate.transform.position = position;
        objToInstantiate.transform.localScale = scale;
    }

    private void WriteXML()
    {
        foreach (GameObject objectPrefab in trees_list)
        {
            xmlObject.name = objectPrefab.name;
            xmlObject.position = objectPrefab.transform.position;
            xmlObject.rotation = objectPrefab.transform.rotation.eulerAngles;
            xmlObject.scale = objectPrefab.transform.localScale;

            xmlContainer.objectList.Add(xmlObject);
            xmlContainer.Save("Assets/TextFiles/xmlFile.xml");
            xmlContainer = ObjectContainer.Load("Assets/TextFiles/xmlFile.xml");
        }
    }
}
