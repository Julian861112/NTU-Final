using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemGenerator : MonoBehaviour {
    public GameObject SnakePlayer;
    public GameObject food;
    public GameObject[] Item;


    public GameObject BorderLeft;
    public GameObject BorderRight;
    public GameObject BorderTop;
    public GameObject BorderBottom;
    public void GenerateItem(){

        int ItemIndex = Random.Range(0, Item.Length);

        int x = (int)Random.Range(BorderLeft.transform.position.x + 10, BorderRight.transform.position.x - 10);
        int y = (int)Random.Range(BorderBottom.transform.position.y + 10, BorderTop.transform.position.y - 10);


        Instantiate(Item[ItemIndex], new Vector2(x, y), Quaternion.identity);
        

    }
    void Start()
    {


        Instantiate(SnakePlayer,new Vector2(0,0),Quaternion.identity);
        InvokeRepeating("GenerateItem", 0, 1);


    }




}
