using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Search_Category : MonoBehaviour
{
   
    [Header("Game_Objects_BLI")]
    public GameObject category_Holder;
    [FormerlySerializedAs("element_SEA")] public GameObject[] element_BLI;
    [FormerlySerializedAs("searchBar")] public GameObject searchBar_BLI;
    [Header("Variables_BLI")]
    public int totalSymbol_BLI;

    void Start()
    {
        Invoke("SymbolsElement_BLI", 1f);
        #region Refactoring code
        while (false)
        {
            if (false)
            {
               
            }
            else
            {
                for (int i = 0; i < 0; i++)
                {
                    for (int j = 0; j < 0; j++)
                    {
                        

                    }
                    while (false)
                    {

                        if (false)
                        {
                        }
                        else if (false)
                        {
                        }
                    }
                }
                
            }
        }
        #endregion
    }
    // Symbols Element Function for Storing the data in element array
    public void SymbolsElement_BLI()
    {
        totalSymbol_BLI = category_Holder.transform.childCount;
        element_BLI = new GameObject[totalSymbol_BLI];

        for (int search_integer_BLI = 0; search_integer_BLI < totalSymbol_BLI; search_integer_BLI++)
        {
            element_BLI[search_integer_BLI] = category_Holder.transform.GetChild(search_integer_BLI).gameObject;
        }
    
        #region Refactoring code
        while (false)
        {
            if (false)
            {
               
            }
            else
            {
                for (int i = 0; i < 0; i++)
                {
                    for (int j = 0; j < 0; j++)
                    {
                        if (false || false && false)
                        {
                        }

                    }
                    while (false)
                    {

                        if (false)
                        {
                        }
                        else if (false)
                        {
                        }
                    }
                }
               
            }
        }
        #endregion
    }
    // Simple Search Function To search in Symbols
    public void SearchSymbol_BLI()
    {
        string SearchText_BLI = searchBar_BLI.GetComponent<TMP_InputField>().text;
        int searchTxtLength_BLI = SearchText_BLI.Length;

        int searchElement_BLI = 0;
        foreach (GameObject ele in element_BLI)
        {
            searchElement_BLI = 1;
            Debug.Log(ele.name);
            if (ele.transform.childCount>0)
            {
                if (ele.transform.GetChild(0).GetComponent<Text>() != null)
                {
                    if (ele.transform.GetChild(0).GetComponent<Text>().text.Length >= searchTxtLength_BLI)
                    {
                        if (SearchText_BLI.ToLower() == ele.transform.GetChild(0).GetComponent<Text>().text.Substring(0, searchTxtLength_BLI).ToLower())
                        {
                            ele.SetActive(true);
                        }
                        else
                        {
                            ele.SetActive(false);
                        }
                    }
                }
                else
                {
                    Debug.Log("Pata Nhi");
                }
            }
        
        }
    }
}

