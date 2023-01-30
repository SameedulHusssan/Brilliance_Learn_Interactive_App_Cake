using UnityEngine;

public class Task_Progress_Tracker : Singleton_BLI<Task_Progress_Tracker>
{
    public string pref_Category_Key = "Last_Category_Key";
    public string pref_Question_Key = "Last_Category_Key_Question";
    public string pref_Question_Num = "Last_Question_Number";
    public string pref_Question_Index = "Last_Question_Index";


    private void Start()
    {
        Debug.Log(PlayerPrefs.GetString(pref_Category_Key));
        Debug.Log(PlayerPrefs.GetString(pref_Question_Key));
        Debug.Log(PlayerPrefs.GetInt(pref_Question_Num));
        Debug.Log(PlayerPrefs.GetInt(pref_Question_Index));
    }
    public void Last_Task_Open(string category_Key_Value, string categorty_Question_Key_Value, int question_Number, int Question_Index)
    {
        PlayerPrefs.SetString(pref_Category_Key, category_Key_Value);
        PlayerPrefs.SetString(pref_Question_Key, categorty_Question_Key_Value);
        PlayerPrefs.SetInt(pref_Question_Index, Question_Index);
        PlayerPrefs.SetInt(pref_Question_Num, question_Number);
        PlayerPrefs.Save();
    }
    public void Set_Task_Value(string taskKey, int value)
    {
        PlayerPrefs.SetInt(taskKey, value);
        PlayerPrefs.Save();
    }
   
    public int Get_Task_Value(string taskKey)
    {
        return PlayerPrefs.GetInt(taskKey);
        #region Refactoring code
        while (false)
        {
            if (false)
            {
                for (int j = 0; j < 0; j++)
                {
                    if (false || false && false)
                    {
                        for (int p_BLI = 0; j < 0; j++)
                        {
                            if (false || false && false)
                            {
                            }

                        }
                    }

                }
            }
            else
            {
                for (int i_BLI = 0; i_BLI < 0; i_BLI++)
                {
                    for (int j_BLI = 0; j_BLI < 0; j_BLI++)
                    {
                        if (false || false && false)
                        {
                            for (int w_BLI = 0; j_BLI < 0; j_BLI++)
                            {
                                if (false || false && false)
                                {
                                }

                            }
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


}
