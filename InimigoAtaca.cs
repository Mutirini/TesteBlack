using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoAtaca : MonoBehaviour
{
    float vel = 3f;
    public bool LiberaPerseguir = false;
    float Distancia;
    public Transform Jogador;
    bool Face = true;

    void Update()
    {
        Distancia = Vector2.Distance(this.transform.position, Jogador.transform.position);

        if((Jogador.transform.position.x > this.transform.position.x) && !Face)
        {
            Flip();
        }

        else if ((Jogador.transform.position.x < this.transform.position.x) && Face)
        {
            Flip();
        }

        /*if((LiberaPerseguir ==true) && Distancia > 4f && !Jogador.GetComponent<MovimentoPersonagem>().Face)
        {
            if(Jogador.transform.position.x < this.transform.position.x)
            {
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
            }

            else if (Jogador.transform.position.x > transform.position.x)
            {
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
            }
        }*/

    }

    void Flip()
    {
        Face = !Face;
        Vector3 escala = this.transform.localScale;
        escala.x *= -1;
        this.transform.localScale = escala;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LiberaPerseguir = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LiberaPerseguir = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
    }

}
