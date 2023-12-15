using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum MatColor
{   
    Red, Blue, Green, Yellow, Pink, Orange, Brown, Purple, Black, White
  // 0    1      2       3      4      5      6      7       8      9
}

public abstract class Personaje
{

    public string nombre;

    public abstract void Presentarte();

}

public class Mago : Personaje
{

    public override void Presentarte()
    {
        Debug.Log("Hola soy " + nombre);
    }

}

public class Brujo : Mago
{

    public override void Presentarte()
    {
        Debug.Log("Soy un brujo");
    }

}


public class Guerrero : Personaje
{

    public override void Presentarte()
    {

    }

}
