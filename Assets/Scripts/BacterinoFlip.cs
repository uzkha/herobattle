using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacterinoFlip : MonoBehaviour {

    public Transform bacterino;

    // Use this for initialization
    void Start () {

        bacterino = gameObject.GetComponent<Transform>();

        //flip
        Vector3 scala = bacterino.localScale;
        scala.x *= -1;
        bacterino.localScale = scala;


    }


}
