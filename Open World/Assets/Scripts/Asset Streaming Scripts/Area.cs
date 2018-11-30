using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> objectsList;
    public List<GameObject> connectedNodes;
    public bool loaded;
    //public string path;

    private ObjectContainer xmlContainer = new ObjectContainer();

    private void LoadXMLContainer(string path, List<GameObject> _areaList)
    {
        xmlContainer = ObjectContainer.Load(path);

        foreach (ObjectPrefab object_prefab in xmlContainer.objectList)
        {
            CreateObject(object_prefab.name, object_prefab.position, object_prefab.rotation, object_prefab.scale, _areaList);
        }
    }

    private void CreateObject(string name, Vector3 position, Vector3 scale, Vector3 rotation, List<GameObject> areaList)
    {
        GameObject _object;

        _object = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;
        _object.transform.position = position;
        _object.transform.eulerAngles = rotation;
        _object.transform.localScale = scale;

        areaList.Add(_object);
    }


    public void PlayerInNode()
    {
        LoadArea();
        LoadAdjacent();
    }

    public void LoadArea()
    {
        //the area the players in
        Debug.Log("Assets/TextFiles/" + gameObject.name + ".xml");
        LoadXMLContainer("Assets/TextFiles/" + gameObject.name + ".xml", objectsList);
    }

    private void LoadAdjacent()
    {
        foreach (GameObject node in connectedNodes)
        {
            node.GetComponent<Area>().LoadArea();
        }
    }
}
