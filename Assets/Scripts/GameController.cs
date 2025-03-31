using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int fallenPins = 0;
    public TextMeshProUGUI textFallenPins;
    public GameObject bowlingPinsPrefab; // Prefab de Bowling_Pins que contiene los bolos.
    public Transform spawnPoint;         // Punto donde instanciar el nuevo Bowling_Pins.
    
    private GameObject currentBowlingPins;  // Referencia al objeto Bowling_Pins actual

    private int currentTurn = 0;

    private void Start()
    {
        // Generar los bolos al principio
        SpawnBowlingPins();
        UpdateScoreText();  // Actualiza el texto del puntaje al inicio
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pin"))
        {
            fallenPins++;
            other.tag = "FallenPin"; // Cambiamos la etiqueta para evitar contarlos varias veces
            textFallenPins.text = "Turn: " + (currentTurn + 1) + "\n" + "Score: " + fallenPins;
        }
    }

    public void NextTurn()
    {
        // Incrementar el turno y reiniciar los pines solo si no hemos llegado al último turno
        if (currentTurn < 9) // Hasta el turno 10
        {
            currentTurn++;
            fallenPins = 0; // Reiniciar el contador de pines caídos
            textFallenPins.text = "Turn: " + (currentTurn + 1) + "\n" + "Score: " + fallenPins;

            // Eliminar el Bowling_Pins actual y generar uno nuevo
            Destroy(currentBowlingPins);  // Destruir el Bowling_Pins actual
            SpawnBowlingPins();  // Generar el Bowling_Pins con los bolos

            Debug.Log("Turno cambiado. Ahora en turno " + (currentTurn + 1));
        }
        else
        {
            Debug.Log("Juego terminado. Puntaje final: " + GetTotalScore());
        }

        UpdateScoreText();
    }

    private void SpawnBowlingPins()
    {
        // Instanciamos un nuevo Bowling_Pins con los bolos y rotación de -90 grados en X
        currentBowlingPins = Instantiate(bowlingPinsPrefab, spawnPoint.position, Quaternion.Euler(-90f, 0f, 0f));
    }

    private int GetTotalScore()
    {
        // Calculamos el puntaje total de acuerdo a las reglas de bolos.
        return fallenPins;
    }

    private void UpdateScoreText()
    {
        // Actualizamos el texto para reflejar el puntaje y turno actual
        textFallenPins.text = "Turn: " + (currentTurn + 1) + "\n" + "Score: " + fallenPins;
    }
}
