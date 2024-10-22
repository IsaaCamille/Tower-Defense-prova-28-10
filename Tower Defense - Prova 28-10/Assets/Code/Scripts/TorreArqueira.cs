using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Classe TorreArqueira : Defina uma torre mágica

public class TorreArqueira : ITorreDano
{
    public string Nome { get; set; } // propriedade que armazena o nome da torre. Ela pode ser lida ou escrita por outras classes

    public TorreArqueira() //inicializa uma instância da torre. O nome da torre é definido como "Atiradora". Toda vez que uma nova torre arqueira for criada, ela terá esse nome
    {
        Nome = "Atiradora";
    }
    public int Dano => 25; // retorna o valor fixo de 25. Esse valor representa o dano que a torre arqueira causa ao atacar inimigos
    public float Alcance => 2; // define o alcance da torre como 2. Isso significa que a torre só pode atacar inimigos que estejam a uma distância de 2 ou menos

    public void Atacar(IDamageble alvo) //Esse é o método principal da torre, que recebe como parâmetro um inimigo ( alvo), que deve implementar uma interface IDamageble
    {
        if (alvo != null) //O método primeiro verifica se o alvo é válido (ou seja, se não é null)
        {
            Debug.Log($"{Nome} ataca o inimigo com {Dano} de dano."); //Se o alvo for válido, ele registra no console (Debug.Log) uma mensagem que a torre está atacando o inimigo com o valor de Dano

            alvo.TakeDamage(Dano); //Em seguida, o método chama o TakeDamage(Dano)no alvo, o que aplica o dano ao inimigo
        }
    }

    
}

