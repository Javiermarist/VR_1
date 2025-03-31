using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallStand : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    public Transform spawnPoint;
    private List<GameObject> ballsInStand = new List<GameObject>();
    private bool hasStarted = false;

    private void Start()
    {
        StartCoroutine(SpawnInitialBalls());
    }

    private IEnumerator SpawnInitialBalls()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnBall();
            yield return new WaitForSeconds(2f);
        }
        hasStarted = true;
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
        if (!hasStarted) return;

        if (ballsInStand.Count < 3) 
        {
            StartCoroutine(SpawnBallWithDelay());
        }
    }

    private IEnumerator SpawnBallWithDelay()
    {
        yield return new WaitForSeconds(1f);
        if (ballsInStand.Count < 3)
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