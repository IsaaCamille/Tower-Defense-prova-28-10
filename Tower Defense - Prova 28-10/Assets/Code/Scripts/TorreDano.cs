using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface que define o comportamento de torres que causam dano a monstros
public interface ITorreDano
{
    string Nome { get; set; } // Nome da torreta
    int Dano { get; } // Dano que a torreta pode causar
    float Alcance { get; } // Alcance da torreta
    void Atacar(IDamageble alvo); // Método para atacar um inimigo que implementa IDamagebleS
}