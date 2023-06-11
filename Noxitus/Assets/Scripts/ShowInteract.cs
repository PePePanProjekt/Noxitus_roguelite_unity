using System;

using TMPro;
using UnityEngine;


public class ShowInteract : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private InteractObject itemDetected;
    [SerializeField] private GameObject inNoti;
    
    void Awake()
    {
        inNoti.SetActive(false);
    }

    public void Show(InteractObject item)
    {
        if (itemDetected != null)
        {
            if (itemDetected.GetDistance() > item.GetDistance())
            {
                itemDetected = item;
            }
        }
        else
        {
            itemDetected = item;
        }

        ShowItem(itemDetected.GetNote());
    }

    private void ShowItem(String te)
    {
        inNoti.SetActive(true);
        text.text = te;
    }
    
    public void InteractButton()
    {
        if (itemDetected != null)
        {
            itemDetected.Interact();
        }
    }
    
    public void Hide(InteractObject item)
    {
        if (itemDetected == item)
        {
            inNoti.SetActive(false);
            itemDetected = null;
        }
        
    }
    
    
    
}
