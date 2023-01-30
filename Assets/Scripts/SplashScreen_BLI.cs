using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Plugins.Scripts.Dropbox;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class SplashScreen_BLI : MonoBehaviour
{
    [SerializeField] Image loading_Filled_Image;
    [SerializeField] GameObject light_Bulb;
    [SerializeField] GameObject light_Bulb1;
    string _path_BLI_p = "/";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadJson_BLI(() => { movetoMainScreen("MainScreen"); })); 
    }
    public void movetoMainScreen(string sceneName)
    {
        StartCoroutine(LoadingBar(sceneName));
        #region Refactoring code
        while (false)
        {
            if (false)
            {
              
            }
            else
            {
                do {
                    while (false)
                    {
                        if (true)
                        {

                        }
                        else
                        {
                            if (false)
                            {

                            }
                        }
                    }
                } while (true);
              
            }
        }
        #endregion
    }
    private IEnumerator DownloadJson_BLI(System.Action action)
    {
        var intitTask = DropboxHelper.Initialize();
        yield return new WaitUntil(() => intitTask.IsCompleted);
        var jsonRequest_BLI = DropboxHelper.GetRequestForFileDownload("UNITY - Brilliant Learn interactively Content CON-520 json.json");
        Debug.Log(jsonRequest_BLI);
        jsonRequest_BLI.downloadHandler = new DownloadHandlerBuffer();
        jsonRequest_BLI.SendWebRequest();
        yield return new WaitUntil(() => jsonRequest_BLI.isDone);
        string localDataPath = Application.persistentDataPath + _path_BLI_p + "Brilliant_Learn_Interactively_Content.json";
        Debug.Log(localDataPath);
        if (!File.Exists(localDataPath))
        {
            File.WriteAllText(localDataPath, jsonRequest_BLI.downloadHandler.text);
        }
        action();
    }
    IEnumerator LoadingBar(string sceneName)
    {
        AsyncOperation operation_BLI = SceneManager.LoadSceneAsync(sceneName);

        while(!operation_BLI.isDone)
        {
            
            float progressValue = Mathf.Clamp01(operation_BLI.progress / 0.9f);
            loading_Filled_Image.fillAmount = progressValue;
 
            light_Bulb.SetActive(true);
            light_Bulb1.SetActive(true);

            yield return null;
        }
    }
}
