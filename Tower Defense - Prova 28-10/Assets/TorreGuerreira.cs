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






}
