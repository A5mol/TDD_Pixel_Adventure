using System.Security.Cryptography;
using UnityEngine;

[System.Serializable]
public class NinjaFrogStats
{
    public int maxLives = 3;          
    public float speed = 5f;        
    public float jumpForce = 10f;    
    public int attackPower = 1;
    public int currentLives = 3;

    public int attackRange = 1;

    public int energia = 50;

    //Valor entre 0 y 1
    public float reduccionDeDano = 0.5f;

    public bool CanAttack(int attackPower, int attackRange)
    {
        if (attackPower > 0 && attackRange > 0)
        {
            return true;
        }
        return false;
    }

    //Devuelve la cantidad de vida que perdemos al dar un puñetazo con intensidad “fuerza”
    public int darPuñetazo(int fuerza)
    {
        return (int)(fuerza*reduccionDeDano);
    }

    //Devuelve true si en la pelea con ”p2”; resulto ganador. Falso en otro caso. Ganará quien tenga más fuerza
    bool peleaCon(NinjaFrogStats p2)
    {
        return p2.maxLives/(attackPower*p2.reduccionDeDano) > maxLives/(p2.attackPower*reduccionDeDano);
    }

    //Devuelve la fuerza de un personaje. No puede haber fuerzas negativas.
    float getFuerza()
    {
        return attackPower;
    }
    
    //Devuelve true si estas vivo. False en otro caso. El personaje estará vivo si tiene fuerza (fuerza  > 0) 
    bool estaVivo()
    {
        return currentLives > 0;
    }
    
    // Devuelve true si tiene al menos 50 puntos de energía.
    bool PuedeHacerAtaqueEspecial()
    {
        return energia >= 50;
    }

}
