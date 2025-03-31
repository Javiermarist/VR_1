using System.Collections;
using UnityEngine;

public class DeleteBall : MonoBehaviour
{
    private BallManagement ballManagement;

    private void Start()
    {
        ballManagement = FindObjectOfType<BallManagement>(); // Busca el BallManagement en la escena
        if (ballManagement == null)
        {
            Debug.LogError("BallManagement NO encontrado en la escena.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UsedBall")) // Comprueba que la bola tiene el tag "UsedBall"
        {
            Debug.Log("Bola con tag 'UsedBall' ha entrado en el trigger para eliminarse: " + other.name);
            StartCoroutine(DestroyObject(other.gameObject));
        }
        else
        {
            Debug.Log("Objeto entró en el trigger pero no tiene el tag 'UsedBall': " + other.name);
        }
    }

    private IEnumerator DestroyObject(GameObject obj)
    {
        yield return new WaitForSeconds(3f);
        if (obj != null)
        {
            Debug.Log("Destruyendo bola: " + obj.name);
            Destroy(obj);
            ballManagement.OnBallDeleted(); // Avisar a BallManagement
        }
    }
}