using UnityEngine;
using System.Collections;

//Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
public class EnemyController : CharacterController2D
{
    public int playerDamage;                            //The amount of food points to subtract from the player when attacking.


    private Animator animator;                          //Variable of type Animator to store a reference to the enemy's Animator component.
    private Transform target;                           //Transform to attempt to move toward each turn.
    private bool skipMove;                              //Boolean to determine whether or not enemy should skip a turn or move this turn.

    private readonly GameManager gameManager;


    //Start overrides the virtual Start function of the base class.
    protected void Start()
    {
        //Register this enemy with our instance of GameManager by adding it to a list of Enemy objects. 
        //This allows the GameManager to issue movement commands.

        //gameManager.AddEnemyToList(this);

        //Get and store a reference to the attached Animator component.
        animator = GetComponent<Animator>();

        //Find the Player GameObject using it's tag and store a reference to its transform component.
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {

    }

}