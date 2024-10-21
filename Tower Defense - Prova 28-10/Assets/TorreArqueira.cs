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


}
