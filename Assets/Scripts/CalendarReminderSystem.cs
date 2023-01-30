using System;
using UnityEngine;
using UnityEngine.UI;

public class CalendarReminderSystem : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject _timeScroll;
    [SerializeField] private GameObject _closeTimeScrollPanel;

    [Header("Time details")]
    [SerializeField] private Text _hourTimeText;
    [SerializeField] private Text _minuteTimeText;

    [Header("Time Selectors")]
    [SerializeField] private TimeSelector _hourTimeSelector;
    [SerializeField] private TimeSelector _minuteTimeSelector;

    [Header("Toggles")]
    [SerializeField] private ToggleSwitch _mathAndLogicToggle;
    [SerializeField] private ToggleSwitch _scienceAndEngineering;

    private int _hourTime;      //The hour set in the reminder by the user
    private int _minuteTime;    //The minute set in the reminder by the user

    private void Awake()
    {
        _mathAndLogicToggle.OnSwitch_BLI += ToggleMathAndLogicReminder;
        _scienceAndEngineering.OnSwitch_BLI += ToggleScienceAndEngineeringReminder;
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
                
            }
        }
        #endregion
    }

    private void Update()
    {
        if (!_timeScroll.activeInHierarchy) return;

        if (_hourTimeSelector.GetTimeInText(out Text hourText) && _minuteTimeSelector.GetTimeInText(out Text minuteText))
        {
            _hourTime = int.Parse(hourText.text);
            _minuteTime = int.Parse(minuteText.text);

            _hourTimeText.text = hourText.text;
            _minuteTimeText.text = minuteText.text;
        }
    }

    /// <summary>
    /// This is what happens once the Math And Logic reminder is toggled
    /// </summary>
    /// <param name="status">If true, notifications are enabled. If false, they are disabled</param>
    private void ToggleMathAndLogicReminder(bool status)
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

            }
        }
        #endregion
    }

    /// <summary>
    /// This is what happens once the Science and Engineering reminder is toggled
    /// </summary>
    /// <param name="status">If true, notifications are enabled. If false, they are disabled</param>
    private void ToggleScienceAndEngineeringReminder(bool status)
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

            }
        }
        #endregion
    }

    /// <summary>
    /// Event called from Unity's Button's OnClick Listener on 'Calender Time Picker- Time' gameObject
    /// </summary>
    public void CalendarTimePicker()
    {
        bool timeScrollActive = _timeScroll.activeInHierarchy;
        _timeScroll.SetActive(!timeScrollActive);

        if (timeScrollActive)
            _closeTimeScrollPanel.SetActive(true);
    }
}