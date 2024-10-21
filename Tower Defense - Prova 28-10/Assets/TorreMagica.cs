using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreMagica : ITorreDano
{
    public string Nome { get; set; } // propriedade que armazena o nome da torre. Ela pode ser lida ou escrita por outras classes

    public TorreMagica() //Inicializa uma inst�ncia da torre. O nome da torre � definido como "Mitica". Toda vez que uma nova torre m�gica for criada, ela ter� esse nome
    {
        Nome = "Mitica";
    }

    public int Dano => 35; //retorna o valor fixo de 25. Esse valor representa o dano que a torre m�gica causa ao atacar inimigos
    public float Alcance => 2f; // define o alcance da torre como 2. Isso significa que a torre s� pode atacar inimigos que estejam a uma dist�ncia de 2 ou menos





}
