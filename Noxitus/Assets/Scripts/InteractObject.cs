using System;

using UnityEngine;

public class InteractObject : DetectPlayer
{
     
     private ShowInteract showInteract;

     [SerializeField] private String note;
    
    void Start()
    {
        showInteract = GameObject.FindGameObjectWithTag("Notification").GetComponent<ShowInteract>(); 
    }

    public virtual String GetNote()
    {
        return note;
    }
    
    public void Interact()
    {
        PickUpItem();
        Destroy(gameObject);
        PlayerAway();
    }

    protected override void PlayerDetected()
    {
        showInteract.Show(this);
    }
    
    public virtual void PickUpItem()
    {
     
    }
    
    protected override void PlayerAway()
    {
        showInteract.Hide(this);
    }
}
