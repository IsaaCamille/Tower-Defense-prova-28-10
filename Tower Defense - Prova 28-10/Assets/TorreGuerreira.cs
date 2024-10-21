using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreGuerreira : ITorreDano
{
    public string Nome { get; set; } // propriedade que armazena o nome da torre. Ela pode ser lida ou escrita por outras classes

    public TorreGuerreira() //Inicializa uma instância da torre. O nome da torre é definido como "Pesada". Toda vez que uma nova torre guerreira for criada, ela terá esse nome
    {
        Nome = "Pesada";
    }

    public int Dano => 50; // Retorna o valor fixo de 50. Esse valor representa o dano que a torre guerreira causa ao atacar inimigos

    public float Alcance => 2f; // A torre só pode atacar inimigos que estejam a uma distância de 2 ou menos


    public void Atacar(IDamageble alvo) //Esse é o método principal da torre, que recebe como parâmetro um inimigo (alvo), que deve implementar uma interface IDamageble
    {
        if (alvo != null) //O método primeiro verifica se o alvo é válido (ou seja, se não é null)
        {
            Debug.Log($"{Nome} ataca o inimigo com {Dano} de dano."); //Se o alvo for válido, ele registra no console uma mensagem que a torre está atacando o inimigo com o valor de Dano

            alvo.TakeDamage(Dano); // o método chama o TakeDamage(Dano)no alvo, o que aplica o dano ao inimigo
        }
    }


}
