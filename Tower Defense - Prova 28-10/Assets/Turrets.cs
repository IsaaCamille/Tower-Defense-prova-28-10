using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    [SerializeField] private Transform pontoDeRotacaoDaTorre;//Provavelmente o ponto ao redor do qual a torre gira
    [SerializeField] private GameObject balaPrefab;//Prefab da bala (projetil) que a torre dispara
    [SerializeField] private Transform firePoint;//O local onde o projétil é instanciado, provavelmente o ponto na ponta da torre

    [SerializeField] private float tamanhoMira; // O alcance da torre, definindo o raio em que ela pode detectar inimigos
    [SerializeField] private float tps; // Tiros por segundo, controlando a frequência de disparo da torre
    [SerializeField] private float velocidadeDeRotacao = 5f;//Velocidade com que a torre gira para mirar no alvo

    private float tempoAteDisparo;//Usado para controlar o intervalo entre os tiros, contando o tempo desde o último disparo
    private Transform alvo;//Armazena a referência ao inimigo mais próximo, que será o alvo da torre
    ITorreDano Dano;//Interface que define o comportamento de dano da torre, permitindo a aplicação de dano ao inimigo

    // Configurações da torreta
    public ITorreDano tipoTorreta; // Instância da interface ITorreDano, que especifica o comportamento de ataque da torre
    public string tipoTorreAlvo; // Define o tipo de inimigo que a torre pode atacar (Arqueira, Pesada, Mágica)
    public string[] tipoInimigosPodeAtacar;









}
