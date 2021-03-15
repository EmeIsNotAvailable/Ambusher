using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class puerta : MonoBehaviour
{
    public bool ontrigger;
    public string levelName;
    public GameObject interaccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            ontrigger = true;
            interaccion.SetActive(true);

        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ontrigger = false;
            interaccion.SetActive(false);


        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && ontrigger)
        {
            SceneManager.LoadScene(levelName);

        }
    }
}
