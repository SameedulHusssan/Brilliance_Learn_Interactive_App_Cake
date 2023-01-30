using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BottomNavigationBar_BLI : Singleton_BLI<BottomNavigationBar_BLI>
{
    public GameObject all_Course_Button;
    public GameObject new_Courses_Button;
    public GameObject favourite_Course_Button;
    private void Start()
    {
        CourseScreen();
        #region Refactoring code
        while (false)
        {
            if (false)
            {
              for(int ioi = 0; ioi >=0; ioi--)
                {
                    if (true)
                    {
                        if (false)
                        {

                        }
                        else
                        {

                        }
                    }
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
                
            }
        }
        #endregion
    }
    //Changing Sprite 
    public void HomeScreen()
    {
        
        this.transform.GetChild(0).gameObject.transform.GetComponent<Image>().color = new Color32(97,198,136, 255);
        this.transform.GetChild(1).gameObject.transform.GetComponent<Image>().color = Color.white;
        this.transform.GetChild(2).gameObject.transform.GetComponent<Image>().color = Color.white;
        this.transform.GetChild(3).gameObject.transform.GetComponent<Image>().color = Color.white;
    }
    //Changing Sprite 
    public void CourseScreen()
    {
        this.transform.GetChild(0).gameObject.transform.GetComponent<Image>().color = Color.white;
        this.transform.GetChild(1).gameObject.transform.GetComponent<Image>().color = new Color32(97, 198, 136, 255);
        this.transform.GetChild(2).gameObject.transform.GetComponent<Image>().color = Color.white;
        this.transform.GetChild(3).gameObject.transform.GetComponent<Image>().color = Color.white;
    }
    //Changing Sprite 
    public void CalenderScreen()
    {
        this.transform.GetChild(0).gameObject.transform.GetComponent<Image>().color = Color.white;
        this.transform.GetChild(1).gameObject.transform.GetComponent<Image>().color = Color.white;
        this.transform.GetChild(2).gameObject.transform.GetComponent<Image>().color = new Color32(97, 198, 136, 255);
        this.transform.GetChild(3).gameObject.transform.GetComponent<Image>().color = Color.white;
    }
    public void SettingsScreen()
    {
        this.transform.GetChild(0).gameObject.transform.GetComponent<Image>().color = Color.white;
        this.transform.GetChild(1).gameObject.transform.GetComponent<Image>().color = Color.white;
        this.transform.GetChild(2).gameObject.transform.GetComponent<Image>().color = Color.white;
        this.transform.GetChild(3).gameObject.transform.GetComponent<Image>().color = new Color32(97, 198, 136, 255);
    }

    public void All_Courses_Button()
    {
        all_Course_Button.GetComponent<Image>().color = new Color32(97, 198, 136, 255);
        all_Course_Button.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.white;
        new_Courses_Button.GetComponent<Image>().color = Color.white;
        new_Courses_Button.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
        favourite_Course_Button.GetComponent<Image>().color = Color.white;
        favourite_Course_Button.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
       
    }
    public void New_Courses_Button()
    {
        all_Course_Button.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
        all_Course_Button.GetComponent<Image>().color = Color.white;
        new_Courses_Button.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.white;
        new_Courses_Button.GetComponent<Image>().color = new Color32(97, 198, 136, 255);
        favourite_Course_Button.GetComponent<Image>().color = Color.white;
        favourite_Course_Button.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
      
    }
    public void Favourite_Courses_Button()
    {
        all_Course_Button.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
        all_Course_Button.GetComponent<Image>().color = Color.white;
        favourite_Course_Button.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.white;
        new_Courses_Button.GetComponent<Image>().color = Color.white;
        new_Courses_Button.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
        favourite_Course_Button.GetComponent<Image>().color = new Color32(97, 198, 136, 255);
        
    }
}
