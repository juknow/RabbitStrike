using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDataManager : MonoBehaviour
{
    // 싱글턴 인스턴스
    public static NewDataManager Instance { get; private set; }

    // Private fields for user stats

    //StageTypeCount
    private int shortEnemyCount;
    private int longEnemyCount;
    private int basicEnemyCount;

    private int shortPlayerCount;
    private int longPlayerCount;
    private int basicPlayerCount;

    //BasicPlayer
    private float basicPlayerHP;
    private float basicPlayerMoveSpeed;

    private float basicPlayerAttackDamage;

    private float basicPlayerAttackCooldown;

    //ShortPlayer

    private float shortPlayerHP;
    private float shortPlayerMoveSpeed;

    private float shortPlayerAttackDamage;

    private float shortPlayerAttackCooldown;

    //LongPlayer

    private float longPlayerHP;
    private float longPlayerMoveSpeed;

    private float longPlayerAttackDamage;

    private float longPlayerAttackCooldown;

    //BasicEnemy

    private float basicEnemyHP;
    private float basicEnemyMoveSpeed;

    private float basicEnemyAttackDamage;

    private float basicEnemyAttackCooldown;


    //ShortEnemy

    private float shortEnemyHP;
    private float shortEnemyMoveSpeed;

    private float shortEnemyAttackDamage;

    private float shortEnemyAttackCooldown;


    //LongEnemy


    private float longEnemyHP;
    private float longEnemyMoveSpeed;

    private float longEnemyAttackDamage;

    private float longEnemyAttackCooldown;

    //

    private int stageLevel;
    private float speed;
    private float attacSpeed;
    private float health;
    private float maxHealth;
    private float damage;
    private int dashCount;
    private bool dashState;
    private string weapon;
    private string specialWeapon;
    private int bulletCount;
    private float skillDamage;
    private float swordLength;
    private float shurikenDamage;
    private float axeDamage;
    public float firstDamage;
    public float firstMaxHealth;
    public float firstSpeed;
    public float firstAttackSpeed;
    public int firstDashCount;
    public float additionalDamage = 0;
    public float additionalMaxHealth = 0;
    public float additionalSpeed = 0;
    public float additionalAttackSpeed = 0;
    public int additionalDashCount = 0;
    public bool justCleared = false;
    public bool specialWeaponGet = false;
    public bool epicSkill = false;
    public bool isDead = false;
    public bool firstClassChage = true;
    public bool beHit = false;

    // getset 에 접근하게 해주는 프로퍼티

    //StageTypeCount
    public int ShortEnemyCount
    {
        get { return shortEnemyCount; }
        set { shortEnemyCount = value; }
    }
    public int LongEnemyCount
    {
        get { return longEnemyCount; }
        set { longEnemyCount = value; }
    }
    public int BasicEnemyCount
    {
        get { return basicEnemyCount; }
        set { basicEnemyCount = value; }
    }
    public int ShortPlayerCount
    {
        get { return shortPlayerCount; }
        set { shortPlayerCount = value; }
    }
    public int LongPlayerCount
    {
        get { return longPlayerCount; }
        set { longPlayerCount = value; }
    }
    public int BasicPlayerCount
    {
        get { return basicPlayerCount; }
        set { basicPlayerCount = value; }
    }
    //BasicPlayer
    public float BasicPlayerHP
    {
        get { return basicPlayerHP; }
        set { basicPlayerHP = value; }
    }

    public float BasicPlayerMoveSpeed
    {
        get { return basicPlayerMoveSpeed; }
        set { basicPlayerMoveSpeed = value; }
    }

    public float BasicPlayerAttackDamage
    {
        get { return basicPlayerAttackDamage; }
        set { basicPlayerAttackDamage = value; }
    }

    public float BasicPlayerAttackCooldown
    {
        get { return basicPlayerAttackCooldown; }
        set { basicPlayerAttackCooldown = value; }
    }


    //ShortPlayer

    public float ShortPlayerHP
    {
        get { return shortPlayerHP; }
        set { shortPlayerHP = value; }
    }

    public float ShortPlayerMoveSpeed
    {
        get { return shortPlayerMoveSpeed; }
        set { shortPlayerMoveSpeed = value; }
    }

    public float ShortPlayerAttackDamage
    {
        get { return shortPlayerAttackDamage; }
        set { shortPlayerAttackDamage = value; }
    }

    public float ShortPlayerAttackCooldown
    {
        get { return shortPlayerAttackCooldown; }
        set { shortPlayerAttackCooldown = value; }
    }

    //LongPlayer
    public float LongPlayerHP
    {
        get { return longPlayerHP; }
        set { longPlayerHP = value; }
    }

    public float LongPlayerMoveSpeed
    {
        get { return longPlayerMoveSpeed; }
        set { longPlayerMoveSpeed = value; }
    }

    public float LongPlayerAttackDamage
    {
        get { return longPlayerAttackDamage; }
        set { longPlayerAttackDamage = value; }
    }

    public float LongPlayerAttackCooldown
    {
        get { return longPlayerAttackCooldown; }
        set { longPlayerAttackCooldown = value; }
    }

    //BasicEnemy

    public float BasicEnemyHP
    {
        get { return basicEnemyHP; }
        set { basicEnemyHP = value; }
    }

    public float BasicEnemyMoveSpeed
    {
        get { return basicEnemyMoveSpeed; }
        set { basicEnemyMoveSpeed = value; }
    }

    public float BasicEnemyAttackDamage
    {
        get { return basicEnemyAttackDamage; }
        set { basicEnemyAttackDamage = value; }
    }

    public float BasicEnemyAttackCooldown
    {
        get { return basicEnemyAttackCooldown; }
        set { basicEnemyAttackCooldown = value; }
    }



    //ShortEnemy

    public float ShortEnemyHP
    {
        get { return shortEnemyHP; }
        set { shortEnemyHP = value; }
    }

    public float ShortEnemyMoveSpeed
    {
        get { return shortEnemyMoveSpeed; }
        set { shortEnemyMoveSpeed = value; }
    }

    public float ShortEnemyAttackDamage
    {
        get { return shortEnemyAttackDamage; }
        set { shortEnemyAttackDamage = value; }
    }

    public float ShortEnemyAttackCooldown
    {
        get { return shortEnemyAttackCooldown; }
        set { shortEnemyAttackCooldown = value; }
    }


    //LongEnemy

    public float LongEnemyHP
    {
        get { return longEnemyHP; }
        set { longEnemyHP = value; }
    }

    public float LongEnemyMoveSpeed
    {
        get { return longEnemyMoveSpeed; }
        set { longEnemyMoveSpeed = value; }
    }

    public float LongEnemyAttackDamage
    {
        get { return longEnemyAttackDamage; }
        set { longEnemyAttackDamage = value; }
    }

    public float LongEnemyAttackCooldown
    {
        get { return longEnemyAttackCooldown; }
        set { longEnemyAttackCooldown = value; }
    }

    //
    public int StageLevel
    {
        get { return stageLevel; }
        set { stageLevel = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float AttacSpeed
    {
        get { return attacSpeed; }
        set { attacSpeed = value; }
    }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }
    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public int DashCount
    {
        get { return dashCount; }
        set { dashCount = value; }
    }

    public bool DashState
    {
        get { return dashState; }
        set { dashState = value; }
    }

    public string Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }
    public string SpecialWeapon
    {
        get { return specialWeapon; }
        set { specialWeapon = value; }
    }
    public int BulletCount
    {
        get { return bulletCount; }
        set { bulletCount = value; }
    }
    public float SkillDamage
    {
        get { return skillDamage; }
        set { skillDamage = value; }
    }
    public float SwordLength
    {
        get { return swordLength; }
        set { swordLength = value; }
    }
    public float ShurikenDamage
    {
        get { return shurikenDamage; }
        set { shurikenDamage = value; }
    }
    public float AxeDamage
    {
        get { return axeDamage; }
        set { axeDamage = value; }
    }

    // Optional: Add any additional methods or functionality here

    void Awake()
    {
        // 싱글톤 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
