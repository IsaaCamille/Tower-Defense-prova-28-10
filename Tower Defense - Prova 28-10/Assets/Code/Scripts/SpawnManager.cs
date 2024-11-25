using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class SpawnManager : MonoBehaviour //Classe criada para gerenciar o surgimento dos inimigos
{
    public static SpawnManager instance;
    public ADSManager ADSManager;

    [SerializeField] private GameObject[] prefabsInimigos; //Um array de prefabs de inimigos que serão instanciados no jogo
    [SerializeField] private int inimigosIniciais; //Define o número inicial de inimigos por onda
    [SerializeField] private float inimigosPorSegundo = 0.5f; //Controla a taxa de spawn dos inimigos(quantos inimigos são gerados por segundo)
    [SerializeField] private float tempoEntreOndas = 5f;//Define quanto tempo esperar entre o fim de uma onda e o início da próxima
    [SerializeField] private float fatorDeEscalaDeDificuldade = 0.75f;//Fator usado para escalar a dificuldade do jogo ao longo das ondas, aumentando a quantidade de inimigos

    private int ondaAtual = 1;//Controla o valor da onda atual
    private float tempoDesdeUltimoSpawn; // controla o tempo desde de que o ulyimo inimigo foi spawnado
    public int inimigosVivos = 0; //Contagem de inimigos vivos, que é aumenta sempre que um novo inimigo é spawnado e diminui quando um inimigo é destruído
    private int inimigosParaSpawnar; //O número de inimigos restantes que precisam ser spawnados em uma onda
    private bool spawnando = false; //verifica se tem inimigos spwnando


    private void Awake() //Define a instância do SpawnManager, permitindo que outras partes do jogo o acessem
    {
        instance = this;
    }
    private void Start()//Inicializa o número de inimigos vivos com zero e inicia a primeira onda de inimigos chamando a Coroutine IniciarOnda()
    {
        inimigosVivos = 0;
        StartCoroutine(IniciarOnda());
    }

    private void Update()
    {
        if (!spawnando) return;
        tempoDesdeUltimoSpawn += Time.deltaTime;

        if (tempoDesdeUltimoSpawn >= (1f / inimigosPorSegundo) && inimigosParaSpawnar > 0)
        {
            SpawnInimigo();
            inimigosParaSpawnar--;
            inimigosVivos++;
            tempoDesdeUltimoSpawn = 0f;
        }

        if (inimigosVivos <= 0 && inimigosParaSpawnar == 0)
        {
            FimDaOnda();
        }

        //ele continua spawnando inimigos com base no tempo (inimigosPorSegundo). A cada spawn, decrementa inimigosParaSpawnar, incrementa inimigosVivos, e reseta o contador tempoDesdeUltimoSpawn
    }

    public void InimigoDestruido()//Método chamado quando um inimigo é destruído, diminuindo o contador de inimigos vivos
    {
        inimigosVivos--;
    }

    public void SpawnInimigo() //Instancia um prefab de inimigo aleatório na posição inicial definida pelo LevelManager
    {
        GameObject prefabToSpawn = prefabsInimigos[Random.Range(0, prefabsInimigos.Length)];
        Instantiate(prefabToSpawn, LevelManager.principal.pontoInicial.position, Quaternion.identity);
    }

    private IEnumerator IniciarOnda()// espera um tempo (tempoEntreOndas), antes de começar a gerar inimigos para a nova onda. Também calcula quantos inimigos serão spawnados usando InimigosPorOnda()
    {
        yield return new WaitForSeconds(tempoEntreOndas);
        spawnando = true;
        inimigosParaSpawnar = InimigosPorOnda();

    }

    private int InimigosPorOnda()//Retorna o número de inimigos que serão gerados em uma onda. O cálculo usa uma fórmula que escala com o número da onda e o fator de dificuldade
    {
        return Mathf.RoundToInt(inimigosIniciais * Mathf.Pow(ondaAtual, fatorDeEscalaDeDificuldade));
    }

    private void FimDaOnda()//Finaliza a onda atual, reseta o contador de spawn e inicia a próxima onda, aumentando o número da onda
    {
        spawnando = false;
        tempoDesdeUltimoSpawn = 0f;
        ADSManager = FindObjectOfType<ADSManager>();
        ADSManager.ShowAd();
        ondaAtual++;
        StartCoroutine(IniciarOnda());
    }
    
}