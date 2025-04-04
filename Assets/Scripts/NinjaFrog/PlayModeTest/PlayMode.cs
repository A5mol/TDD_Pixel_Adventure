using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;

public class NinjaFrogMovementTest
{
    private GameObject NinjaFrog;
    private GameObject Ground;

    [SetUp]
    public void SetUp()
    {
        EditorSceneManager.LoadScene("SampleScene");
        Debug.Log("Scene Loaded");
    }
    [UnityTest]
    public IEnumerator NinjaFrogFall()
    {   
        yield return new WaitForSeconds(2);
        NinjaFrog = GameObject.Find("NinjaFrog");
        Ground = GameObject.Find("Ground");
        Assert.That(NinjaFrog.transform.position.y > Ground.transform.position.y);
       
    }
    [UnityTest]
    public IEnumerator ObjectBreaksOnImpact()
    {
        // Configuramos el objeto que caerá
        GameObject glassObject = GameObject.Find("GlassObject");
        yield return new WaitForSeconds(2);  // Esperar el tiempo para que caiga

        // Simulamos el impacto con el suelo o cualquier otro objeto
        // Uso esto porque IsNull no funciona con unity da Expected: nullBut was:  <null>
        Assert.IsTrue(glassObject==null); // Verificamos que el objeto ya no existe después del impacto
    }
    
    [UnityTest]
    public IEnumerator ObjectDisappearsOnCollisionWithPlayer()
    {
        // Configuramos el objeto y el personaje
        GameObject collectibleObject = GameObject.Find("CollectibleObject");

        yield return new WaitForSeconds(2); // Esperamos a que haya una posible colisión

        // Simulamos la colisión entre el objeto y el jugador
        Assert.IsTrue(collectibleObject== null); // Verificamos que el objeto desaparece
    }



    [TearDown]
    public void TearDown()
    {
        EditorSceneManager.UnloadSceneAsync("SampleScene");
    }
}
