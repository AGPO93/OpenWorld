using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StreamingManager : MonoBehaviour
{

    void Start()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        //print("Streaming Assets Path: " + Application.streamingAssetsPath);
        FileInfo[] allFiles = directoryInfo.GetFiles("*.*");

        foreach (FileInfo file in allFiles)
        {
            if (file.Name.Contains("player1"))
            {
                // Loads all the files and then calls function.
                //StartCoroutine("InstantiateObject", file);
            }
        }
    }

    IEnumerator InstantiateObject(FileInfo file)
    {
        //1
        // Make sure theres no meta files.
        if (file.Name.Contains("meta"))
        {
            yield break;
        }
        //2
        else
        {
            string fileWithoutExtension = Path.GetFileNameWithoutExtension(file.ToString());
            string[] fileNameData = fileWithoutExtension.Split(" "[0]);
            //3
            string tempPlayerName = "";
            int i = 0;
            foreach (string stringFromFileName in fileNameData)
            {
                if (i != 0)
                {
                    tempPlayerName = tempPlayerName + stringFromFileName + " ";
                }
                i++;
            }


            //5
            //playerAvatar.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
            //playerName.text = tempPlayerName;
            //
        }
    }

    void LoadFile()
    {

    }
}
