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






}
