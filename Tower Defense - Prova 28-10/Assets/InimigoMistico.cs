using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMistico : MonoBehaviour, ITipoInimigo//implementa a interface ITipoInimigo
{
    public string Nome//retorna a string "Mitico". Isso significa que, sempre que chamar o nome do tipo de inimigo, o valor "Mitico" será retornado
    {
        get { return "Mitico"; }
    }
}