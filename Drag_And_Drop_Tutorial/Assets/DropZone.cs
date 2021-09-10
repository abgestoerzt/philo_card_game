using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{

    public Dragable.Slot typeOfItem = Dragable.Slot.WEAPON;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d!=null)
        {
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null && d.placeholderParent==this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name+"was dropped on  " + gameObject.name);

        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        if (d != null)
        {
            d.parentToReturnTo = this.transform;
        }



    }

        
}
