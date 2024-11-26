using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoviment : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;//Gerencia a f�sica do inimigo, permitindo controlar sua velocidade e movimenta��o

    [SerializeField] private float velocidade = 2f;//Define a velocidade com que o inimigo se movimenta no caminho

    private Transform alvo;//Representa o ponto atual para onde o inimigo est� se movendo
    private int caminhoIndex = 0;// �ndice que acompanha em qual ponto do caminho o inimigo est�
    SpawnManager spawnManager;//Refer�ncia ao sistema de spawn de inimigos, usado para atualizar a contagem de inimigos vivos

    private void Start()
    {
        alvo = LevelManager.principal.caminho[caminhoIndex];// Inicializa o alvo do inimigo com o primeiro ponto do caminho(caminhoIndex = 0), obtendo essa informa��o do LevelManager
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();//Busca uma refer�ncia para o SpawnManager, que gerencia a contagem de inimigos vivos no n�vel
    }

    private void Update()
    {
        if (Vector2.Distance(alvo.position, transform.position) <= 0.1f)//Verifica se o inimigo chegou ao ponto atual (alvo) com base na dist�ncia. Se a dist�ncia for menor ou igual a 0.1, considera que o inimigo alcan�ou o ponto
        {
            caminhoIndex++;//Incrementa o �ndice (caminhoIndex) para ir ao pr�ximo ponto.

            if (caminhoIndex == LevelManager.principal.caminho.Length)//Se o �ndice for igual ao n�mero total de pontos (fim do caminho), o inimigo � destru�do (removido da cena), e o n�mero de inimigos vivos no SpawnManager � decrementado
            {
                spawnManager.inimigosVivos--;
                Destroy(gameObject);
                telaGameOver = FindObjectOfType<TelaGameOver>();
                telaGameOver.ExibirGameOver();
                return;
            }
            else
            {
                alvo = LevelManager.principal.caminho[caminhoIndex];//Se ainda houver pontos no caminho, o alvo � atualizado para o pr�ximo pontos
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (alvo.position - transform.position).normalized; //Calcula a dire��o do movimento para o inimigo em rela��o ao ponto atual(alvo)

        rb.velocity = direction * velocidade;//Atualiza a velocidade do Rigidbody2D para mover o inimigo na dire��o calculada com base na velocidade definida
    }
}