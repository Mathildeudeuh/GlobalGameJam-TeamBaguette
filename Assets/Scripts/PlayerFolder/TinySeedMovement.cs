using UnityEngine;
using UnityEngine.InputSystem;                        //rajoute les inputS. (pakage manager)                                                                              
public class TinySeed : MonoBehaviour
{

    /* declaration des attributs de ma class player accessible a unity [SerializeField] */
    [SerializeField] private float speed;
    [SerializeField] private float xMaxSpeed;                                                         // limitation de la vitesse en courant                                                                          
    [SerializeField] private float yMaxSpeed;                                                         // limitation de la vitesse vertical pour limiter la hauteur de saut                              
    [SerializeField] private float jumpForce;                                                         // force donnée au saut                                                                            

    /* declaration des variables private de ma class player */
    private float direction;                                                                           // flag qui permet de savoir si on se deplace (!=0) et dans quel sens <0 a gauche >0 adroite      
    private bool canJump = false;                                                                     // flag pr savoir si on px sauter(v)                                                                

    /* declaration des composants unity gerant le comportement du player */                            // composants unity
    private Controls controls;                                                                   // gestionnaire de actions utilisées pour gerer les touches                                                 
    private Rigidbody2D rigidbody2D;                                                                // gestionnaire comportement physique du player                                                                          // gestion de transition des etats de l'animation    
    private SpriteRenderer spriteRenderer;                                                             // gestion des animations                                                                                           


    void Start()
    {                                                 // initialisation des composants
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnEnable()                                                                            // Event au déclenchement du player 
    {
        /* initialisation input action ; abonnement aux evenements generer par le clavier */
        /* associations (binding)                                                         */

        controls = new Controls();
        controls.Enable();
        controls.Main.Jump.performed += JumpOnperformed;
        controls.Main.MoveLR.performed += MoveLROnperformed;
        controls.Main.MoveLR.canceled += MoveLROncanceled;
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

        var horizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x);
        if (horizontalSpeed < xMaxSpeed)
            rigidbody2D.AddForce(new Vector2(speed * direction, 0));



        var verticalSpeed = Mathf.Abs(rigidbody2D.velocity.y);
        if (verticalSpeed < yMaxSpeed)
            rigidbody2D.AddForce(new Vector2(0, speed));

    }


    private void OnCollisionEnter2D(Collision2D col)                                             // Evenement déclancher à la collision
    {
        /* on peux de nouveau sauter quand on touche un collider     */
        /* On arrête l'anim "Jumping"                                */
        /* selon la direct° si elle est diff de 0 on cours donc anim */
        /* -> mode "Running"= true                                   */
        /* sinon                                                     */
        /* -> mode standing ,"Running" = False                       */

        canJump = true;

    }

    private void MoveLROnperformed(InputAction.CallbackContext obj)                            // MoveOnperformed-> player non statique direction !=(different) 0
    {
        /* qd la touche < ou > est appuyée la direction devient non null                */
        /* si la  direction est plus grande que 0, le sprite en forme normal (pas FLip) */
        /* sinon on l'inverse (le sprite est Flippé)                                    */

        direction = obj.ReadValue<float>();

        if (direction > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }




    /*using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class TinySeedMovement : MonoBehaviour
    {
        Rigidbody2D rb;
        public int speed;
        public int jumpForce;
        [SerializeField] int JumpPower;

        Vector2 vectormove;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {

        }


        public void Movement(InputAction.CallbackContext value)
        {
            vectormove = value.ReadValue<Vector2>();
            flip();
        }

        public void Jump(InputAction.CallbackContext value)
        {
            if (value.started)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }


        private void FixedUpdate()
        { 
            rb.velocity = new Vector2(vectormove.x * speed, rb.velocity.y); 

        }

        void  flip()
        {
            if (vectormove.x < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
            if(vectormove.x > -0.01f) transform.localScale = new Vector3(1, 1, 1);
        }*/
}
