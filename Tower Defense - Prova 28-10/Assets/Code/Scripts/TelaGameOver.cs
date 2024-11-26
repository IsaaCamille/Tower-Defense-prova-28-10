using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaGameOver : MonoBehaviour
{
    [SerializeField] private GameObject telaGameOver; // referência à tela de Game Over
    [SerializeField] private Button btnAssistirAnuncio; // botão para assistir ao anúncio recompensado
    [SerializeField] private Button btnReiniciar; // botão para reiniciar o jogo

    private SpawnManager spawnManager;
    private LevelManager levelManager;
    private ADSManager adManager;
    private EnemyMoviment Enemy;

    public delegate void ShowAds();
    public static ShowAds showAds;

    private void Start()
    {
        // Referências necessárias
        spawnManager = FindObjectOfType<SpawnManager>();
        levelManager = FindObjectOfType<LevelManager>();

        // Configurações dos botões
        btnAssistirAnuncio.onClick.AddListener(AssistirAnuncioRecompensado);
        btnReiniciar.onClick.AddListener(OcultarGameOver);

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
        RecompensadoDelegate();
        AdicionarMoedasRecompensa();
        OcultarGameOver();
    }

    private void AdicionarMoedasRecompensa()
    {
        levelManager.AdicionarMoeda(300); // Por exemplo, adiciona moedas como recompensa.
    }

    private void OcultarGameOver()
    {
        Time.timeScale = 1f; // Retoma o jogo
        telaGameOver.SetActive(false); // Desativa a tela de Game Over
    }

    public void RecompensadoDelegate()
    {
        showAds?.Invoke();
    }
}