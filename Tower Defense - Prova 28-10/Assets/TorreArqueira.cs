using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreArqueira : ITorreDano
{
    public string Nome { get; set; } // propriedade que armazena o nome da torre. Ela pode ser lida ou escrita por outras classes

    public TorreArqueira() //inicializa uma instância da torre. O nome da torre é definido como "Atiradora". Toda vez que uma nova torre arqueira for criada, ela terá esse nome
    {
        Nome = "Atiradora";
    }

    public int Dano => 25; // retorna o valor fixo de 25. Esse valor representa o dano que a torre arqueira causa ao atacar inimigos

    public float Alcance => 2; // define o alcance da torre como 2. Isso significa que a torre só pode atacar inimigos que estejam a uma distância de 2 ou menos


}
