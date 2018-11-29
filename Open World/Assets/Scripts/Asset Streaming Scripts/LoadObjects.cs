using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjects : MonoBehaviour
{
    #region Area Lists
    [SerializeField]
    private List<GameObject> Area_1 = new List<GameObject>();
    [SerializeField]
    private List<GameObject> Area_2 = new List<GameObject>();
    [SerializeField]
    private List<GameObject> Area_3 = new List<GameObject>();
    [SerializeField]
    private List<GameObject> Area_4 = new List<GameObject>();
    [SerializeField]
    private List<GameObject> Area_5 = new List<GameObject>();
    [SerializeField]
    private List<GameObject> Area_6 = new List<GameObject>();
    [SerializeField]
    private List<GameObject> Area_7 = new List<GameObject>();
    [SerializeField]
    private List<GameObject> Area_8 = new List<GameObject>();
    [SerializeField]
    private List<GameObject> Area_9 = new List<GameObject>();
    #endregion

    ObjectContainer xmlContainer = new ObjectContainer();
    ObjectPrefab xmlObject = new ObjectPrefab();

    private void Start()
    {
        //WriteXML();

        LoadContainer("Assets/TextFiles/Area1.xml");
        LoadContainer("Assets/TextFiles/Area2.xml");
        LoadContainer("Assets/TextFiles/Area3.xml");
        LoadContainer("Assets/TextFiles/Area4.xml");
        LoadContainer("Assets/TextFiles/Area5.xml");
        LoadContainer("Assets/TextFiles/Area6.xml");
        LoadContainer("Assets/TextFiles/Area7.xml");
        LoadContainer("Assets/TextFiles/Area8.xml");
        LoadContainer("Assets/TextFiles/Area9.xml");
    }

    private void CreateObject(string name, Vector3 position, Vector3 scale)
    {
        GameObject _object;

        _object = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;
        _object.transform.position = position;
        _object.transform.localScale = scale;
    }

    private void WriteXML()
    {
        foreach (GameObject objectPrefab in Area_9)
        {
            xmlObject.name = objectPrefab.name;
            xmlObject.position = objectPrefab.transform.position;
            xmlObject.rotation = objectPrefab.transform.rotation.eulerAngles;
            xmlObject.scale = objectPrefab.transform.localScale;

            xmlContainer.objectList.Add(xmlObject);
            xmlContainer.Save("Assets/TextFiles/Area9.xml");
            xmlContainer = ObjectContainer.Load("Assets/TextFiles/Area9.xml");
        }
    }

    private void LoadContainer(string path)
    {
        xmlContainer = ObjectContainer.Load(path);

        foreach (ObjectPrefab object_prefab in xmlContainer.objectList)
        {
            CreateObject(object_prefab.name, object_prefab.position, object_prefab.scale);
        }
    }
}
