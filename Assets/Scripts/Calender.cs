using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calender : MonoBehaviour
{
    public class Day
    {
        public int dayNum;
        public Color circleColor;
        public GameObject obj;
        public Day(int dayNum, Color circleColor, GameObject obj_BLI)
        {
            this.dayNum = dayNum;
            this.circleColor = circleColor;
            this.obj = obj_BLI;
            obj_BLI.GetComponent<Image>().color = circleColor;
            UpdateColor_BLI(circleColor);
            UpdateDay_BLI(dayNum);
        }
        public void UpdateColor_BLI(Color newcolor)
        {
            obj.GetComponent<Image>().color = newcolor;
            circleColor = newcolor;
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
        public void UpdateDay_BLI(int newDayNum)
        {
            this.dayNum = newDayNum;
            if(circleColor==Color.white||circleColor==Color.green)
            {
                obj.GetComponentInChildren<Text>().text = (dayNum + 1).ToString();
            }
            else
            {
                obj.GetComponentInChildren<Text>().text = "";
            }
        }
    }
    private List<Day> days_BLI = new List<Day>();
    public Transform[] weeks_BLI;
    public Text Month_BLI;
    public Text Year_BLI;
    public GameObject calenderReminderSystem;
    public DateTime currDate = DateTime.Now;
    
    private void Start()
    {
        UpdateCalender_BLI(DateTime.Now.Year, DateTime.Now.Month);
    }
    void UpdateCalender_BLI(int year, int month)
    {
        DateTime timeTemp = new DateTime(year, month, 1);
        currDate = timeTemp;
        Month_BLI.text = timeTemp.ToString("MMMM");
        Year_BLI.text = timeTemp.Year.ToString();
        int startDay = GetMonthStartDay(year, month);
        int endDay = TotalNumberOfDays(year, month);

        if(days_BLI.Count == 0)
        {
            for(int _week_BLI = 0; _week_BLI < 6; _week_BLI++)
            {
                for(int i=0; i < 7; i++)
                {
                    Day  newDay;
                    int currDay = (_week_BLI * 7) + i;

                    if (currDay < startDay|| currDay -startDay >= endDay)
                    {
                        newDay = new Day(currDay - startDay, Color.grey, weeks_BLI[_week_BLI].GetChild(i).gameObject);
                    }
                    else
                    {
                        newDay = new Day(currDay - startDay, Color.white, weeks_BLI[_week_BLI].GetChild(i).gameObject);
                    }
                    days_BLI.Add(newDay);
                }
            }
        }
        else
        {
            for(int i= 0; i<42; i++)
            {
                if(i<startDay || i-startDay >= endDay)
                {
                    days_BLI[i].UpdateColor_BLI(Color.grey);
                }
                else
                {
                    days_BLI[i].UpdateColor_BLI(Color.white);
                }
                days_BLI[i].UpdateDay_BLI(i - startDay);
            }
        }

        if(DateTime.Now.Year == year && DateTime.Now.Month == month)
        {
            days_BLI[(DateTime.Now.Day - 1) + startDay].UpdateColor_BLI(Color.green);
         //   Debug.Log(days[(DateTime.Now.Day - 1) + startDay].UpdateColor(Color.green));
        }
    }
    int GetMonthStartDay(int year, int month)
    {
        DateTime temp_BLI = new DateTime(year, month, 1);
        return (int)temp_BLI.DayOfWeek;
    }
    int TotalNumberOfDays(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
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
                if (true)
                {
                    while (true)
                    {
                        do { } while (false);
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
    public void SwitchMonth(int direction)
    {
        if (direction < 0)
        {
            currDate = currDate.AddMonths(-1);
        }
        else
        {
            currDate = currDate.AddMonths(1);
        }
        UpdateCalender_BLI(currDate.Year, currDate.Month);
    }
    public void ReminderTimepicker()
    {
        calenderReminderSystem.SetActive(true);
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

