using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public List<Bolo> bolos;
    private int bolosCaidos = 0;
    
    void Update()
    {
        
    }
    int ContarBolosCaidos()
    {
        foreach (Bolo bolo in bolos)
        {
            if (bolo.EstaCaido() && !bolo.YaContado)
            {
                bolosCaidos++;
                bolo.YaContado = true;
            }
        }
        return bolosCaidos;
    }
}
