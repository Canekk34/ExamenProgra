using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct WeatherData 
{
    public string country; //Pias
    public string city;//Ciudad
    public float actualTemp;//Temperatura Actual
    public string description;//Descripcion
    public float windSpeed;//Velocidad del viento
}
