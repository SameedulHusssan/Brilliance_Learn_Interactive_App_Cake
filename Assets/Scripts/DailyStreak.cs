using System;
using UnityEngine;
using UnityEngine.UI;

public class DailyStreak : MonoBehaviour
{
        // Key for storing the streak value in PlayerPrefs
        const string STREAK_KEY = "streak";
        // Key for storing the date of the lastsuccessful completion in PlayerPrefs
        const string LAST_COMPLETION_DATE_KEY = "lastCompletionDate";
    
        // Text element for displaying the current streak value
        public Text streakText;

        void Start()
        {
            // Get the current streak value from PlayerPrefs
            int streak = PlayerPrefs.GetInt(STREAK_KEY, 0);
            // Get the date of the last successful completion from PlayerPrefs
            string lastCompletionDateString = PlayerPrefs.GetString(LAST_COMPLETION_DATE_KEY, "");
            DateTime lastCompletionDate;
            if (DateTime.TryParse(lastCompletionDateString, out lastCompletionDate))
            {
                // Check if the current date is the same as the date of the last successful completion
                if (DateTime.Now.Date == lastCompletionDate.Date)
                {
                    // If the current date is the same as the date of the last successful completion, increment the streak value
                    streak++;
                }
                else
                {
                    // If the current date is different from the date of the last successful completion, reset the streak value to 1
                    streak = 1;
                }
            }
            else
            {
                // If there is no stored value for the date of the last successful completion, set the streak value to 1
                streak = 1;
            }

            // Set the text element to display the current streak value
            streakText.text = streak.ToString();

            // Set the onClick event for the task button to call the CompleteTask function
            
        }

        // Function to be called when the player clicks the task button
        void CompleteTask()
        {
            // Increment the streak value
            int streak = PlayerPrefs.GetInt(STREAK_KEY, 0) + 1;
            // Save the new streak value to PlayerPrefs
            PlayerPrefs.SetInt(STREAK_KEY, streak);
            // Save the current date as the date of the last successful completion
            PlayerPrefs.SetString(LAST_COMPLETION_DATE_KEY, DateTime.Now.ToString());
            // Update the text element to display the new streak value
            streakText.text = "Current streak: " + streak;
        }
    }

