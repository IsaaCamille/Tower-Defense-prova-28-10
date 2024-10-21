using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITorreDano
{
    string Nome { get; set; } // Nome da torreta
    int Dano { get; } // Dano que a torreta pode causar
    float Alcance { get; } // Alcance da torreta
    void Atacar(IDamageble alvo); // Método para atacar um inimigo que implementa IDamageble
}