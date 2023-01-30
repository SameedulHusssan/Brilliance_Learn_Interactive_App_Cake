using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using Plugins.Scripts.Dropbox;
using UnityEngine.Networking;

public class CoursesCategory : Singleton_BLI<CoursesCategory>
{
    string path_BIA = "/";
    public Transform parent_Of_Courses;
    public GameObject prefabs_Course_Category;
    public GameObject prefabs_Course_Card;
    private GameObject category_Prefab_Holder;
    private GameObject course_Prefabs_Holder;
    public GameObject resume_Course_Object;
    public Button submit_Quiz_Button;
    public Category_Section all_Content_Data = new Category_Section();
    [Header("Quiz_Game_GameObjects")]
    public Transform parent_Of_Quiz_Choices;
    public GameObject question_Key_Text;
    public GameObject wrong_Answer1_Text;
    public GameObject wrong_Answer2_Text;
    public GameObject wrong_Answer3_Text;
    public GameObject right_Answer_Text;
    public GameObject explanation_Answer_Text;
    public GameObject question_Image;
    public GameObject question_Explanation_Image;
    public ToggleGroup toggle_Group;
    public GameObject _ProgressBar_BLI;
    [Header("Variables_For_Quiz_Show")]
     int question_Number_value = 0;
     string category_Key_Variable;
     string question_task_Variable;
    string question_Image_Variable;
    string explanation_Image_Variale;
     int task_Key_Variable;
    [Header("Sprites_Of_Card")]
    public Sprite physics_Card_Sprite;
    public Sprite logic_Card_Sprite;
    // Start is called before the first frame update
    void Start()
    {
        string localDataPath = Application.persistentDataPath + path_BIA + "Brilliant_Learn_Interactively_Content.json";
       all_Content_Data = JsonConvert.DeserializeObject<Category_Section>(File.ReadAllText(localDataPath));
        Courses_GameObject();
        Invoke("Resume_Course_Card", 1f);
       // Resume_Course_Card();
    }
    private void Update()
    {
        submit_Quiz_Button.interactable = toggle_Group.AnyTogglesOn();
        if (PlayerPrefs.GetString("Last_Category_Key") == "")
        {
            resume_Course_Object.GetComponentInChildren<Button>().interactable = false;
        } 
    }
    public void Resume_Course_Card()
    {
        resume_Course_Object.transform.GetChild(2).GetComponent<Text>().text = PlayerPrefs.GetString(Task_Progress_Tracker.Instance.pref_Question_Key);
        resume_Course_Object.GetComponentInChildren<Slider>().value = Task_Progress_Tracker.Instance.Get_Task_Value(PlayerPrefs.GetString("Last_Category_Key_Question"));

    }
    public void Courses_GameObject()
    {
        foreach (var category in all_Content_Data.allData)
        {
            category_Prefab_Holder = Instantiate(prefabs_Course_Category, parent_Of_Courses);
            category_Prefab_Holder.transform.GetChild(0).GetComponent<Text>().text = category.Key;
            if (category.Key == "Math")
            category_Prefab_Holder.transform.GetChild(0).GetComponent<Text>().text = "Mathematics";
            Transform go_Course_Subject = category_Prefab_Holder.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0);
             List<string> task_Keys =new List <string>(all_Content_Data.allData[category.Key].Keys);
            switch (category.Key)
            {
                case "Math":
                    for (int i=0; i<all_Content_Data.allData[category.Key].Count; i++)
                    {
                        int index_Of_Mathematics = i;
                        course_Prefabs_Holder = Instantiate(prefabs_Course_Card, go_Course_Subject);
                        course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Text>().text = (question_Number_value+1).ToString();
                        course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<Text>().text = ("of " + all_Content_Data.allData[category.Key][task_Keys[index_Of_Mathematics]].Length).ToString();
                        course_Prefabs_Holder.transform.GetChild(3).gameObject.GetComponent<Text>().text = task_Keys[index_Of_Mathematics];
                        course_Prefabs_Holder.transform.GetChild(5).gameObject.GetComponent<Slider>().value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Mathematics]);
                        course_Prefabs_Holder.GetComponent<Button>().onClick.AddListener(() => {
                            if (Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Mathematics]) >= 5)
                            {
                                question_Number_value = 0;
                            }
                            else
                            {
                                question_Number_value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Mathematics]);
                            }
                        category_Key_Variable = category.Key;
                        question_task_Variable = task_Keys[index_Of_Mathematics];
                        task_Key_Variable = index_Of_Mathematics;
                        Quiz_Show(category.Key, task_Keys[index_Of_Mathematics], question_Number_value, index_Of_Mathematics);
                        GameManager_BLI.Instance.Quiz_Task_Screen();
                        update_Progress_Bar();
                        });
                    }
                    break;
                case "Logic":
                    for (int i = 0; i < all_Content_Data.allData[category.Key].Count; i++)
                    {
                        int index_Of_Logic = i;
                        course_Prefabs_Holder = Instantiate(prefabs_Course_Card, go_Course_Subject);
                        course_Prefabs_Holder.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = logic_Card_Sprite; course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Text>().text = (question_Number_value + 1).ToString();
                        course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<Text>().text = ("of " + all_Content_Data.allData[category.Key][task_Keys[index_Of_Logic]].Length).ToString();
                        course_Prefabs_Holder.transform.GetChild(3).gameObject.GetComponent<Text>().text = task_Keys[index_Of_Logic];
                        course_Prefabs_Holder.transform.GetChild(5).gameObject.GetComponent<Slider>().value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Logic]);
                        course_Prefabs_Holder.GetComponent<Button>().onClick.AddListener(() => {
                         if (Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Logic]) >= 5)
                         {
                                question_Number_value = 0;
                          }
                          else
                          {
                                question_Number_value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Logic]);
                            }
                            category_Key_Variable = category.Key;
                        question_task_Variable = task_Keys[index_Of_Logic];
                        task_Key_Variable = index_Of_Logic;
                        question_Number_value = 0;
                        Quiz_Show(category.Key, task_Keys[index_Of_Logic],question_Number_value, index_Of_Logic);
                        GameManager_BLI.Instance.Quiz_Task_Screen();
                            update_Progress_Bar();
                        });
                    }
                    break;
                case "Physic":
                    for (int i = 0; i < all_Content_Data.allData[category.Key].Count; i++)
                    {
                        int index_Of_Physic = i;
                        course_Prefabs_Holder = Instantiate(prefabs_Course_Card, go_Course_Subject);
                        course_Prefabs_Holder.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = physics_Card_Sprite; course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Text>().text = (question_Number_value + 1).ToString();
                        course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<Text>().text = ("of " + all_Content_Data.allData[category.Key][task_Keys[index_Of_Physic]].Length).ToString();
                        course_Prefabs_Holder.transform.GetChild(3).gameObject.GetComponent<Text>().text = task_Keys[index_Of_Physic];
                        course_Prefabs_Holder.transform.GetChild(5).gameObject.GetComponent<Slider>().value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Physic]);
                        course_Prefabs_Holder.GetComponent<Button>().onClick.AddListener(() => {
                            if (Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Physic]) >= 5)
                            {
                                question_Number_value = 0;
                            }
                            else
                            {
                                question_Number_value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Physic]);
                            }
                            category_Key_Variable = category.Key;
                        question_task_Variable = task_Keys[index_Of_Physic];
                        task_Key_Variable = index_Of_Physic;
                        question_Number_value = 0;
                        Quiz_Show(category.Key, task_Keys[index_Of_Physic], question_Number_value, index_Of_Physic);
                        GameManager_BLI.Instance.Quiz_Task_Screen();
                            update_Progress_Bar();
                        });

                    }
                    break;
                case "Statistic":
                    for (int i = 0; i < all_Content_Data.allData[category.Key].Count; i++)
                    {
                        int index_Of_Statistic = i;
                        course_Prefabs_Holder = Instantiate(prefabs_Course_Card, go_Course_Subject);
                        course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Text>().text = (question_Number_value + 1).ToString();
                        course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<Text>().text = ("of " + all_Content_Data.allData[category.Key][task_Keys[index_Of_Statistic]].Length).ToString();
                        course_Prefabs_Holder.transform.GetChild(3).gameObject.GetComponent<Text>().text = task_Keys[index_Of_Statistic];
                        course_Prefabs_Holder.transform.GetChild(5).gameObject.GetComponent<Slider>().value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Statistic]);
                        course_Prefabs_Holder.GetComponent<Button>().onClick.AddListener(() => {
                            if (Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Statistic]) >= 5)
                            {
                                question_Number_value = 0;
                            }
                            else
                            {
                                question_Number_value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Statistic]);
                            }
                            category_Key_Variable = category.Key;
                        question_task_Variable = task_Keys[index_Of_Statistic];
                        task_Key_Variable = index_Of_Statistic;
                        question_Number_value = 0;
                        Quiz_Show(category.Key, task_Keys[index_Of_Statistic], question_Number_value, index_Of_Statistic);
                        GameManager_BLI.Instance.Quiz_Task_Screen();
                            Task_Progress_Tracker.Instance.Last_Task_Open(category.Key, task_Keys[index_Of_Statistic],  question_Number_value, index_Of_Statistic);
                            update_Progress_Bar();
                        });
                     }
                    break;
                case "Algebra":
                    for (int i = 0; i < all_Content_Data.allData[category.Key].Count; i++)
                    {
                        int index_Of_Algebra = i;
                        course_Prefabs_Holder = Instantiate(prefabs_Course_Card, go_Course_Subject);
                        course_Prefabs_Holder.transform.GetChild(3).gameObject.GetComponent<Text>().text = task_Keys[index_Of_Algebra];
                        course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Text>().text = (question_Number_value + 1).ToString();
                        course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<Text>().text = ("of " + all_Content_Data.allData[category.Key][task_Keys[index_Of_Algebra]].Length).ToString();
                        course_Prefabs_Holder.transform.GetChild(5).gameObject.GetComponent<Slider>().value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Algebra]);
                        course_Prefabs_Holder.GetComponent<Button>().onClick.AddListener(() => {
                            if (Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Algebra]) >= 5)
                            {
                                question_Number_value = 0;
                            }
                            else
                            {
                                question_Number_value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Algebra]);
                            }
                            category_Key_Variable = category.Key;
                        question_task_Variable = task_Keys[index_Of_Algebra];
                        task_Key_Variable = index_Of_Algebra;
                        question_Number_value = 0;
                        Quiz_Show(category.Key, task_Keys[index_Of_Algebra],  question_Number_value, index_Of_Algebra);
                        GameManager_BLI.Instance.Quiz_Task_Screen();
                        update_Progress_Bar();
                        });
                    }
                    break;
                    case "Geometry":
                    for (int i = 0; i < all_Content_Data.allData[category.Key].Count; i++)
                    {
                        int index_Of_Geometry = i;
                        course_Prefabs_Holder = Instantiate(prefabs_Course_Card, go_Course_Subject);
                        course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Text>().text = (question_Number_value + 1).ToString();
                        course_Prefabs_Holder.transform.GetChild(2).transform.GetChild(1).gameObject.GetComponent<Text>().text = ("of " + all_Content_Data.allData[category.Key][task_Keys[index_Of_Geometry]].Length).ToString();
                        course_Prefabs_Holder.transform.GetChild(5).gameObject.GetComponent<Slider>().value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Geometry]);
                        course_Prefabs_Holder.transform.GetChild(3).gameObject.GetComponent<Text>().text = task_Keys[index_Of_Geometry];
                        course_Prefabs_Holder.GetComponent<Button>().onClick.AddListener(() => {
                            if (Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Geometry]) >= 5)
                            {
                                question_Number_value = 0;
                            }
                            else
                            {
                                question_Number_value = Task_Progress_Tracker.Instance.Get_Task_Value(task_Keys[index_Of_Geometry]);
                            }
                            category_Key_Variable = category.Key;
                        question_task_Variable = task_Keys[index_Of_Geometry];
                        task_Key_Variable = index_Of_Geometry;
                        question_Number_value = 0;
                        Quiz_Show(category.Key, task_Keys[index_Of_Geometry],  question_Number_value, index_Of_Geometry);
                        GameManager_BLI.Instance.Quiz_Task_Screen();
                        update_Progress_Bar();
                        });
                    }
                    break;   
            }
        }
    }
    public void Check_Answer()
    {
            Toggle selectToggle;
            selectToggle = toggle_Group.ActiveToggles().FirstOrDefault();
            string selectAnswer = selectToggle.GetComponentInChildren<Text>().text;
            if (selectAnswer == all_Content_Data.allData[category_Key_Variable][question_task_Variable][question_Number_value].answer)
            {
                question_Number_value += 1;
                selectToggle.isOn = false;
            Task_Progress_Tracker.Instance.Set_Task_Value(question_task_Variable, question_Number_value);
                GameManager_BLI.Instance.Correct_Answer(true);
                Rearrange_Answer();
                update_Progress_Bar();
                StartCoroutine(Next_Task_Values());
        }
            else
            {
                question_Number_value += 1;
                selectToggle.isOn = false;
                GameManager_BLI.Instance.Correct_Answer(false);
                Rearrange_Answer();
                update_Progress_Bar();
                StartCoroutine(Next_Task_Values()); 

            }
        }
     IEnumerator Next_Task_Values()
    {
        
        yield return new WaitForSeconds(3.5f);
        
        if (question_Number_value >= all_Content_Data.allData[category_Key_Variable][question_task_Variable].Length)
        {
            GameManager_BLI.Instance.Back_To_Course_Screen();
        }
        else
        {
            Quiz_Show(category_Key_Variable, question_task_Variable,  question_Number_value, task_Key_Variable);
        }
    }
    public void Quiz_Show(string category_Key, string question_Key, int question_NO, int task_Key)
    {
        Rearrange_Answer();
        List<string> mathy = new List<string>(all_Content_Data.allData[category_Key].Keys);
        question_Key_Text.GetComponent<Text>().text = mathy[task_Key];
       question_Key_Text.transform.GetChild(0).gameObject.GetComponent<Text>().text = all_Content_Data.allData[category_Key][question_Key][question_NO].questions;
        parent_Of_Quiz_Choices.GetChild(3).GetComponentInChildren<Text>().text = all_Content_Data.allData[category_Key][question_Key][question_NO].answer;
        parent_Of_Quiz_Choices.GetChild(1).GetComponentInChildren<Text>().text = all_Content_Data.allData[category_Key][question_Key][question_NO].wrongAnswer_1;
        parent_Of_Quiz_Choices.GetChild(2).GetComponentInChildren<Text>().text = all_Content_Data.allData[category_Key][question_Key][question_NO].wrongAnswer_2;
        parent_Of_Quiz_Choices.GetChild(0).GetComponentInChildren<Text>().text = all_Content_Data.allData[category_Key][question_Key][question_NO].wrongAnswer_3;
       explanation_Answer_Text.GetComponent<Text>().text = all_Content_Data.allData[category_Key][question_Key][question_NO].explanation;
        Task_Progress_Tracker.Instance.Last_Task_Open(category_Key,question_Key,question_NO,task_Key);
        resume_Course_Object.GetComponentInChildren<Slider>().value = Task_Progress_Tracker.Instance.Get_Task_Value(PlayerPrefs.GetString("Last_Category_Key_Question"));
        StartCoroutine(Question_Image_Json_Download(category_Key,question_Key,question_NO));
        StartCoroutine(Explanation_Image_Json_Download(category_Key, question_Key, question_NO));
    }
   public IEnumerator Question_Image_Json_Download(string category_key_Image, string question_key_Image, int question_No_Image) 
    {
        var init_Task_BLI = DropboxHelper.Initialize();
        yield return new WaitUntil(() => init_Task_BLI.IsCompleted);
        string image_local_Path = Application.persistentDataPath + path_BIA + all_Content_Data.allData[category_key_Image][question_key_Image][question_No_Image].question_Image;
        if (!File.Exists(image_local_Path))
        {
        Debug.Log("Enter in Image Download");
            var Image_path_BLI = DropboxHelper.GetRequestForFileDownload(category_key_Image + path_BIA + all_Content_Data.allData[category_key_Image][question_key_Image][question_No_Image].question_Image);
            Image_path_BLI.downloadHandler = new DownloadHandlerBuffer();
            Image_path_BLI.SendWebRequest();
            yield return new WaitUntil(() => Image_path_BLI.isDone);
            File.WriteAllBytes(image_local_Path, Image_path_BLI.downloadHandler.data);
            byte[] picBytes_IMDA_Ys = File.ReadAllBytes(Application.persistentDataPath + path_BIA + all_Content_Data.allData[category_key_Image][question_key_Image][question_No_Image].question_Image);
            Texture2D _tex2D_BLI = new Texture2D(2, 2);
            _tex2D_BLI.LoadImage(picBytes_IMDA_Ys);
            Sprite newSprite_BLI = Sprite.Create(_tex2D_BLI, new Rect(0, 0, _tex2D_BLI.width, _tex2D_BLI.height), new Vector2(0.5f, 0.5f), 100f);
            question_Image.transform.GetChild(0).GetComponent<Image>().sprite = newSprite_BLI;
        }
        else
        {
            byte[] picBytes_IMDA_Ys = File.ReadAllBytes(Application.persistentDataPath + path_BIA + all_Content_Data.allData[category_key_Image][question_key_Image][question_No_Image].question_Image);
            Texture2D tex2D_BLI = new Texture2D(2, 2);
            tex2D_BLI.LoadImage(picBytes_IMDA_Ys);
            Sprite _newSprite_BLI = Sprite.Create(tex2D_BLI, new Rect(0, 0, tex2D_BLI.width, tex2D_BLI.height), new Vector2(0.5f, 0.5f), 100f);
            question_Image.transform.GetChild(0).GetComponent<Image>().sprite = _newSprite_BLI;
        }
        }
    public IEnumerator Explanation_Image_Json_Download(string category_key_Image, string question_key_Image, int question_No_Image)
    {
        string image_local_Path = Application.persistentDataPath + path_BIA + all_Content_Data.allData[category_key_Image][question_key_Image][question_No_Image].explanation_image;
        if (!File.Exists(image_local_Path))
        {
            Debug.Log("Enter in Image Download");
            var Image_path_BLI = DropboxHelper.GetRequestForFileDownload(category_key_Image + path_BIA + all_Content_Data.allData[category_key_Image][question_key_Image][question_No_Image].explanation_image);
            Image_path_BLI.downloadHandler = new DownloadHandlerBuffer();
            Image_path_BLI.SendWebRequest();
            yield return new WaitUntil(() => Image_path_BLI.isDone);
            File.WriteAllBytes(image_local_Path, Image_path_BLI.downloadHandler.data);
            byte[] picBytes_IMDA_BLI = File.ReadAllBytes(Application.persistentDataPath + path_BIA + all_Content_Data.allData[category_key_Image][question_key_Image][question_No_Image].explanation_image);
            Texture2D tex2D_IMDA_BLI = new Texture2D(2, 2);
            tex2D_IMDA_BLI.LoadImage(picBytes_IMDA_BLI);
            Sprite newSprite_BIL = Sprite.Create(tex2D_IMDA_BLI, new Rect(0, 0, tex2D_IMDA_BLI.width, tex2D_IMDA_BLI.height), new Vector2(0.5f, 0.5f), 100f);
            question_Explanation_Image.transform.GetChild(0).GetComponent<Image>().sprite = newSprite_BIL;
        }
        else
        {
            byte[] _picBytes_IMDA_BLI = File.ReadAllBytes(Application.persistentDataPath + path_BIA + all_Content_Data.allData[category_key_Image][question_key_Image][question_No_Image].question_Image);
            Texture2D _tex2D_IMDA_BLI = new Texture2D(2, 2);
            _tex2D_IMDA_BLI.LoadImage(_picBytes_IMDA_BLI);
            Sprite _newSprite_BIL = Sprite.Create(_tex2D_IMDA_BLI, new Rect(0, 0, _tex2D_IMDA_BLI.width, _tex2D_IMDA_BLI.height), new Vector2(0.5f, 0.5f), 100f);
            question_Explanation_Image.transform.GetChild(0).GetComponent<Image>().sprite = _newSprite_BIL;
        }
    }

   
   
    public void Rearrange_Answer()
    {
        Transform parent = parent_Of_Quiz_Choices;
        GameObject answer_child = parent.GetChild(3).gameObject;
        answer_child.transform.SetSiblingIndex(Random.Range(0,4));
    }
    public void Resume_Quiz_Show()
    {
       
            category_Key_Variable = PlayerPrefs.GetString("Last_Category_Key");
            question_task_Variable = PlayerPrefs.GetString("Last_Category_Key_Question");
            question_Image_Variable = PlayerPrefs.GetString("Last_cQuestion_Image");
            explanation_Image_Variale = PlayerPrefs.GetString("Last_Explanation_Image");
            question_Number_value = PlayerPrefs.GetInt("Last_Question_Number");
            Quiz_Show(PlayerPrefs.GetString("Last_Category_Key"), PlayerPrefs.GetString("Last_Category_Key_Question"), PlayerPrefs.GetInt("Last_Question_Number"), PlayerPrefs.GetInt("Last_Question_Index"));
            BottomNavigationBar_BLI.Instance.CourseScreen();
            GameManager_BLI.Instance.Quiz_Task_Screen();
    }
    public void update_Progress_Bar()
    {
        float BLI_progress = Total_Question_solved();
        _ProgressBar_BLI.GetComponent<Slider>().value = BLI_progress;
    }
    public float Total_Question_solved()
    {
        return question_Number_value;
        #region Refactoring
        for (int j = 0; j < 0; j++)
        {
            if (false || false && false)
            {
                for (int i_BLI = 0; j < 0; j++)
                {
                    if (false || false && false)
                    {
                        for (int w_BLI = 0; j < 0; j++)
                        {
                            if (false || false && false)
                            {
                            }

                        }
                    }

                }
            }

        }
        #endregion
    }
    public void Submit_Button_Update()
    {
        if (toggle_Group.isActiveAndEnabled)
        {
            submit_Quiz_Button.interactable = true;
        }
        else
        {
            submit_Quiz_Button.interactable = false;
        }
        #region Refactoring code
        while (false)
        {
            if (false)
            {
                try
                {
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
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
                try
                {
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        #endregion
    }
    public void Recommended_Course_1()
    {
        category_Key_Variable = "Math";
        question_task_Variable = "2-step equations";
        question_Number_value = 0;
        Quiz_Show(category_Key_Variable, question_task_Variable,question_Number_value, 3);
        GameManager_BLI.Instance.Quiz_Task_Screen();

    }
    public void Recommended_Course_2()
    {
        category_Key_Variable = "Geometry";
        question_task_Variable = "Area problems";
        question_Number_value = 0;
       Quiz_Show(category_Key_Variable, question_task_Variable, question_Number_value, 2);
        GameManager_BLI.Instance.Quiz_Task_Screen();
    }
    public void Recommended_Course_3()
    {
        category_Key_Variable = "Math";
        question_task_Variable = "Adding and subtracting negative numbers";
        question_Number_value = 0;
        Quiz_Show(category_Key_Variable, question_task_Variable, question_Number_value, 1);
        GameManager_BLI.Instance.Quiz_Task_Screen();
    }
    public void Recommended_Course_4()
    {
        category_Key_Variable = "Statistic";
        question_task_Variable = "Z scores";
        question_Number_value = 0;
        Quiz_Show(category_Key_Variable, question_task_Variable, question_Number_value, 2);
        GameManager_BLI.Instance.Quiz_Task_Screen();
    }
}
