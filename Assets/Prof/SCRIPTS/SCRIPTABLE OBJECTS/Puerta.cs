using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta :  MonoBehaviour,IInteractable
{
    // Esta variable, va a contener el item que se requiere para abrir la puerta
    [SerializeField] private Item llave;
    
    [SerializeField] private bool requireInventory;
    public bool _requireInventory { get => requireInventory; set => requireInventory = value; }

    public void Interact()
    {
        
    }
    
    public void Interact(Inventory inventario)
    {
        if(inventario.inventory.Contains(llave))
        {
            Debug.Log("Se abre la puerta");
            
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No tienes la llave");
        }
    }
}
