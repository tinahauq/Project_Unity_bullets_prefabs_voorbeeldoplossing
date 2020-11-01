using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //Declaratie en initialisatie van de public variables.

    public float velX; // De horizontale snelheid krijgt een waarde via de gebruikte prefab. Voor een BulletToLeft wordt dit -5 zodat 
                       // de Bullet naar links zal bewegen langs de X-as. Voor een BulletToRight staat de waarde ingesteld op 5 zodat
                       // de bullet naar rechts beweegt langs de X-as. (Je stelde deze waarden reeds in toen je de prefabs maakte).

    public float velY = 0f; // De verticale snelheid is 0 zodat de bullet niet naar beneden valt.

    //Declaratie variabele van het type Rigidbody om de RigidBody component van een Bullet kunnen aan te spreken in wat volgt.

    Rigidbody2D rb; 

    void Awake() //De functie Awake wordt uitgevoerd als het object gemaakt wordt.
    {
        rb = GetComponent<Rigidbody2D>(); //De variabele rb wordt gekoppeld aan de Rigidbody2D component
                                          //waaraan dit script gekoppeld is, dus aan de Rigidbody2D van een Bullet.
    }

   
    void Update()
    {
        rb.velocity = new Vector2(velX, velY); //De property velocity geeft de snelheid aan waarmee de kogel binnen elk frame bewogen wordt. 
                                               //Deze instructie zorgt er dus voor dat de kogel blijft voortbewegen tegen de ingestelde snelheid.
    }
}
