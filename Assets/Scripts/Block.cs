using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{       
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 20f;
    }

    void Update()
    {
        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
    }
}
