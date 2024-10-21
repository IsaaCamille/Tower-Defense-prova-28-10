using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreMagica : ITorreDano
{
    public string Nome { get; set; } // propriedade que armazena o nome da torre. Ela pode ser lida ou escrita por outras classes

    public TorreMagica() //Inicializa uma instância da torre. O nome da torre é definido como "Mitica". Toda vez que uma nova torre mágica for criada, ela terá esse nome
    {
        Nome = "Mitica";
    }

    public int Dano => 35; //retorna o valor fixo de 25. Esse valor representa o dano que a torre mágica causa ao atacar inimigos
    public float Alcance => 2f; // define o alcance da torre como 2. Isso significa que a torre só pode atacar inimigos que estejam a uma distância de 2 ou menos





}
