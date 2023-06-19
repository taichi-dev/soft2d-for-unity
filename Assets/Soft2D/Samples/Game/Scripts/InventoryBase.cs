using UnityEngine;
using UnityEngine.EventSystems;
using Game;
using UnityEngine.UI;

public class InventoryBase : MonoBehaviour, IPointerEnterHandler, IBeginDragHandler, IDragHandler, IEndDragHandler,
    IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private GameManager gameManager;
    private UIManager uiManager;
    private int inventoryID;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameManager == null)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        if (uiManager == null)
        {
            uiManager = gameManager.uiManager;
        }

        if (inventoryID != -1)
        {
            if (uiManager.slotGroup[inventoryID].transform.GetChild(0).TryGetComponent(out Image image))
            {
                image.gameObject.SetActive(false);
            }
        }

        inventoryID = -1;
        var parent = transform.parent.gameObject;
        Transform[] allChildren = parent.GetComponentsInChildren<Transform>();

        // get this slot id by comparing all children's name
        for (int i = 0; i < allChildren.Length; ++i)
        {
            var childName = parent.transform.GetChild(i).name;
            if (childName == transform.name)
            {
                inventoryID = i;
                break;
            }
        }

        gameManager.currentInvId = inventoryID;
        if (inventoryID != -1)
        {
            if (uiManager.slotGroup[inventoryID].transform.GetChild(0).TryGetComponent<Image>(out Image image))
            {
                image.gameObject.SetActive(true);
            }
        }
    }

    #region Functions

    public void OnBeginDrag(PointerEventData eventData) { }
    public void OnDrag(PointerEventData eventData) { }
    public void OnEndDrag(PointerEventData eventData) { }
    public void OnPointerUp(PointerEventData eventData) { }
    public void OnPointerEnter(PointerEventData eventData) { }
    public void OnPointerExit(PointerEventData eventData) { }

    #endregion
}