using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjects : MonoBehaviour
{
    public GameObject obj; // Need to find a smarter way to assign the prefab to be loaded.
    private GameObject objToInstantiate;
    ObjectContainer container = new ObjectContainer();
    ObjectPrefab prefab = new ObjectPrefab();

    void Start()
    {
        prefab.name = obj.name;
        prefab.position = obj.transform.position;
        prefab.rotation = obj.transform.rotation.eulerAngles;
        prefab.scale = obj.transform.localScale;

        container.objectList.Add(prefab);
        container.Save("Assets/TextFiles/xmlFile.xml");
        container = ObjectContainer.Load("Assets/TextFiles/xmlFile.xml");

        foreach (ObjectPrefab objectPrefab in container.objectList)
        {
            createObject(objectPrefab.name, objectPrefab.position, objectPrefab.scale);
        }
        // Need to create the objects during run time, perhaps based on player position.
    }

    void createObject(string name, Vector3 position, Vector3 scale)
    {
        objToInstantiate = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;
        objToInstantiate.transform.position = position;
        objToInstantiate.transform.localScale = scale;
    }
}
