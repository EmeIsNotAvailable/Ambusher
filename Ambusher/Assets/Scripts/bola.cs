using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    // Start is called before the first frame update
    private float h = 1f;
    private float v = 1f;
    public float vel;
    public bool inplay = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime *vel/2 * h);
        transform.Translate(Vector2.up * Time.deltaTime*vel * v);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "vertical")
        {
            h = h * -1;
        }
        if (collision.gameObject.tag == "horizontal" )
        {
            v = v * -1;
        }
        if (collision.gameObject.tag == "bottom")
        {
            inplay = false;
            Destroy(this.gameObject);
        }
    }
}
