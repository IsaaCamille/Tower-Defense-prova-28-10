using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Update()
    {
        if (Vector2.Distance(alvo.position, transform.position) <= 0.1f)//Verifica se o inimigo chegou ao ponto atual (alvo) com base na distância. Se a distância for menor ou igual a 0.1, considera que o inimigo alcançou o ponto
        {
            caminhoIndex++;//Incrementa o índice (caminhoIndex) para ir ao próximo ponto.

            if (caminhoIndex == LevelManager.principal.caminho.Length)//Se o índice for igual ao número total de pontos (fim do caminho), o inimigo é destruído (removido da cena), e o número de inimigos vivos no SpawnManager é decrementado
            {
                spawnManager.inimigosVivos--;
                Destroy(gameObject);
                telaGameOver = FindObjectOfType<TelaGameOver>();
                telaGameOver.ExibirGameOver();
                return;
            }
            else
            {
                alvo = LevelManager.principal.caminho[caminhoIndex];//Se ainda houver pontos no caminho, o alvo é atualizado para o próximo pontos
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (alvo.position - transform.position).normalized; //Calcula a direção do movimento para o inimigo em relação ao ponto atual(alvo)

        rb.velocity = direction * velocidade;//Atualiza a velocidade do Rigidbody2D para mover o inimigo na direção calculada com base na velocidade definida
    }
}