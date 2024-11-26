using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaGameOver : MonoBehaviour
{
    [SerializeField] private GameObject telaGameOver; // Refer�ncia � tela de Game Over.
    [SerializeField] private Button btnAssistirAnuncio; // Bot�o para assistir ao an�ncio recompensado.
    [SerializeField] private Button btnReiniciar; // Bot�o para reiniciar o jogo.

    private SpawnManager spawnManager;
    private LevelManager levelManager;
    private ADSManager adManager;
    private EnemyMoviment Enemy;

    private void Start()
    {
        // Refer�ncias necess�rias
        spawnManager = FindObjectOfType<SpawnManager>();
        levelManager = FindObjectOfType<LevelManager>();

        // Configura��es dos bot�es
        btnAssistirAnuncio.onClick.AddListener(AssistirAnuncioRecompensado);
        btnReiniciar.onClick.AddListener(ReiniciarJogo);

        // Garante que a tela est� desativada no in�cio
        telaGameOver.SetActive(false);
    }

    public void ExibirGameOver()
    {
        Time.timeScale = 0f; // Pausa o jogo
        telaGameOver.SetActive(true); // Ativa a tela de Game Over
    }

    private void AssistirAnuncioRecompensado()
    {
        adManager = FindObjectOfType<ADSManager>();
        adManager.ShowRewarded(); // Usa o delegate para exibir o an�ncio recompensado.
        AdicionarMoedasRecompensa();
        OcultarGameOver();
    }

    private void AdicionarMoedasRecompensa()
    {
        levelManager.AdicionarMoeda(300); // Por exemplo, adiciona moedas como recompensa.
    }

    private void ReiniciarJogo()
    {
        Time.timeScale = 1f; // Retoma o jogo
        telaGameOver.SetActive(false); // Oculta a tela de Game Over
    }

    private void OcultarGameOver()
    {
        Time.timeScale = 1f; // Retoma o jogo
        telaGameOver.SetActive(false); // Desativa a tela de Game Over
    }
}