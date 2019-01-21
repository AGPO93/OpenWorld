using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIAreaManager : MonoBehaviour
{
    public int currentArea;
    //public List<GameObject> areaList = new List<GameObject>();

    void Start()
    {
       // areaList = GameObject.FindGameObjectsWithTag("Area").ToList();
    }

    public void updateArea(int new_area)
    {
        //for (int i = 0; i < areaList.Count; i++)
        //{
        //    if (areaList[i].GetComponent<AreaCollider>().AreaID == currentArea)
        //    {
        //        areaList[i].GetComponent<Area>().objectsList.Remove(gameObject);

        //        Debug.Log("area " + areaList[i].GetComponent<AreaCollider>().AreaID);
        //    }
        //    if (areaList[i].GetComponent<AreaCollider>().AreaID == new_area)
        //    {
        //        areaList[i].GetComponent<Area>().objectsList.Add(gameObject);
        //    }
        //}
        currentArea = new_area;
    }
}
