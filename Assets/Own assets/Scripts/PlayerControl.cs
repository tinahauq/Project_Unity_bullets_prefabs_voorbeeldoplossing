using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 1.5f;

    //Variabele die zal geïnitialiseerd worden op de SpriteRenderer component van de Player.
    //Via deze variabele kunnen we de property flipX aanspreken die we nodig hebben om de sprite
    //te flippen op de X-as.
    private SpriteRenderer mySpriteRenderer;

    //Public variables die we via het Inspector venster instellen op de prefabs (selecteer het Player object
    //om deze te kunnen instellen bij de component Player Control (Script)).
    //In de Fire() functie gebruiken we deze variabelen om van de ingestelde prefab een kogel te maken.
    public GameObject bulletToRight, bulletToLeft;

    //Variabele die in de functie Fire() gebruikt wordt om de startpositie van een Bullet te bepalen.
    Vector2 bulletPos;

    //Awake() wordt uitgevoerd als het GameObject gemaakt wordt.
    private void Awake()
    {
        //De variabele mySpriteRenderer wordt gekoppeld aan de Sprite Renderer component van
        //het Player object. Via deze variabele kunnen we in wat volgt de flipX property aanspreken.
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Toegevoegd om de sprite te flippen op de X-as als er op de linkse pijltoets gedrukt wordt.
            mySpriteRenderer.flipX = true;
            //Einde toevoeging

            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Toegevoegd om de sprite origineel te tonen als er op de rechtse pijltoets gedrukt wordt.
            //(origineel = kijkend naar rechts)
            mySpriteRenderer.flipX = false;
            //Einde toevoeging

            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * 2 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1")) //Wordt de Fire1-toets ingedrukt (= linkse CTRL toets)
        {
            Fire(); //De functie Fire wordt uitgevoerd als de Fire1 button ingedrukt wordt (dit is ingesteld op de linkse CTRL toets).
        }
    }
    void Fire()
    {

        //De positie van de bullet wordt geïnitialiseerd op de positie van de Player. Transform.position geeft immers
        //de positie van de Player aan aangezien dit script aan het Player object gekoppeld is.
        bulletPos = transform.position;

        if (mySpriteRenderer.flipX) //Indien flipX true is, kijkt de Player naar links en moet er een Bullet geïnstantieerd worden
        {                           //die naar links gaat.
            bulletPos += new Vector2(-0.4f, +0.05f); //De positie van de Bullet wordt iets naar links en iets naar boven verschoven t.o.v. de Player.
                                                     //Dit geeft het effect dat de Bullet aan de linkerkant van de Player vertrekt ter hoogte van zijn hand.

            Instantiate(bulletToLeft, bulletPos, Quaternion.identity); //Van de prefab bulletToLeft wordt een nieuwe instantie gemaakt
        }                                                              //die getoond wordt op de positie bulletPos.
        else
        {
            bulletPos += new Vector2(+0.4f, +0.05f); //De positie van de Bullet wordt iets naar rechts en iets naar boven verschoven t.o.v. de Player.
                                                     //Dit geeft het effect dat de Bullet aan de rechterkant van de Player vertrekt ter hoogte van zijn hand.

            Instantiate(bulletToRight, bulletPos, Quaternion.identity); //Van de prefab bulletToLeft (argument 1) wordt een nieuwe instantie gemaakt
        }                                                               //die getoond wordt op de positie bulletPos (argument 2).
                                                                        //De functie Instantiate heeft meerdere overloads. Hier gebruiken we de versie met
                                                                        //3 argumenten. Het derde argument geeft de rotatie aan. We stellen dit hier in op
                                                                        //Quaternion.identity, wat betekent: geen rotatie t.o.v. de wereld waarin het object
                                                                        //zich bevindt.
    }
}

