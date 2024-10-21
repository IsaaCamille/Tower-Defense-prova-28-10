using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoFogo : MonoBehaviour, ITipoInimigo//implementa a interface ITipoInimigo.
{
    public string Nome
    {
        get
        {
            return "Fogo"; // Sempre que chamar o nome do tipo de inimigo, o valor "Fogo" será retornado
        }
    }
}