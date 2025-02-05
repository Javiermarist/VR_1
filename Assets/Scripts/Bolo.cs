using UnityEngine;

public class Bolo : MonoBehaviour
{
    public bool YaContado = false;
    
    public bool EstaCaido()
    {
        return Vector3.Dot(transform.up, Vector3.up) < 0.5f;
    }
}
