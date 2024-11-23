using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public static LevelManager principal;//Armazena uma inst�ncia est�tica do LevelManager, permitindo que outras classes acessem facilmente as informa��es do n�vel

    public Transform pontoInicial;//Representa o ponto inicial do caminho, ou seja, o local onde os inimigos come�am a se mover
    public Transform[] caminho;//Um array de Transform que define o caminho que os inimigos devem seguir, com cada elemento representando um waypoint

    public int moeda;
    public Text moedatexto;

    private void Awake()
    {
        principal = this;// garantir que a inst�ncia do LevelManager seja atribu�da � vari�vel est�tica principal. Isso estabelece um ponto de acesso global para o LevelManager, permitindo que outras partes do jogo acessem seus dados (como o caminho dos inimigos) sem precisar criar novas inst�ncias ou passar refer�ncias manualmente

    }

    private void Start()
    {
        moeda = 0;
       
    }
    public void AdicionarMoeda(int amount)
    {
        moeda += amount;
        moedatexto.text = "Moeda: " + moeda;
    }

    public bool DiminuirMoeda(int amount)
    {
        if (amount <= moeda)
        {
            moeda -= amount;
            return true;
        }
        else
        {
            Debug.Log("Saldo insuficiente");
            return false;
        }
    }


}