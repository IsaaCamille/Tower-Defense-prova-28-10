using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreArqueira : ITorreDano
{
    public string Nome { get; set; } // propriedade que armazena o nome da torre. Ela pode ser lida ou escrita por outras classes

    public TorreArqueira() //inicializa uma inst�ncia da torre. O nome da torre � definido como "Atiradora". Toda vez que uma nova torre arqueira for criada, ela ter� esse nome
    {
        Nome = "Atiradora";
    }

    public int Dano => 25; // retorna o valor fixo de 25. Esse valor representa o dano que a torre arqueira causa ao atacar inimigos

    public float Alcance => 2; // define o alcance da torre como 2. Isso significa que a torre s� pode atacar inimigos que estejam a uma dist�ncia de 2 ou menos


}
