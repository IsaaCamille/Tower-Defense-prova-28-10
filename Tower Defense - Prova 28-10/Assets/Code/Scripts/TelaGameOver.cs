using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaGameOver : MonoBehaviour
{
    [SerializeField] private GameObject telaGameOver; // Referência à tela de Game Over.
    [SerializeField] private Button btnAssistirAnuncio; // Botão para assistir ao anúncio recompensado.
    [SerializeField] private Button btnReiniciar; // Botão para reiniciar o jogo.

    private SpawnManager spawnManager;
    private LevelManager levelManager;
    private ADSManager adManager;
    private EnemyMoviment Enemy;

    private void Start()
    {
        // Referências necessárias
        spawnManager = FindObjectOfType<SpawnManager>();
        levelManager = FindObjectOfType<LevelManager>();

        // Configurações dos botões
        btnAssistirAnuncio.onClick.AddListener(AssistirAnuncioRecompensado);
        btnReiniciar.onClick.AddListener(ReiniciarJogo);

        // Garante que a tela está desativada no início
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
        adManager.ShowRewarded(); // Usa o delegate para exibir o anúncio recompensado.
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