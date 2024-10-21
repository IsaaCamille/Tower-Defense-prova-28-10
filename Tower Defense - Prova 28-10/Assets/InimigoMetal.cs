using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMetal : MonoBehaviour, ITipoInimigo//implementa a interface ITipoInimigo
{
    public string Nome//retorna a string "Metal". Isso significa que sempre que chamar o nome do tipo de inimigo, o valor "Metal" será retornado
    {
        get { return "Metal"; }
    }
}
