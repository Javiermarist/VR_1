using UnityEngine;
using System.Collections;

public class BowlingBall : MonoBehaviour
{
    private Rigidbody rb;
    private bool isUsed = false;
    public float destroyDelay = 3f;
    
    public AudioSource audioPins;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MarkAsUsed()
    {
        if (!isUsed)
        {
            isUsed = true;
            StartCoroutine(CheckBallStopped());
        }
    }

    private IEnumerator CheckBallStopped()
    {
        while (rb.linearVelocity.magnitude > 0.05f)
        {
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pin"))
        {
            print("Play audio");
            audioPins.Play();
        }
    }
}
