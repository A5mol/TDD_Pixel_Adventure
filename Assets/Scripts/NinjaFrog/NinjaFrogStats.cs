using System.Security.Cryptography;
using UnityEngine;

[System.Serializable]
public class NinjaFrogStats
{
    public int maxLives = 3;          
    public float speed = 5f;        
    public float jumpForce = 10f;    
    public int attackPower = 1;
    public int currentLives;
    public int attackRange = 1;

    public int energy;
    public int maxEnergy;
    

    //Valor entre 0 y 1
    public float reduccionDeDano = 0.5f;

    public NinjaFrogStats()
    {
        currentLives = maxLives;
        energy = maxEnergy;
    }

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
        return Mathf.Max(fuerza - attackPower, 0);;
    }

    //Devuelve true si en la pelea con ”p2”; resulto ganador. Falso en otro caso. Ganará quien tenga más fuerza
    public bool peleaCon(NinjaFrogStats p2)
    {
        return attackPower>p2.attackPower;
    }

    //Devuelve la fuerza de un personaje. No puede haber fuerzas negativas.
    float getFuerza()
    {
        return attackPower;
    }
    
    //Devuelve true si estas vivo. False en otro caso. El personaje estará vivo si tiene fuerza (fuerza  > 0) 
    public bool estaVivo()
    {
        return currentLives > 0;
    }
    
    // Devuelve true si tiene al menos 50 puntos de energía.
    public bool PuedeHacerAtaqueEspecial()
    {
        const int energiaRequerida = 50;
        if (energy >= energiaRequerida)
        {
            // Consumo de energía al hacer el ataque especial
            energy -= energiaRequerida;
            return true;
        }
        return false;
    }

}
