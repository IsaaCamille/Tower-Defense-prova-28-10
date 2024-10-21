using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;//Gerencia a física do inimigo, permitindo controlar sua velocidade e movimentação

    [SerializeField] private float velocidade = 2f;//Define a velocidade com que o inimigo se movimenta no caminho

    private Transform alvo;//Representa o ponto atual para onde o inimigo está se movendo
    private int caminhoIndex = 0;// Índice que acompanha em qual ponto do caminho o inimigo está
    SpawnManager spawnManager;//Referência ao sistema de spawn de inimigos, usado para atualizar a contagem de inimigos vivos

    private void Start()
    {
        alvo = LevelManager.principal.caminho[caminhoIndex];// Inicializa o alvo do inimigo com o primeiro ponto do caminho(caminhoIndex = 0), obtendo essa informação do LevelManager
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();//Busca uma referência para o SpawnManager, que gerencia a contagem de inimigos vivos no nível
    }





}
