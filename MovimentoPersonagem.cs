using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{

    public bool Face = true;
    Transform Personagem;
    float Velocidade = 3f;
    float Forca = 7f;
    Rigidbody2D PersonagemRB;
    bool LiberaPulo = false;
    Animator Animacao;
    bool Vivo = true;
    public float TempoTornado = 2.0f;

    void Start()
    {
        Personagem = GetComponent<Transform>();
        PersonagemRB = GetComponent<Rigidbody2D>();
        Animacao = GetComponent<Animator>();
    }

    void Update()
    {

            TempoTornado += Time.deltaTime;


        if (TempoTornado >= 5f)
        {
            TempoTornado = 5f;
        }

        if (Vivo == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !Face && !(Input.GetKey(KeyCode.LeftArrow)))
            {
                Flip();
            }

            else if (Input.GetKey(KeyCode.LeftArrow) && Face && !(Input.GetKey(KeyCode.RightArrow)))
            {
                Flip();
            }
        }

        if (Vivo == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !(Input.GetKey(KeyCode.LeftArrow)))
            {
                transform.Translate(new Vector2(Velocidade * Time.deltaTime, 0));
                Animacao.SetBool("Idle", false);
                Animacao.SetBool("Andar", true);
            }

            else if (Input.GetKey(KeyCode.LeftArrow) && !(Input.GetKey(KeyCode.RightArrow)))
            {
                transform.Translate(new Vector2(-Velocidade * Time.deltaTime, 0));
                Animacao.SetBool("Idle", false);
                Animacao.SetBool("Andar", true);
            }

            else
            {
                Animacao.SetBool("Idle", true);
                Animacao.SetBool("Andar", false);
            }
        }

        if (Vivo == true)
        {

            if (Input.GetKeyDown(KeyCode.Space) && LiberaPulo == true)
            {
                PersonagemRB.AddForce(new Vector2(0, Forca), ForceMode2D.Impulse);
                Animacao.SetBool("Idle", false);
                Animacao.SetBool("Pular", true);
            }
        }



        if (Vivo == true)
        {
            if (Input.GetKeyDown(KeyCode.S) && Face == false && TempoTornado >= 5f)
            {
                GetComponent<InvocarHabilidade>().TornadoDireita();
                TempoTornado = 0f;

            }

            if (Input.GetKeyDown(KeyCode.S) && Face == true && TempoTornado >= 5f)
            {
                GetComponent<InvocarHabilidade>().TornadoEsquerda();
                TempoTornado = 0f;

            }
        }
    }

   void Flip()
    {
        Face = !Face;

        Vector3 escala = Personagem.localScale;
        escala.x *= -1;
        Personagem.localScale = escala;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            LiberaPulo = true;
            Animacao.SetBool("Pular", false);
            Animacao.SetBool("Idle", true);
        }

        if (collision.gameObject.CompareTag("Tronco"))
        {
            LiberaPulo = true;
            Animacao.SetBool("Pular", false);
            Animacao.SetBool("Idle", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            LiberaPulo = false;
        }
    }
}
