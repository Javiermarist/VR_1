using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int fallenPins = 0;
    public TextMeshProUGUI textFallenPins;
    public TextMeshProUGUI textTotalScore;
    public GameObject bowlingPinsPrefab;
    public Transform spawnPoint;

    private GameObject currentBowlingPins;
    private int currentTurn = 0;
    private int totalScore = 0;

    private void Start()
    {
        SpawnBowlingPins();
        UpdateScoreText();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            fallenPins++;
            other.tag = "FallenPin";
            UpdateScoreText();
        }
    }

    public void NextTurn()
    {
        if (currentTurn < 9)
        {
            totalScore += fallenPins;
            currentTurn++;
            fallenPins = 0;

            Destroy(currentBowlingPins);
            SpawnBowlingPins();

            Debug.Log("Turno cambiado. Ahora en turno " + (currentTurn + 1));
        }
        else
        {
            totalScore += fallenPins;
            Debug.Log("Juego terminado. Puntaje final: " + totalScore);
        }

        UpdateScoreText();
    }

    private void SpawnBowlingPins()
    {
        currentBowlingPins = Instantiate(bowlingPinsPrefab, spawnPoint.position, Quaternion.Euler(-90f, 0f, 0f));
    }

    private void UpdateScoreText()
    {
        textFallenPins.text = "Turn: " + (currentTurn + 1) + "\n\nScore: " + fallenPins;
        textTotalScore.text = "Total Score: " + totalScore;
    }
}
