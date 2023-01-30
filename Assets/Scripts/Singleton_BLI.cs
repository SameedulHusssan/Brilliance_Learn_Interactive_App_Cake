using System;
using UnityEngine;

public class Singleton_BLI<T> : MonoBehaviour where T : Component
{
    //Singleton File 
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    var obj_BLI = new GameObject();
                    instance = obj_BLI.AddComponent<T>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

   public void Refactoring_BLI()
    {
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


}
