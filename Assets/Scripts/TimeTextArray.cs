using UnityEngine;

public class TimeTextArray : MonoBehaviour
{
    [Tooltip("These are the UI text elements containing HourX or MinuteX, and should be ordered alphabetically. Ignore adding Top/BottomEmptyOffsets")]
    [SerializeField] private RectTransform[] _timeTexts;
    public RectTransform[] TimeTexts { get { return _timeTexts; } }
}