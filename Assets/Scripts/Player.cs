using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int llaves = 0;
    public float velocidad = 5.0f;

    public Text cantidadllaves;
    public Text Ganaste;
    public GameObject Puerta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-velocidad * Time.deltaTime , 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(velocidad * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, velocidad * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -velocidad * Time.deltaTime, 0);
        }

        if(llaves == 3) 
        {
            Destroy(Puerta);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) 
    {
        if(collision.gameObject.tag == "Llaves")
        {
            llaves++;
            cantidadllaves.text = "Llaves:" + llaves;
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "UPB" )
        {
            Ganaste.text = "Ganasteee :)";

        }
        if (collision.gameObject.tag == "Enemigos")
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


        //rebotar de las paredes
        if (collision.gameObject.tag == "Paredes")
        {
           
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(velocidad * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-velocidad * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -velocidad * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, velocidad * Time.deltaTime, 0);
            }
        }
    }
}
