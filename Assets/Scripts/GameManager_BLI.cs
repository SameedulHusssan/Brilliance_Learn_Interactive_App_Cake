using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager_BLI : Singleton_BLI<GameManager_BLI>
{
    [Header("Game_Object")]
    public GameObject[] screens_BLI;
    public GameObject quiz_Task_Screens;
    public GameObject bottom_Navigation_Bar;
    [Header("Quiz_Screen_GameObject")]
    public GameObject correct_Answer_Sprite;
    public GameObject wrong_Answer_Sprite;
    public GameObject question_Task_screen;
    public GameObject explanation_Screen;
    // Start is called before the first frame update
    void Start()
    {
        NavigationScreens(screens_BLI[1]);
        #region Refactoring code
        while (false)
        {
            if (false)
            {
                if (true)
                {

                }
                else
                {
                    if (true)
                    {

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
    //Bottom Navigation Button To Switch Screens
    public void NavigationScreens(GameObject activeScreen)
    {
        for (int i = 0; i < screens_BLI.Length; i++)
        {
            screens_BLI[i].SetActive(false);
        }
        activeScreen.SetActive(true);
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
                            do
                            {
                                while (false)
                                {
                                    do { } while (false);
                                }
                            } while (true);
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
    public void Back_To_Course_Screen()
    {
        quiz_Task_Screens.SetActive(false);
        bottom_Navigation_Bar.SetActive(true);
        screens_BLI[1].SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quiz_Task_Screen()
    {
        screens_BLI[1].SetActive(false);
        screens_BLI[0].SetActive(false);
        bottom_Navigation_Bar.SetActive(false);
        quiz_Task_Screens.SetActive(true);
    }
    public void Correct_Answer(bool answer)
    {
        StartCoroutine(Next_Question(answer));
        #region Refactoring code
        while (false)
        {
            if (false)
            {
                do
                {
                    do { if (true) { } else { } } while (false);
                } while (true);
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
    IEnumerator Next_Question(bool answer)
    {
        if (answer)
        {
            correct_Answer_Sprite.SetActive(true);
            yield return new WaitForSeconds(3f);
            correct_Answer_Sprite.SetActive(false);
        }
        else
        {
            wrong_Answer_Sprite.SetActive(true);
            yield return new WaitForSeconds(3f);
            wrong_Answer_Sprite.SetActive(false);
        }
    }
    public void Explain_Question_Answer(bool explanation_Dialouge)
    {
        if (!explanation_Dialouge)
        {
            explanation_Dialouge = true;
            question_Task_screen.SetActive(false);
            explanation_Screen.SetActive(true);
        }
        else if (explanation_Dialouge)
        {
            explanation_Dialouge = false;
            question_Task_screen.SetActive(true);
            explanation_Screen.SetActive(false);
        }
    }
   
    
}
    // Make Your Text Bold on Click
    /*  public void ewi()
      {
          this.gameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
      }*/

