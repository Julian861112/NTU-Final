using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {
    
    public Body next;

    public void Move(Vector3 pos){
        Vector3 NextPos = transform.position;

        transform.position = pos;

        if (next !=null){

            next.Move(NextPos);
        }

    }


}
