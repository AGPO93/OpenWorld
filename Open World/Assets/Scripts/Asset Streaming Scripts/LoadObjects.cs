using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjects : MonoBehaviour
{
    /* Only for XML file writing. 
     * private ObjectPrefab xmlObject = new ObjectPrefab();*/

    private ObjectContainer xmlContainer = new ObjectContainer();

    #region Area instances
    Area area1;
    Area area2;
    Area area3;
    Area area4;
    Area area5;
    Area area6;
    Area area7;
    Area area8;
    Area area9;
    #endregion


    private void Awake()
    {
        //area1.path = "Assets/TextFiles/Area1.xml";
        //area2.path = "Assets/TextFiles/Area2.xml";
        //area3.path = "Assets/TextFiles/Area3.xml";
        //area4.path = "Assets/TextFiles/Area4.xml";
        //area5.path = "Assets/TextFiles/Area5.xml";
        //area6.path = "Assets/TextFiles/Area6.xml";
        //area7.path = "Assets/TextFiles/Area7.xml";
        //area8.path = "Assets/TextFiles/Area8.xml";
        //area9.path = "Assets/TextFiles/Area9.xml";
    }

    private void CreateObject(string name, Vector3 position, Vector3 scale, List<GameObject> areaList)
    {
        GameObject _object;

        _object = Instantiate(Resources.Load(name, typeof(GameObject))) as GameObject;
        _object.transform.position = position;
        _object.transform.localScale = scale;

        areaList.Add(_object);
    }

    private void LoadXMLContainer(string path, List<GameObject> _areaList)
    {
        xmlContainer = ObjectContainer.Load(path);

        foreach (ObjectPrefab object_prefab in xmlContainer.objectList)
        {
            CreateObject(object_prefab.name, object_prefab.position, object_prefab.scale, _areaList);
        }
    }

    public void UpdatePlayerArea(int area)
    {
        // Int area gets updated based on player position.
        // Load and unload areas accordingly.
        // Will do loading and creation of assets, so shouldn't be called in Update.

      /* switch(area)
        {
            case 1:
                // Load: 1, 2, 4, 5.
                //LoadXMLContainer("Assets/TextFiles/Area1.xml", _area1.objectsList);
                //LoadXMLContainer("Assets/TextFiles/Area2.xml", _area1.objectsList);
                //LoadXMLContainer("Assets/TextFiles/Area4.xml", _area1.objectsList);
                //LoadXMLContainer("Assets/TextFiles/Area5.xml", _area1.objectsList);

                //// Unload: 3, 6, 7, 8, 9.
                //foreach (GameObject obj in area_3)
                //    Destroy(obj); 
                //foreach (GameObject obj in area_6)
                //    Destroy(obj);
                //foreach (GameObject obj in area_7)
                //    Destroy(obj);
                //foreach (GameObject obj in area_8)
                //    Destroy(obj);
                //foreach (GameObject obj in area_9)
                //    Destroy(obj);

                break;

            case 2:
                // Load: 1, 2, 3, 4, 5, 6.
                LoadXMLContainer("Assets/TextFiles/Area1.xml", _area2.objectsList);
                LoadXMLContainer("Assets/TextFiles/Area2.xml", _area2.objectsList);
                LoadXMLContainer("Assets/TextFiles/Area3.xml", _area2.objectsList);
                LoadXMLContainer("Assets/TextFiles/Area4.xml", _area2.objectsList);
                LoadXMLContainer("Assets/TextFiles/Area5.xml", _area2.objectsList);
                LoadXMLContainer("Assets/TextFiles/Area6.xml", _area2.objectsList);

                // Unload: 7, 8, 9.
                foreach (GameObject obj in area_7)
                    Destroy(obj);
                foreach (GameObject obj in area_8)
                    Destroy(obj);
                foreach (GameObject obj in area_9)
                    Destroy(obj);

                break;

            case 3:
                // Load: 2, 3, 5, 6.
                LoadXMLContainer("Assets/TextFiles/Area2.xml", area_3);
                LoadXMLContainer("Assets/TextFiles/Area3.xml", area_3);
                LoadXMLContainer("Assets/TextFiles/Area5.xml", area_3);
                LoadXMLContainer("Assets/TextFiles/Area6.xml", area_3);

                // Unload: 1, 4, 7, 8, 9.
                foreach (GameObject obj in area_1) 
                    Destroy(obj);
                foreach (GameObject obj in area_4)
                    Destroy(obj);
                foreach (GameObject obj in area_7)
                    Destroy(obj);
                foreach (GameObject obj in area_8)
                    Destroy(obj);
                foreach (GameObject obj in area_9)
                    Destroy(obj);

                break;

            case 4:
                // Load: 1, 2, 4, 5, 7, 8.
                LoadXMLContainer("Assets/TextFiles/Area1.xml", area_4);
                LoadXMLContainer("Assets/TextFiles/Area2.xml", area_4);
                LoadXMLContainer("Assets/TextFiles/Area4.xml", area_4);
                LoadXMLContainer("Assets/TextFiles/Area5.xml", area_4);
                LoadXMLContainer("Assets/TextFiles/Area7.xml", area_4);
                LoadXMLContainer("Assets/TextFiles/Area8.xml", area_4);

                // Unload: 3, 6, 9.
                foreach (GameObject obj in area_3)
                    Destroy(obj);
                foreach (GameObject obj in area_6)
                    Destroy(obj);
                foreach (GameObject obj in area_9)
                    Destroy(obj);

                break;

            case 5:
                // Load: all.
                LoadXMLContainer("Assets/TextFiles/Area1.xml", area_5);
                LoadXMLContainer("Assets/TextFiles/Area2.xml", area_5);
                LoadXMLContainer("Assets/TextFiles/Area3.xml", area_5);
                LoadXMLContainer("Assets/TextFiles/Area4.xml", area_5);
                LoadXMLContainer("Assets/TextFiles/Area5.xml", area_5);
                LoadXMLContainer("Assets/TextFiles/Area6.xml", area_5);
                LoadXMLContainer("Assets/TextFiles/Area7.xml", area_5);
                LoadXMLContainer("Assets/TextFiles/Area8.xml", area_5);
                LoadXMLContainer("Assets/TextFiles/Area9.xml", area_5);

                // Unload: none.
                break;

            case 6:
                // Load: 2, 3, 5, 6, 8, 9.
                LoadXMLContainer("Assets/TextFiles/Area2.xml", area_6);
                LoadXMLContainer("Assets/TextFiles/Area3.xml", area_6);
                LoadXMLContainer("Assets/TextFiles/Area5.xml", area_6);
                LoadXMLContainer("Assets/TextFiles/Area6.xml", area_6);
                LoadXMLContainer("Assets/TextFiles/Area8.xml", area_6);
                LoadXMLContainer("Assets/TextFiles/Area9.xml", area_6);

                // Unload: 1, 4, 7.
                foreach (GameObject obj in area_1)
                    Destroy(obj);
                foreach (GameObject obj in area_4)
                    Destroy(obj);
                foreach (GameObject obj in area_7)
                    Destroy(obj);

                break;

            case 7:
                // Load: 4, 5, 7, 8.
                LoadXMLContainer("Assets/TextFiles/Area4.xml", area_7);
                LoadXMLContainer("Assets/TextFiles/Area5.xml", area_7);
                LoadXMLContainer("Assets/TextFiles/Area7.xml", area_7);
                LoadXMLContainer("Assets/TextFiles/Area8.xml", area_7);

                // Unload: 1, 2, 3, 6, 9.
                foreach (GameObject obj in area_1)
                    Destroy(obj);
                foreach (GameObject obj in area_2)
                    Destroy(obj);
                foreach (GameObject obj in area_3)
                    Destroy(obj);
                foreach (GameObject obj in area_6)
                    Destroy(obj);
                foreach (GameObject obj in area_9)
                    Destroy(obj);

                break;

            case 8:
                // Load: 4, 5, 6, 7, 8, 9.
                LoadXMLContainer("Assets/TextFiles/Area4.xml", area_8);
                LoadXMLContainer("Assets/TextFiles/Area5.xml", area_8);
                LoadXMLContainer("Assets/TextFiles/Area6.xml", area_8);
                LoadXMLContainer("Assets/TextFiles/Area7.xml", area_8);
                LoadXMLContainer("Assets/TextFiles/Area8.xml", area_8);
                LoadXMLContainer("Assets/TextFiles/Area9.xml", area_8);

                // Unload: 1, 2, 3.
                foreach (GameObject obj in area_1)
                    Destroy(obj);
                foreach (GameObject obj in area_2)
                    Destroy(obj);
                foreach (GameObject obj in area_3)
                    Destroy(obj);

                break;

            case 9:
                // Load: 5, 6, 8, 9.
                LoadXMLContainer("Assets/TextFiles/Area5.xml", area_9);
                LoadXMLContainer("Assets/TextFiles/Area6.xml", area_9);
                LoadXMLContainer("Assets/TextFiles/Area7.xml", area_9);
                LoadXMLContainer("Assets/TextFiles/Area8.xml", area_9);
                LoadXMLContainer("Assets/TextFiles/Area9.xml", area_9);

                // Unload: 1, 2, 3, 4, 7.
                foreach (GameObject obj in area_1)
                    Destroy(obj);
                foreach (GameObject obj in area_2)
                    Destroy(obj);
                foreach (GameObject obj in area_3)
                    Destroy(obj);
                foreach (GameObject obj in area_4)
                    Destroy(obj);
                foreach (GameObject obj in area_7)
                    Destroy(obj);

                break;
        }
    }

    private void WriteXML()
    {
        //foreach (GameObject objectPrefab in Area_9)
        //{
        //    xmlObject.name = objectPrefab.name;
        //    xmlObject.position = objectPrefab.transform.position;
        //    xmlObject.rotation = objectPrefab.transform.rotation.eulerAngles;
        //    xmlObject.scale = objectPrefab.transform.localScale;

        //    xmlContainer.objectList.Add(xmlObject);
        //    xmlContainer.Save("Assets/TextFiles/Area9.xml");
        //    xmlContainer = ObjectContainer.Load("Assets/TextFiles/Area9.xml");
        //}
        */
    }
    
}
