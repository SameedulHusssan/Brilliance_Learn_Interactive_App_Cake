using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TimeSelector : MonoBehaviour
{
    [Tooltip("If the this gameobject is on the HourScrollView UI, this value should point to HourTimePicker. Same logic goes with setting up minute")]
    [SerializeField] private TimeTextArray _timeTextArray;

    /// <summary>
    /// Attempts to retrieve the time from the TimeTextArray. Useful to get the hour/minute time
    /// </summary>
    /// <param name="text">The text value result gotten from TimeTextArray</param>
    /// <returns>True when successful, false when not successful</returns>
    public bool GetTimeInText(out Text text)
    {
        int lenght = _timeTextArray.TimeTexts.Length;

        float[] distances = new float[lenght];
        for (int i = 0; i < lenght; i++)
            distances[i] = Vector2.Distance((Vector2)transform.position, (Vector2)_timeTextArray.TimeTexts[i].position);

        float smallestDistance = distances.Min();
        int indexOfSmallestDistance = Array.IndexOf(distances, smallestDistance);

        return _timeTextArray.TimeTexts[indexOfSmallestDistance].TryGetComponent(out text);
    }
}