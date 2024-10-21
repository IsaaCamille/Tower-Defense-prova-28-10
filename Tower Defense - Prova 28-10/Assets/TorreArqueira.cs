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


}
