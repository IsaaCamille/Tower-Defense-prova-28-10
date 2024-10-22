using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPedra : MonoBehaviour, ITipoInimigo//implementa a interface ITipoInimigo
{
    public string Nome//retorna a string "Pedra". Isso significa que, sempre que chamar o nome do tipo de inimigo, o valor "Pedra" será retornado
    {
        get { return "Pedra"; }
    }
}
