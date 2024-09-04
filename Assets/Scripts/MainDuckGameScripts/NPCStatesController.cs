using System.Collections.Generic;
using UnityEngine;

public class NPCStatesController : MonoBehaviour
{
    private List<INPCBehavior> behaviors;
    [SerializeField] private Dictionary<int, INPCBehavior> currentBehaviors = new Dictionary<int, INPCBehavior>();
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private int redPoints, bluePoints;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
                behavior.Value.Update();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            animator.SetBool("IsActive", true);
            PlayerContact(collision.GetComponent<PlayerStats>());
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "player")
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
    }
    private void InitBehaviors()
    {
        behaviors = new List<INPCBehavior>
        {
            new RedState(),
            new BlueState()
        };

    }

    private void AddBehavior(int behaviorNumber, int colorPercent)
    {
        Debug.Log(behaviors[behaviorNumber].ToString());
        if (currentBehaviors.TryAdd(behaviorNumber, behaviors[behaviorNumber]))
            currentBehaviors[behaviorNumber].Enter(spriteRenderer, colorPercent);
    }

    private void RemoveBehavior(int behaviorNumber)
    {
        if (currentBehaviors.ContainsKey(behaviorNumber))
        {
            currentBehaviors[behaviorNumber].Exit(spriteRenderer);
            currentBehaviors.Remove(behaviorNumber);
        }
    }

    //Методы перехода в определённое состояние

    public void AddBlueState() => AddBehavior(1, bluePoints);
    public void AddRedState() => AddBehavior(0, redPoints);
    public void RemoveBlueState() => RemoveBehavior(1);

    public void RemoveRedState() => RemoveBehavior(0);
}
