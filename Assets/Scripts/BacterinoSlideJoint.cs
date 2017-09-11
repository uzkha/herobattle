using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacterinoSlideJoint : MonoBehaviour {

    private SliderJoint2D bacterino;
    private JointMotor2D aux;

    // Use this for initialization
    void Start()
    {

        bacterino = GetComponent<SliderJoint2D>();
        aux = bacterino.motor;

    }

    // Update is called once per frame
    void Update()
    {

        if (bacterino.limitState == JointLimitState2D.UpperLimit)
        {
            aux.motorSpeed = Random.Range(-1, -5);
            bacterino.motor = aux;
        }

        if (bacterino.limitState == JointLimitState2D.LowerLimit)
        {
            aux.motorSpeed = Random.Range(1, 5);
            bacterino.motor = aux;
        }

    }
}
