using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager principal;//Armazena uma instância estática do LevelManager, permitindo que outras classes acessem facilmente as informações do nível
    public Transform pontoInicial;//Representa o ponto inicial do caminho, ou seja, o local onde os inimigos começam a se mover
    public Transform[] caminho;//Um array de Transform que define o caminho que os inimigos devem seguir, com cada elemento representando um waypoint




}
