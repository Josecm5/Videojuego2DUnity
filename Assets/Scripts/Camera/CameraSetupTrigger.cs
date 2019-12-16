using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetupTrigger : MonoBehaviour
{

    public float _xMin, _xMax, _yMin, _yMax;
    public CameraFollowPlayer _cameraFollowPlayer;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            _cameraFollowPlayer.XMinValue = _xMin;
            _cameraFollowPlayer.XMaxValue = _xMax;
            _cameraFollowPlayer.YMinValue = _yMin;
            _cameraFollowPlayer.YMaxValue = _yMax;
        }
    }
}
