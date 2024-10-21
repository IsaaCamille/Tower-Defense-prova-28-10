using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [SerializeField] private GameObject[] prefabsInimigos; //Um array de prefabs de inimigos que ser�o instanciados no jogo
    [SerializeField] private int inimigosIniciais; //Define o n�mero inicial de inimigos por onda
    [SerializeField] private float inimigosPorSegundo = 0.5f; //Controla a taxa de spawn dos inimigos(quantos inimigos s�o gerados por segundo)
    [SerializeField] private float tempoEntreOndas = 5f;//Define quanto tempo esperar entre o fim de uma onda e o in�cio da pr�xima
    [SerializeField] private float fatorDeEscalaDeDificuldade = 0.75f;//Fator usado para escalar a dificuldade do jogo ao longo das ondas, aumentando a quantidade de inimigos

    private int ondaAtual = 1;//Controla o valor da onda atual
    private float tempoDesdeUltimoSpawn; // controla o tempo desde de que o ulyimo inimigo foi spawnado
    public int inimigosVivos = 0; //Contagem de inimigos vivos, que � aumenta sempre que um novo inimigo � spawnado e diminui quando um inimigo � destru�do
    private int inimigosParaSpawnar; //O n�mero de inimigos restantes que precisam ser spawnados em uma onda
    private bool spawnando = false; //verifica se tem inimigos spwnando




}
