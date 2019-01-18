using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    //[HideInInspector]
    public List<GameObject> objectsList;
    public List<GameObject> connectedNodes;
    public List<GameObject> unloadNodes;
    public bool loaded = true;

    private ObjectContainer xmlContainer = new ObjectContainer();

    private void LoadXMLContainer(string path, List<GameObject> _areaList)
    {
        xmlContainer = ObjectContainer.Load(path);

        foreach (ObjectPrefab object_prefab in xmlContainer.objectList)
        {
            CreateObject(object_prefab.name, object_prefab.position, object_prefab.scale, object_prefab.rotation, _areaList);
        }
    }

    private void CreateObject(string name, Vector3 position, Vector3 scale, Vector3 rotation, List<GameObject> areaList)
    {
        GameObject _object;

        _object = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;
        _object.transform.position = position;
        _object.transform.localScale = scale;
        _object.transform.eulerAngles = rotation;

        areaList.Add(_object);
    }


    public void PlayerInNode()
    {
        LoadArea();
        LoadAdjacent();
    }

    public void LoadArea()
    {
        if (!loaded)
        {
            LoadXMLContainer("Assets/TextFiles/" + gameObject.name + ".xml", objectsList);
            loaded = true;
        }
    }

    private void LoadAdjacent()
    {
        foreach (GameObject node in connectedNodes)
        {
            node.GetComponent<Area>().LoadArea();
        }

        foreach (GameObject node in unloadNodes)
        {
            foreach(GameObject objs in node.GetComponent<Area>().objectsList)
            {
                Destroy(objs);
            }
            node.GetComponent<Area>().loaded = false;
        }
    }
}
