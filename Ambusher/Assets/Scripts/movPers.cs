using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPers : MonoBehaviour
{
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * Time.deltaTime * vel);
        float v = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * v * Time.deltaTime * vel);
    }
}
