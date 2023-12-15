using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Son objetos creados via script, no son objetos fisicos en la escena
[CreateAssetMenu(fileName ="New Item" ,menuName = "Scriptable Objects/Item", order = 1 )]
public class Item : ScriptableObject
{
    public string name; // Nombre del objeto
    public Sprite icon; // Imagen que representa el objeto
    public string description; // Una breve descripcion del objeto
    public float value; // El valor del objeto dentro de el juego en base a la economia de este
    public GameObject prefab; // Es para saber a que objeto/mesh esta ligado el objeto
}
