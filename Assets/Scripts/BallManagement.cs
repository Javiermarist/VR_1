using UnityEngine;

public class BallManagement : MonoBehaviour
{
    public int usedBalls = 0;

    private void OnTriggerEnter(Collider other)
    {
        BowlingBall ball = other.GetComponent<BowlingBall>();
        if (ball != null)
        {
            usedBalls++;
            ball.MarkAsUsed();
        }
    }
}