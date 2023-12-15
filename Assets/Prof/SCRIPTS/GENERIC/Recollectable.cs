using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Para que un objeto se pueda recolectar, este debe de contar con un collider
/// para que el raycast lo pueda identificar.
/// 
/// Debe de contar con un tag, en este caso el tag es "Recollectable"
/// 
/// Y la variable objeto de este script, debe contener un scriptable object
/// </summary>
public class Recollectable : MonoBehaviour, IRecollectable
{
    [SerializeField] private Item objeto;

    public Item Pick()
    {
        return objeto;
    }
}
