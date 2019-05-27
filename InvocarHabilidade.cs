using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocarHabilidade : MonoBehaviour
{

    public GameObject Tornado;
    public GameObject TornadoEsq;
    public GameObject Arma;
    //public SliderJoint2D Slide;
    //public JointMotor2D Auxiliar;


    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(Tornado, new Vector2(Arma.transform.position.x, Arma.transform.position.y), Arma.transform.rotation);
        }
    }*/

    public void TornadoDireita()
    { 
            GameObject tor = Instantiate(Tornado, new Vector2(Arma.transform.position.x, Arma.transform.position.y), Arma.transform.rotation);
        // Auxiliar.motorSpeed = -8f;
        //Auxiliar2.maxMotorTorque = 10f;
        // Slide.motor = Auxiliar;
            Destroy(tor, 2f);

  

    }

     public void TornadoEsquerda()
     {
        GameObject tor = Instantiate(TornadoEsq, new Vector2(Arma.transform.position.x, Arma.transform.position.y), Arma.transform.rotation);
        // Auxiliar.motorSpeed = 8f;
        //Auxiliar2.maxMotorTorque = 10f;
        //Slide.motor = Auxiliar;
        Destroy(tor, 2f);
     }
}

