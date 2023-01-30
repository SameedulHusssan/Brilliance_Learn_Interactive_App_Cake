using System.Collections;
using Plugins.Scripts.Dropbox;
using UnityEngine.Networking;
using UnityEngine;
using System.IO;

public class BIDownloadData : Singleton_BLI<BIDownloadData>
{
    // Start is called before the first frame update
    void Start()
    {
      //  string localDataPath = Application.persistentDataPath + "/" + "Brilliant_Learn_Interactively_Content.json";
    
    }

    /*private IEnumerator DownloadJson()
    {
        var intitTask = DropboxHelper.Initialize();
        yield return new WaitUntil(() => intitTask.IsCompleted);
        var jsonRequest_BLI = DropboxHelper.GetRequestForFileDownload("UNITY - Brilliant Learn interactively Content.json");
        Debug.Log(jsonRequest_BLI);
        jsonRequest_BLI.downloadHandler = new DownloadHandlerBuffer();
        jsonRequest_BLI.SendWebRequest();
        yield return new WaitUntil(() => jsonRequest_BLI.isDone);
        string localDataPath = Application.persistentDataPath + "/" + "Brilliant_Learn_Interactively_Content.json";
        Debug.Log(localDataPath);
        if (!File.Exists(localDataPath))
        {
            Debug.Log("local data Path" + localDataPath);
            File.WriteAllText(localDataPath, jsonRequest_BLI.downloadHandler.text);
            Debug.Log("Before Json converter");
           
        }

    }*/
}
