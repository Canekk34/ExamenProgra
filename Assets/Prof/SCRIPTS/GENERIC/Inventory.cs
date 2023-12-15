using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script, va a ser unicamente y solamente, y nada mas, para almacenar y gestionar el inventario
/// </summary>
public class Inventory : MonoBehaviour
{

    public List<Item> inventory; // Esta lista es donde se guardaran los objeto
    [SerializeField] private int maxCapacity = 9; // Esta variable indica la capacidad maxima de mi inventario
    [SerializeField] private int objeto;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            Instantiate(inventory[objeto].prefab);
            inventory.Remove(inventory[objeto]);
        }
    }

    public void AddItem(Item itemToAdd)
    {
        inventory.Add(itemToAdd);
    }


}
