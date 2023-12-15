using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Todas las clases que hereden de esta interfaz, deberán de implementar
// los metodos que contenga la misma
public interface IInteractable
{

    public bool _requireInventory { get; set; }
    
    public void Interact(Inventory inventory);
    
    // Este metodo es el que uso, cuano quiero hacer la interaccion, sin restricciones
    public void Interact();

}