using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{

    [Header("Punto a teletransportarse")]
    public Transform _teleportPoint;

    private void Awake()
    {
        Debug.Assert(_teleportPoint != null, "Falta asignar la referencia _teleportPoint", this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            collider2D.transform.position = _teleportPoint.position;
        }
    }
}
