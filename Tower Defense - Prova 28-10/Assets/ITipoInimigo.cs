using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITipoInimigo //ela contém uma propriedade Nome usa para que qualquer classe possa implementar essa interface
{
    string Nome { get; } //A propriedade Nome serve para identificar o tipo de inimigo
}

