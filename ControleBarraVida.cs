using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleBarraVida : MonoBehaviour
{
    public Image BarraVida;
    public Text VidaTexto;
    public int ValorAtualVida = 150;
    public int Dano = 5; // remover depois isso ser exemplo
    public int Recuperar = 20;  // remover depois isso ser exemplo 
    int ValorMaximo = 150;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ReduzirVida();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            RecuperarVida();
        }

        AtualizaVida();
    }

    public void ReduzirVida()
    {
        if (ValorAtualVida > 0)
        {
            ValorAtualVida -= Dano;
            BarraVida.fillAmount = (float)ValorAtualVida / ValorMaximo;
            string MostraVida = ValorAtualVida.ToString();
            VidaTexto.text = MostraVida;
        }
    }

    public void RecuperarVida()
    {
        if (ValorAtualVida <= ValorMaximo && ValorAtualVida >=1)
        {
            ValorAtualVida += Recuperar;
            BarraVida.fillAmount = (float)ValorAtualVida / ValorMaximo;
            string MostraVida = ValorAtualVida.ToString();
            VidaTexto.text = MostraVida;
        }
    }

    void AtualizaVida()
    {
        if (ValorAtualVida >= ValorMaximo)
        {
            ValorAtualVida = ValorMaximo;
            VidaTexto.text = ValorAtualVida.ToString();
        }

        if (ValorAtualVida <= 0)
        {
            ValorAtualVida = 0;
            VidaTexto.text = ValorAtualVida.ToString();
        }
    }

}

