using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

//Classe TorreMagica : Defina uma torre m�gica

public class TorreMagica : ITorreDano
{
    public string Nome { get;  set; } // propriedade que armazena o nome da torre. Ela pode ser lida ou escrita por outras classes

    public TorreMagica() //Inicializa uma inst�ncia da torre. O nome da torre � definido como "Mitica". Toda vez que uma nova torre m�gica for criada, ela ter� esse nome
    {
        Nome = "Mitica";
    }
    public int Dano => 35; //retorna o valor fixo de 25. Esse valor representa o dano que a torre m�gica causa ao atacar inimigos
    public float Alcance => 2f; // define o alcance da torre como 2. Isso significa que a torre s� pode atacar inimigos que estejam a uma dist�ncia de 2 ou menos

    public void Atacar(IDamageble alvo) //Esse � o m�todo principal da torre, que recebe como par�metro um inimigo ( alvo), que deve implementar uma interface IDamageble
    {
        if (alvo != null) //O m�todo primeiro verifica se o alvo � v�lido (ou seja, se n�o � null)
        {
            Debug.Log($"{Nome} ataca o inimigo com {Dano} de dano."); //Se o alvo for v�lido, ele registra no console (Debug.Log) uma mensagem que a torre est� atacando o inimigo com o valor de Dano

            alvo.TakeDamage(Dano); // o m�todo chama o TakeDamage(Dano)no alvo, o que aplica o dano ao inimigo
        }
    }

}
