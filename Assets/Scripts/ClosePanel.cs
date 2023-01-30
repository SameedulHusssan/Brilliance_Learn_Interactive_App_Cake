using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ClosePanel : MonoBehaviour, IPointerDownHandler
{
    [FormerlySerializedAs("_panels")] [SerializeField] private GameObject[] _panels_BLI;

    public void OnPointerDown(PointerEventData eventData)
    {        
        for (int i = 0; i < _panels_BLI.Length; i++)
            _panels_BLI[i].SetActive(false);

        gameObject.SetActive(false);
    }
}