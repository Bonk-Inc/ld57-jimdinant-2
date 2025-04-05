using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIControllerManager : MonoBehaviour
{
    [SerializeField, SceneObjectsOnly]
    protected GameObject firstSelected;

    private void Awake()
    {
        if(firstSelected == null)
        {
            firstSelected = EventSystem.current.currentSelectedGameObject;
        }
    }

    public void SetSelectedUIObject(GameObject newSelected)
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (newSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(newSelected);
        }
    }
}
