using UnityEngine;
using UnityEngine.UI;

public class CDeviceTypeDeterminator_BLI : MonoBehaviour
{
    public static bool IsTabletDr_BLI => isTabletDr_BLI;
    private static bool isTabletDr_BLI;
    private void Awake()
    {
        var safeAreaDr_BLI = Screen.safeArea;

        var _anchorPlaneMinDr_BLI = safeAreaDr_BLI.position;
        _anchorPlaneMinDr_BLI.x /= Screen.width;
        _anchorPlaneMinDr_BLI.y /= Screen.height;

        var _anchorMaxDr_BLI = safeAreaDr_BLI.position + safeAreaDr_BLI.size;
        _anchorMaxDr_BLI.x /= Screen.width;

        float _screenWidthDr_BLI = Screen.width / Screen.dpi;
        float _screenHeightDr_BLI = Screen.height / Screen.dpi;
        float _diagonalInchesDr_BLI = Mathf.Sqrt(Mathf.Pow(_screenWidthDr_BLI, 2) + Mathf.Pow(_screenHeightDr_BLI, 2));
        var _aspectRatioDr_BLI = Mathf.Max(Screen.width, Screen.height) / (float)Mathf.Min(Screen.width, Screen.height);
        isTabletDr_BLI = (_diagonalInchesDr_BLI > 6.5f && _aspectRatioDr_BLI < 1.6f);
       
       
    }

    private void Start()
    {
        var cs_BLI = GetComponent<CanvasScaler>();
        if (IsTabletDr_BLI)
            cs_BLI.matchWidthOrHeight = 1f;
        else
            cs_BLI.matchWidthOrHeight = 0.5f;

    }
}
