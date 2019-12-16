using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformConstrain : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.transform.position.y > this.transform.position.y)
        {
            _lastParent = collision.transform.parent;
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(_lastParent);
        }
    }

    private Transform _lastParent;
}
