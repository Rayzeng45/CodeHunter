using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucarachin : MonoBehaviour, IDa�o
{
    [Header("Vida y Da�o")]
    [SerializeField] private float vida;
    public void TomarDa�o(float Da�o)
    {
        vida -= Da�o;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
