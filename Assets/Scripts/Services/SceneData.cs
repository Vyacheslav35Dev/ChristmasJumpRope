using Leopotam.Ecs;
using UnityComponents;
using UnityEngine;
using YG;

public class SceneData : MonoBehaviour
{
    public int OldScore;
    public int Score;

    public bool isRunGame;

    public PlayerController PlayerController;
    public RopeController RopeController;
    
    public UI Ui;
    
    public Sprite PinguinSprite;
    public Sprite SnomanSprite;
    public Sprite TreeSprite;

    public SpriteRenderer PlayerSprite;

    public GameObject World;

    public EcsEntity entityForceRopeAnimSpeed;

    public LeaderboardYG LeaderboardYg;
    
    [Header("Store Settings")]
    public string PurchaseIdSnoMan = "snowmanpay";
    public string PurchaseIdPenguin = "penguinpay";
    
    [Header("Player Settings")]
    public float p_Impulse = 10f;
    public float strengImpuls = 10f;
    public float dumping = 0.9f;
    
    [Header("Rope Settings")]
    public float speedAnim = 40.0f;
    public float coofSpeed = 0.03f;
}
