using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Snake : MonoBehaviour {
    List<Transform> tail = new List<Transform>();


    public GameObject tailPrefab;
    public SpeedUp SpeedUp;
    private Body _Firstbody;
    private Body _Lastbody;
    Vector2 dir = Vector2.right;

    // Use this for initialization
    void Start()
    {
        // Move the Snake every 300ms
        InvokeRepeating("Move", 0, 0.3f);
    }


    void Update()
    {
        // Move in a new Direction?
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;    // '-up' means 'down'
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right; // '-right' means 'left'
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
    }
    public void Grow(){

        GameObject obj = Instantiate(tailPrefab, new Vector3(1000, 1000, 0), Quaternion.identity) as GameObject;
        Body b = obj.GetComponent<Body>();
        if (_Firstbody==null)
        {
            _Firstbody = b;

        }
        if (_Lastbody!=null)
        {
            _Lastbody.next = b;

        }
        _Lastbody = b;
    }

    void Move()
    {
        // Save current position (gap will be here)
        Vector3 nextPos = transform.position;
        // Move head into new direction
        transform.Translate(dir);
        // Do we have a Tail?
        if(_Firstbody!=null){
            _Firstbody.Move(nextPos);
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag=="Food")
        {
            
            print("Hit!");
            Grow();
            Destroy(coll.gameObject);

            ScoreScript.scoreValue += 1;
        }
        if (coll.tag=="Wall")
        {
            print("GG");
            Destroy(gameObject);
            Time.timeScale=0;

        }
        if (coll.tag=="SpeedUp")
        {
            print("Eat speed up");
            Destroy(coll.gameObject);
           
            Time.timeScale += 0.3f;

        }
        if (coll.tag=="slow down")
        {
            print("Eat slow down");
            Destroy(coll.gameObject);
            Time.timeScale -= 0.3f;
        }
        if (coll.tag=="2points")
        {
            Destroy(coll.gameObject);
            ScoreScript.scoreValue += 2;
        }

    }




}
