using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoEspirito : MonoBehaviour, ITipoInimigo// A classe InimigoEspirito precisa fornecer as implementa��es dos membros definidos na interface ITipoInimigo
{
    public string Nome// Sempre que chamar o nome do tipo de inimigo, o valor "Espirito" ser� retornado
    {
        get { return "Espirito"; }
    }
}
