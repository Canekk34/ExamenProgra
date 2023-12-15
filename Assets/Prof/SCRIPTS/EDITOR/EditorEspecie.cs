using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

// Esta linea, indica que script o que parte del editor va
// a modificar
[CustomEditor(typeof(Especie))]
public class EditorEspecie : Editor
{

    private Especie _especieScript;

    private void OnEnable()
    {
        // Se asigna el target, es decir, el script objetivo a modificar
        _especieScript = (Especie)target;
    }

    // Sobreescribe el inspector
    public override void OnInspectorGUI()
    {
        //                                                                Nombre       Variable que aparece
        _especieScript.especie = (EnumEspecies)EditorGUILayout.EnumPopup("Especie", _especieScript.especie);
                                                         
        InspectorLines();

        // Nombre // Lo que hay dentro del cuadro          
        _especieScript.nombre = EditorGUILayout.TextField("Nombre","");


        _especieScript.habitat = EditorGUILayout.TextField("Habitat", "");

        _especieScript.color = EditorGUILayout.ColorField("Color", _especieScript.color);

        switch (_especieScript.especie)
        {
            case EnumEspecies.Perro:
                {
                    _especieScript.buenOlfato = EditorGUILayout.Toggle("Buen Olfato?", _especieScript.buenOlfato);
                    _especieScript.ladrido = EditorGUILayout.TextField("Sonido al Ladrar", "");

                    break;
                }

            case EnumEspecies.Gato:
                {
                    _especieScript.garras = EditorGUILayout.Toggle("Garras Afuera?", _especieScript.garras);
                    _especieScript.maullido = EditorGUILayout.TextField("Sonido al maullar", "");
                    break;
                }

            case EnumEspecies.Cabra:
                {
                    _especieScript.cuernos = EditorGUILayout.Toggle("Tiene Cuernos?", _especieScript.cuernos);
                    _especieScript.equilibrio = EditorGUILayout.FloatField("Equilibrio al Escalar", _especieScript.equilibrio);

                    break;
                }

            case EnumEspecies.Vaca:
                {
                    _especieScript.manchas = EditorGUILayout.IntField("Cantidad De Manchas", _especieScript.manchas);
                    _especieScript.pezuñas = EditorGUILayout.Toggle("Tiene pezuñas?", _especieScript.pezuñas);
                    break;
                }

            case EnumEspecies.Cerdo:
                {
                    _especieScript.peso = EditorGUILayout.FloatField("Peso (Kg)", _especieScript.peso);
                    _especieScript.olfato = EditorGUILayout.FloatField("Olfato (intensidad)", _especieScript.olfato);
                    break;
                }

            case EnumEspecies.Pato:
                {
                    _especieScript.vuela = EditorGUILayout.Toggle("Puede volar?", _especieScript.vuela);
                    _especieScript.agresivo = EditorGUILayout.Toggle("Es agresivo?", _especieScript.agresivo);
                    break;
                }
        }    


    }


    private void InspectorLines()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField(InspectorWidthLines());
        EditorGUILayout.Space();
    }

    private string InspectorWidthLines()
    {

        string line = "";

        for(int i = 0; i < EditorGUIUtility.currentViewWidth; i++)
        {
            line += "-";
        }

        return line;

    }


}
