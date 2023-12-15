using System.Collections;
using UnityEngine;


namespace Alan0
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnTypes spawnType;

        [Header("Variables")]

        [Tooltip("Aqui se coloca la informacion de las rondas")]
        [SerializeField] private SpawnData[] spawnData;

        [Tooltip("Aqui se guardan las coordenadas de los puntos donde pueden spawnear" +
            "los enemigos")]
        [SerializeField] private Transform[] spawnPoints;

        [Tooltip("Tiempo de descanso entre rondas")]
        [SerializeField] private float timeBetweenRounds;

        /// <summary>
        /// EJERCICIO
        /// 
        /// Van a usar el arreglo de spawn data, para spawnear
        /// todos los enemigos que esten indicados en el scriptable object, 
        /// en el tiempo que indica.
        /// 
        /// Despues de haber spawneado todos los enemigos de esa ronda, se debe de esperar
        /// el tiempo indicado en timeBetweenRounds antes de comenzar la siguiente ronda.
        /// 
        /// Los enemigos que se van a spawnear, se deben de seleccionar de manera random, 
        /// usando el arreglo de enemigos del spawn data.
        /// 
        /// Y el enemigo, va a aparecer en un Spawn Point random de el arreglo de spawnPoints
        /// 
        /// 
        /// REGLAS:
        /// No se permite usar el Update, o FixedUpdate, o LateUpdate
        /// Tiene que haber informacion de al menos 5 rondas
        /// Minimo 10 spawnPoints 
        /// Y cada enemigo, debe ser diferente en modelo
        /// 
        /// Hacerlo dentro de su propia carpeta con una nueva escena
        /// Crear un codigo en un namespace distinto a este
        /// 
        /// Van a subir PDF con el codigo, y video de el spawn ya funcionando
        /// </summary>
        private void Start()
        {

        }

    }


    public enum SpawnTypes
    {

    }

}