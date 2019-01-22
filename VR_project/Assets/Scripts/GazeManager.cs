using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GazeManager : MonoBehaviour
{
    public float sightlength = 100.0f;
    public GameObject currentButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void FixedUpdate()
    {
        RaycastHit seen;
        Ray raydirection = new Ray(transform.position, transform.forward);
        GameObject hitButton = null;

        PointerEventData data = new PointerEventData(EventSystem.current);

        if (Physics.Raycast(raydirection, out seen, sightlength))
        {
            if (seen.collider.tag == "UI")
            {
                hitButton = seen.transform.gameObject;
            }
        }

        if(currentButton != hitButton)
        {
            if(currentButton != null)
            {
                ExecuteEvents.Execute<IPointerExitHandler>(currentButton, data, ExecuteEvents.pointerExitHandler);
            }
            currentButton = hitButton;

            if (currentButton != null)
            {
                ExecuteEvents.Execute<IPointerEnterHandler>(currentButton, data, ExecuteEvents.pointerEnterHandler);
            }
        }
    }





    /*public float sightlength = 100.0f;
    public GameObject selectedObj;

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void FixedUpdate()
    {
        RaycastHit seen;
        Ray raydirection = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(raydirection, out seen, sightlength))
        {
            if (seen.collider.tag == "UI")
            {
                string name = seen.collider.gameObject.name;

                if(name == "Play")
                {
                    seen.collider.gameObject.GetComponent<EventTrigger>().OnPointerEnter();
                }
            }
        }
    }*/
}