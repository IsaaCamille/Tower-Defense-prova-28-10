using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe para os inimigos
public class Monster : MonoBehaviour, IDamageble
{
    public int vidaAtual = 100;  // Valor inicial da vida do monstro

    // Implementa o método da interface IDamageble
    public void TakeDamage(int dano) //A função desse método é subtrair o valor de dano da vida
    {
        vidaAtual -= dano; // a vida do inimigo é reduzida pela quantidade de dano recebido

        Debug.Log("Inimigo tomou dano: " + dano + ", Vida restante: " + vidaAtual); //a quantidade de dano que o inimigo acabou de receber(dano)
                                                                                    //a quantidade de vida restante do inimigo(vidaAtual)

        if (vidaAtual <= 0) //O método verifica se a vida atual do inimigo(vidaAtual) é menor ou igual a 0.Se for,significa que o inimigo não tem mais vida suficiente para continuar no jogo
        {
            Morrer();  // Chama o método Morrer quando a vida chegar a zero
        }
    }

    private void Morrer()//O metodo Morrer lida com a remoção do inimigo do jogo, como a destruição do objeto
    {
        SpawnManager.instance.InimigoDestruido();
        Debug.Log("Inimigo morreu!");  // Mensagem para confirmar a morte
        Destroy(gameObject);  // Destrói o inimigo
    }

}
