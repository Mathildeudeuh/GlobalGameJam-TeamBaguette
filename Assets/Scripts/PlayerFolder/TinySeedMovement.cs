using UnityEngine;
using UnityEngine.InputSystem;                        //rajoute les inputS. (pakage manager)                                                                              
public class TinySeedMovement: MonoBehaviour
{

    /* declaration des attributs de ma class player accessible a unity [SerializeField] */
    [SerializeField] private float speed;
    [SerializeField] private float xMaxSpeed;                                                         // limitation de la vitesse en courant                                                                          
    [SerializeField] private float yMaxSpeed;                                                         // limitation de la vitesse vertical pour limiter la hauteur de saut                              
    [SerializeField] private float jumpForce;                                                         // force donnée au saut                                                                            

    /* declaration des variables private de ma class player */
    private float direction;                                                                           // flag qui permet de savoir si on se deplace (!=0) et dans quel sens <0 a gauche >0 adroite      
    private bool canJump = false;                                                                     // flag pr savoir si on px sauter(v)                                                                

    /* declaration des composants unity gerant le comportement du player */                                                                                                              
    private Rigidbody2D rb2D;                                                                // gestionnaire comportement physique du player                                                                          // gestion de transition des etats de l'animation    
    private SpriteRenderer spriteRenderer;                                                                                                                                                    


    void Start()
    {                                                 // initialisation des composants
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }


    private void FixedUpdate()
    {
        /* event declenché a chaque changement de frame du sprite, on va s'en servir pour gerer la limite de vitesse  */
        /* recup de la vitesse du player : rigidbody2D.velocity.x (>0 a droite <0 a gauche)                           */
        /* on check que abs( rigidbody2D.velocity.x ) est inferieur a vitesse limite que l'on impose                  */
        /* si vitesse inferieur a limite                                                                              */
        /*     on ajoute a la vitesse                                                                                 */
        /* sinon on fait rien                                                                                         */
        /* On fait la meme chose pour la vitesse verticale afin de limiter le saut                                    */

        var horizontalSpeed = Mathf.Abs(rb2D.velocity.x);
        if (horizontalSpeed < xMaxSpeed)
            rb2D.AddForce(new Vector2(speed * direction, 0));



        var verticalSpeed = Mathf.Abs(rb2D.velocity.y);
        if (verticalSpeed < yMaxSpeed)
            rb2D.AddForce(new Vector2(0, speed));

    }


    private void OnCollisionEnter2D(Collision2D col)                                             // Evenement déclancher à la collision
    {

        canJump = true;

    }

    public void MoveLROnperformed(InputAction.CallbackContext obj)                            // MoveOnperformed-> player non statique direction !=(different) 0
    {
        /* qd la touche < ou > est appuyée la direction devient non null                */
        /* si la  direction est plus grande que 0, le sprite en forme normal (pas FLip) */
        /* sinon on l'inverse (le sprite est Flippé)    
         * */
        if (obj.canceled)
        {
            direction = 0;
            return;
        }
        direction = obj.ReadValue<float>();

        if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction < 0)
        {
            spriteRenderer.flipX = true;
        }
    }



    public void JumpOnperformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Je saute !");
        
        if (canJump)
        {
            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }
    }

  
}
