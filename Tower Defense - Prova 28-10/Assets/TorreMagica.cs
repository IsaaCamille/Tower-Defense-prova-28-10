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







}
