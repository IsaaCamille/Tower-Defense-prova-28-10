using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelaGameOver : MonoBehaviour
{
    [SerializeField] private GameObject telaGameOver; // refer�ncia � tela de Game Over
    [SerializeField] private Button btnAssistirAnuncio; // bot�o para assistir ao an�ncio recompensado
    [SerializeField] private Button btnReiniciar; // bot�o para reiniciar o jogo

    private SpawnManager spawnManager;
    private LevelManager levelManager;
    private ADSManager adManager;
    private EnemyMoviment Enemy;

    public delegate void ShowAds();
    public static ShowAds showAds;

    private void Start()
    {
        // refer�ncias necess�rias
        spawnManager = FindObjectOfType<SpawnManager>();
        levelManager = FindObjectOfType<LevelManager>();

        // configura��es dos bot�es
        btnAssistirAnuncio.onClick.AddListener(AssistirAnuncioRecompensado);
        btnReiniciar.onClick.AddListener(OcultarGameOver);

        // garante que a tela est� desativada no in�cio
        telaGameOver.SetActive(false);
    }

    public void ExibirGameOver()
    {
        Time.timeScale = 0f; // pausa o jogo
        telaGameOver.SetActive(true); // ativa a tela de Game Over
    }

    private void AssistirAnuncioRecompensado()
    {
        RecompensadoDelegate();
        AdicionarMoedasRecompensa();
        OcultarGameOver();
    }

    private void AdicionarMoedasRecompensa()
    {
        levelManager.AdicionarMoeda(300); // por exemplo, adiciona moedas como recompensa
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