using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallStand : MonoBehaviour
{
    public GameObject[] ballPrefabs; // Array de prefabs de bolas
    public Transform spawnPoint; // Punto donde se generarán nuevas bolas
    private List<GameObject> ballsInStand = new List<GameObject>(); // Lista de bolas en el soporte
    private bool hasStarted = false; // Para evitar que se generen 2 bolas al inicio

    private void Start()
    {
        // Forzamos la generación de una bola inicial
        SpawnBall();
        hasStarted = true; // A partir de aquí, el sistema de detección se activa
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BowlingBall")) 
        {
            if (!ballsInStand.Contains(other.gameObject))
            {
                ballsInStand.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BowlingBall")) 
        {
            ballsInStand.Remove(other.gameObject);
            CheckAndSpawnBall();
        }
    }

    private void CheckAndSpawnBall()
    {
        if (!hasStarted) return; // Evitar que se generen bolas antes de tiempo

        if (ballsInStand.Count < 3) 
        {
            StartCoroutine(SpawnBallWithDelay());
        }
    }

    private IEnumerator SpawnBallWithDelay()
    {
        yield return new WaitForSeconds(1f); // Pequeña pausa antes de generar
        if (ballsInStand.Count < 3) // Verificar nuevamente
        {
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefabs[Random.Range(0, ballPrefabs.Length)], spawnPoint.position, Quaternion.identity);
        ballsInStand.Add(newBall);
    }
}