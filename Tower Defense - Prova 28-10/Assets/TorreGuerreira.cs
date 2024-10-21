using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreGuerreira : ITorreDano
{
    public string Nome { get; set; } // propriedade que armazena o nome da torre. Ela pode ser lida ou escrita por outras classes

    public TorreGuerreira() //Inicializa uma inst�ncia da torre. O nome da torre � definido como "Pesada". Toda vez que uma nova torre guerreira for criada, ela ter� esse nome
    {
        Nome = "Pesada";
    }






}