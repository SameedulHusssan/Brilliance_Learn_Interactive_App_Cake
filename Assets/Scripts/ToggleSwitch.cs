using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToggleSwitch : MonoBehaviour, IPointerClickHandler
{
    public bool State { get { return _switchState; } }

    [Tooltip("Toggle state")]
    [SerializeField] private bool _switchState;
    [Tooltip("Toggle knob switch offset pos. This is the number of units to move once the switch is clicked")]
    [SerializeField] private float _switchHorizontalPos = 25f;
    [Tooltip("If the toggle 'Switch State' is false, the image attached to this object will change to this color")]
    [SerializeField] private Color _switchOffColor;
    [Tooltip("If the toggle 'Switch State' is true, the image attached to this object will change to this color")]
    [SerializeField] private Color _switchOnColor;

    private RectTransform _knob;
    private Image _knobImage;

    public Action<bool> OnSwitch_BLI;

    private void Awake()
    {
        _knob = transform.GetChild(0).GetComponent<RectTransform>();
        _knobImage = GetComponent<Image>();

        SetInitialPositionBasedOnState();
    }

    /// <summary>
    /// Set the initial position based on the '_switchState'
    /// </summary>
    private void SetInitialPositionBasedOnState()
    {
        SetPosition_BLI(Vector2.zero);

        Vector2 anchoredPos_BLI = _knob.anchoredPosition;
        if (_switchState)
            anchoredPos_BLI.x += _switchHorizontalPos;
        else
            anchoredPos_BLI.x -= _switchHorizontalPos;
        SetPosition_BLI(anchoredPos_BLI);
        SwitchColor();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ClickSwitch();
        OnSwitch_BLI?.Invoke(_switchState);
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

    /// <summary>
    /// Called when a finger/click is registered on this game object
    /// </summary>
    public void ClickSwitch()
    {
        Vector2 endPosition_BLI = _knob.anchoredPosition;

        if (_switchState)
            endPosition_BLI.x -= _switchHorizontalPos * 2f;
        else
            endPosition_BLI.x += _switchHorizontalPos * 2f;
        SetPosition_BLI(endPosition_BLI);

        _switchState = !_switchState;
        SwitchColor();
    }

    private void SetPosition_BLI(Vector2 pos)
    {
        _knob.localPosition = pos;
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
                            Console.WriteLine("dsflksdnfkjsdkfdsnkdskckjdsnf");
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
                
                }
            }
        }
        #endregion
    }

    private void SwitchColor()
    {
        if (State)
            _knobImage.color = _switchOnColor;
        else
            _knobImage.color = _switchOffColor;
    }
}