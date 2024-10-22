using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe para os inimigos
public class Monster : MonoBehaviour, IDamageble
{
    public int vidaAtual = 100;  // Valor inicial da vida do monstro

    // Implementa o m�todo da interface IDamageble
    public void TakeDamage(int dano) //A fun��o desse m�todo � subtrair o valor de dano da vida
    {
        vidaAtual -= dano; // a vida do inimigo � reduzida pela quantidade de dano recebido

        Debug.Log("Inimigo tomou dano: " + dano + ", Vida restante: " + vidaAtual); //a quantidade de dano que o inimigo acabou de receber(dano)
                                                                                    //a quantidade de vida restante do inimigo(vidaAtual)

        if (vidaAtual <= 0) //O m�todo verifica se a vida atual do inimigo(vidaAtual) � menor ou igual a 0.Se for,significa que o inimigo n�o tem mais vida suficiente para continuar no jogo
        {
            Morrer();  // Chama o m�todo Morrer quando a vida chegar a zero
        }
    }

    private void Morrer()//O metodo Morrer lida com a remo��o do inimigo do jogo, como a destrui��o do objeto
    {
        SpawnManager.instance.InimigoDestruido();
        Debug.Log("Inimigo morreu!");  // Mensagem para confirmar a morte
        Destroy(gameObject);  // Destr�i o inimigo
    }

}
