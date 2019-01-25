using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadObjects : MonoBehaviour
{
    // Only for XML file writing. 
    // private ObjectPrefab xmlObject = new ObjectPrefab();

    public void UpdatePlayerArea(GameObject area)
    {
        area.GetComponent<Area>().PlayerInNode();
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
    }
    
}
