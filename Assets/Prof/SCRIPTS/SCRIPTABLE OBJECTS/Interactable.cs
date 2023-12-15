using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable :  MonoBehaviour,IInteractable
{

    [SerializeField] private InteractionType interactionType;

    [SerializeField] private Item item;

    [SerializeField] private Animator animator;
    [SerializeField] private string animationName;
    [SerializeField] private bool animationState;

    [SerializeField] private GameObject target;
    [SerializeField] private bool activeTarget;

    [SerializeField] private bool requireInventory;
    
    public bool _requireInventory { get => requireInventory; set => requireInventory = value; }

    public void Interact()
    {
        switch(interactionType)
        {
            case InteractionType.Animation:
                {
                    AnimInteraction();
                    break;
                }

            case InteractionType.Destroy:
                {
                    DestroyInteraction();
                    break;
                }

            case InteractionType.Active:
                {
                    ActiveInteraction(); 
                    break;
                }
        }
    }

    // Este metodo, es el que quiero, si requiere item
    public void Interact(Inventory inventory)
    {
        
    }

    // Este metodo se usa en el tipo Animation
    public void AnimInteraction()
    {
                        // OpenDoor      // True
        animator.SetBool(animationName, animationState);
    }

    // Este metodo se usa en el tipo Destroy
    public void DestroyInteraction()
    {
        Destroy(target);
    }

    // Este metodo se usa en el tipo Active
    public void ActiveInteraction()
    {
        target.SetActive(activeTarget);
    }

}

public enum InteractionType
{
    Animation, Destroy, Active, ItemNeeded
}