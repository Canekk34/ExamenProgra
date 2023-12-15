using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Canek
{
    public class SpawnCanek : MonoBehaviour
    {
        [Header("Variables")]

        [Tooltip("Aqui se coloca la informacion de las rondas")]
        [SerializeField] private SpawnData[] spawnData;

        [Tooltip("Aqui se guardan las coordenadas de los puntos donde pueden spawnear" +
            "los enemigos")]
        [SerializeField] private Transform[] spawnPoints;

        [Tooltip("Tiempo de descanso entre rondas")]
        [SerializeField] private float timeBetweenRounds;

        private int currentRound = 0;
        private List<GameObject> spawnedEnemies = new List<GameObject>();

        private void Start()
        {
            if (spawnData.Length < 5 || spawnPoints.Length < 10)
            {
                Debug.Log("El ciclo de rondas no puede comezar");
                return;
            }

            // Inicia el ciclo de rondas.
            StartCoroutine(Rondas());
        }

        private IEnumerator Rondas()
        {
            while (currentRound < spawnData.Length)
            {
                if (spawnedEnemies.Count > 0)
                {
                    // Destruye los enemigos de la ronda anterior.
                    foreach (var enemy in spawnedEnemies)
                    {
                        Destroy(enemy);
                    }
                    spawnedEnemies.Clear();
                }

                // Obtiene los datos de spawn para la ronda actual.
                SpawnData currentSpawnData = spawnData[currentRound];
                // Invoca la función SpawnEnemigos para crear enemigos en la ronda.
                yield return SpawnEnemigos(currentSpawnData);
                // Espera un tiempo entre rondas.
                yield return new WaitForSeconds(timeBetweenRounds);
                currentRound++;
            }
        }

        private IEnumerator SpawnEnemigos(SpawnData roundData)
        {
            for (int i = 0; i < roundData.amount; i++)
            {
                // Selecciona un punto de spawn al azar.
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                // Selecciona un enemigo al azar de la lista de enemigos disponibles.
                GameObject enemyPrefab = roundData.enemies[Random.Range(0, roundData.enemies.Length)];
                // Instancia el enemigo en el punto de spawn y lo añade a la lista de enemigos spawneados.
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                spawnedEnemies.Add(enemy); // Agrega el enemigo a la lista de enemigos spawneados.

                // Espera un tiempo antes de instanciar el siguiente enemigo.
                yield return new WaitForSeconds(roundData.spawnRate);
            }
        }
    }
}
