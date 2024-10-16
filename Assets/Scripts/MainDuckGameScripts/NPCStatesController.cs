using System.Collections.Generic;
using UnityEngine;

public class NPCStatesController : MonoBehaviour
{
    private List<INPCBehavior> behaviors;
    [SerializeField] private Dictionary<int, INPCBehavior> currentBehaviors = new Dictionary<int, INPCBehavior>();
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Collider2D playerCollider;
    private int redPoints, bluePoints;
    [SerializeField] private float distanceToPlayer, minPlayerRadius/*для 0*/, maxPlayerRadius/*для 1*/;

    private void Awake()
    {
        gameObject.GetComponent<CircleCollider2D>().radius = minPlayerRadius;
    }
    private void Start()
    {
        InitBehaviors();
    }

    private void Update()
    {
        if (currentBehaviors != null)
        {
            foreach (var behavior in currentBehaviors)
            {
                behavior.Value.Update(distanceToPlayer/ (minPlayerRadius- maxPlayerRadius)); 
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minPlayerRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxPlayerRadius);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == playerCollider)
        {
            animator.SetBool("IsActive", true);
            PlayerContact(collision.GetComponent<PlayerStats>());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == playerCollider)
        {
            distanceToPlayer = Vector2.Distance(gameObject.transform.position, collision.transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == playerCollider)
        {
            animator.SetBool("IsActive", false);
            RemoveBlueState();
            RemoveRedState();
        }
    }
    public void PlayerContact(PlayerStats playerStats)
    {
        if (playerStats.karmaPoints < 50)
            redPoints = 100 - playerStats.karmaPoints;
        else
            redPoints = 0;

        if (playerStats.mindPoints < 50)
            bluePoints = 100 - playerStats.mindPoints;
        else
            bluePoints = 0;

        if (redPoints != 0)
        {
            AddRedState();
        }
        if (bluePoints != 0)
        {
            AddBlueState();
        }
        minPlayerRadius = playerStats.interactRadius;
    }
    private void InitBehaviors()
    {
        behaviors = new List<INPCBehavior>
        {
            new RedState(),
            new BlueState()
        };

    }

    private void AddBehavior(int behaviorNumber, int colorPercent, bool isOneState)
    {
        Debug.Log(behaviors[behaviorNumber].ToString());
        if (currentBehaviors.TryAdd(behaviorNumber, behaviors[behaviorNumber]))
            currentBehaviors[behaviorNumber].Enter(spriteRenderer, colorPercent, isOneState);
    }

    private void RemoveBehavior(int behaviorNumber)
    {
        if (currentBehaviors.ContainsKey(behaviorNumber))
        {
            currentBehaviors[behaviorNumber].Exit();
            currentBehaviors.Remove(behaviorNumber);
        }
    }

    //Методы перехода в определённое состояние

    public void AddBlueState() => AddBehavior(1, bluePoints, redPoints == 0);
    public void AddRedState() => AddBehavior(0, redPoints, bluePoints == 0);
    public void RemoveBlueState() => RemoveBehavior(1);

    public void RemoveRedState() => RemoveBehavior(0);
}
