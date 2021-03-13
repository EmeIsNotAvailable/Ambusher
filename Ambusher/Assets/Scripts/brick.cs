using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bola")
        {
            Destroy(this.gameObject);
            Debug.Log("Me cago en mis muertos");
        }
    }

}
