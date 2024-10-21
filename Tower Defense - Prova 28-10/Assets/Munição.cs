using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munição : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2d; //Responsável por aplicar a munição física (movimentação)
    [SerializeField] private float Velocidadetiro = 5f;//Definir a velocidade com que a munição se move em direção ao alvo
    private Transform alvo;//O alvo que a munição vai seguir
    private int dano; // O valor do dano que uma munição causará ao atingir o alvo, com base no tipo de torre que disparou a munição




}
