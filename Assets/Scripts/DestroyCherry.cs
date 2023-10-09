using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCherry : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "JumpBase")
        {
            Destroy(col.collider.gameObject);
        }
    }
}
