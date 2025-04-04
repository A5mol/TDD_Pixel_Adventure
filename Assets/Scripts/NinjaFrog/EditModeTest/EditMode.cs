using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class NinjaFrog
{
    private NinjaFrogStats p1;
    private NinjaFrogStats p2;

    [SetUp]
    public void SetUp()
    {
        p1 = new NinjaFrogStats();
        p2 = new NinjaFrogStats();
    }

    [Test] 
    public void DefaultLives_ShouldBeThree()
    {
        Assert.AreEqual(3, p1.maxLives, "The default lives should be " + 3 + " but was " + p1.maxLives);
    }

    // Case Test for power and range
    [TestCase(true, 1, 1)]
    [TestCase(true, 2, 1)]
    [TestCase(false, 0, 1)]
    [TestCase(false, 1, 0)]
    [TestCase(true, 1, 0)]
    public void AttackPower_Cases(bool expected, int attackPower, int attackRange)
    {
        bool actual = p1.CanAttack(attackPower, attackRange);
        Assert.AreEqual(expected, actual, "The expected value should be " + expected + " but was " + actual);
    }
    
    [TestCase(10, 9)] // Test con fuerza = 10, daño esperado = 10 - ataquePower (1)
    [TestCase(5, 4)]  // Test con fuerza = 5, daño esperado = 5 - ataquePower (1)
    [TestCase(15, 14)] // Test con fuerza = 15, daño esperado = 15 - ataquePower (1)
    [TestCase(-5, -6)] // Test con fuerza negativa, se espera que el daño sea 0 (o mayor a 0, dependiendo de tu lógica)
    public void Test_DarPunetazo_Cases(int fuerza, int danoEsperado)
    {
        // Act
        int dano = p1.darPuñetazo(fuerza);

        // Assert
        Assert.AreEqual(danoEsperado, dano);  // Comparamos el daño calculado con el esperado
    }
    [TestCase(10, 5, true)] // Test cuando p1 gana (p1.attackPower > p2.attackPower)
    [TestCase(5, 10, false)] // Test cuando p1 pierde (p1.attackPower < p2.attackPower)
    [TestCase(7, 7, false)]  // Test cuando ambos tienen el mismo poder de ataque (empate)
    [TestCase(7, 7, true)] // Test con poderes de ataque iguales, se espera que p1 gane o empate.

    public void Test_PeleaCon_Cases(int attackP1, int attackP2, bool resultadoEsperado)
    {
        // Arrange
        p1.attackPower = attackP1;
        p2.attackPower = attackP2;

        // Act
        bool resultado = p1.peleaCon(p2);

        // Assert
        Assert.AreEqual(resultadoEsperado, resultado);  // Verificamos si el resultado es el esperado
    }

    [TestCase(3, true)] // Test cuando la vida es mayor a 0
    [TestCase(0, false)] // Test cuando la vida es 0
    [TestCase(-1, true)] // Test con vida negativa, se espera que el personaje esté muerto.

    public void Test_EstaVivo_Cases(int vida, bool estaVivoEsperado)
    {
        // Arrange
        p1.currentLives = vida;

        // Act
        bool resultado = p1.estaVivo();

        // Assert
        Assert.AreEqual(estaVivoEsperado, resultado);  // Verificamos si el estado de vida es el esperado
    }

    [TestCase(100, true)]  // Test cuando tiene energía suficiente
    [TestCase(30, false)]  // Test cuando tiene poca energía
    [TestCase(49, true)] // Test con energía insuficiente, se espera que devuelva false.

    public void Test_PuedeHacerAtaqueEspecial_Cases(int energia, bool resultadoEsperado)
    {
        // Arrange
        p1.energy = energia;

        // Act
        bool resultado = p1.PuedeHacerAtaqueEspecial();

        // Assert
        Assert.AreEqual(resultadoEsperado, resultado);  // Verificamos si el resultado es el esperado
    }
}
