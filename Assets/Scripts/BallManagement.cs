using UnityEngine;

public class BallManagement : MonoBehaviour
{
    public int usedBalls = 0;
    private int deletedBalls = 0;
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            Debug.LogError("GameController NO encontrado en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BowlingBall ball = other.GetComponent<BowlingBall>();
        if (ball != null)
        {
            usedBalls++;
            other.tag = "UsedBall";
            Debug.Log("Bola usada. Total usadas: " + usedBalls);
        }
    }

    public void OnBallDeleted()
    {
        deletedBalls++;
        Debug.Log("Bola eliminada. Total eliminadas: " + deletedBalls);

        if (usedBalls >= 2 && deletedBalls >= 2) 
        {
            Debug.Log("Ambas bolas eliminadas, cambiando de turno...");
            usedBalls = 0;
            deletedBalls = 0;
            gameController.NextTurn();
        }
        else if (gameController.fallenPins == 10) 
        {
            Debug.Log("Todos los pines caídos, cambiando de turno...");
            usedBalls = 0;
            deletedBalls = 0;
            gameController.NextTurn();
        }
    }
}