using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Move : MonoBehaviour
{
    [SerializeField]
    private Vector3 a;
    private bool b = false;
    [SerializeField] private int count = 24;
    
    [SerializeField] private Text count_text;

   

    // Start is called before the first frame update
    void Start()
    {
       
       
        
    }
    // Update is called once per frame
    void Update()
    {
        if (count >= 0)
        {
            PlayerMove();
        }
        else
        {
            SceneManager.LoadScene("07.Scene7");
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "qur")
        {
            Debug.Log("벽에 부닥침");
            b = true;
            count += 1;
            count_text.text = count.ToString();
        }
        if (col.gameObject.tag == "boss")
        {
            Debug.Log("클리어");
            SceneManager.LoadScene("09.Scene8-2");
        }
    }
    void PlayerMove()
    {
        if (b)
        {
            Remove();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                a = this.transform.localPosition;
                transform.Translate(new Vector2(0, 40));
              
                    count -= 1;
                count_text.text = count.ToString();

            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                a = this.transform.localPosition;
                transform.Translate(new Vector2(0, -40));
                count -= 1;
                count_text.text = count.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                a = this.transform.localPosition;
                transform.Translate(new Vector2(40, 0)); 
                count -= 1;
                count_text.text = count.ToString();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                a = this.transform.localPosition;
                transform.Translate(new Vector2(-40, 0));
                count -= 1;
                count_text.text = count.ToString();
            }
        }
    }
    void Remove()
    {
        transform.localPosition = a;
        a = new Vector3(0, 0, 0);
        b = false;
    }
}
