using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munição : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2d; //Responsável por aplicar a munição física (movimentação)
    [SerializeField] private float Velocidadetiro = 5f;//Definir a velocidade com que a munição se move em direção ao alvo
    private Transform alvo;//O alvo que a munição vai seguir
    private int dano; // O valor do dano que uma munição causará ao atingir o alvo, com base no tipo de torre que disparou a munição

    public void DefinirAlvo(Transform _alvo)//Este método recebe um Transformcomo parâmetro(_alvo) e define uma variável alvo para que a munição saiba em qual direção seguir
    {
        alvo = _alvo;
    }

 
    public void DefinirDano(int _dano)// Define o valor do dano que a munição vai causar ao atingir o inimigo 
    {
        dano = _dano;
    }

    private void FixedUpdate()//O método FixedUpdate() é usado para atualizar a física do objeto, sendo chamado em intervalos de tempo fixos
    {   //Este método verifica se há um alvo (alvo). Se não houver, o método retorna e não executa mais código
        if (!alvo) return;

       
        Vector2 direcao = (alvo.position - transform.position).normalized;
        rigidbody2d.velocity = direcao * Velocidadetiro;//O rigidbody2d.velocity é atualizado com essa nova direção, o que movimenta o projétil fisicamente em direção ao alvo
    }

    private void OnCollisionEnter2D(Collision2D collision)// A função dele é verificar se o objeto com o qual o projétil colidiu é um inimigo e caso seja, aplicar dano
    {
        Debug.Log("Colidiu com: " + collision.gameObject.name);  // Verifica o objeto com o qual colidiu

        IDamageble inimigo = collision.gameObject.GetComponent<IDamageble>();//Verifica se o objeto colidido implementa a interface IDamageble. Se sim, isso significa que ele é um inimigo e pode receber dano
        if (inimigo != null)
        {
            print("acionou");
            inimigo.TakeDamage(dano);//Chama o método TakeDamage do inimigo, passando o valor de dano como argumento. Isso aplica o dano ao inimigo
                Destroy(gameObject); //Destrói o projétil após a colisão, removendo-o da cena
        }


    }

   
}