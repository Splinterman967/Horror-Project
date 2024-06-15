using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] AudioClip monsterRage;
    [SerializeField] float monsterSpeed;
    [SerializeField] Transform playerTransform;

     
     
     Animator animator;
     AudioSource audioSource;
     bool isMonsterMoving = false;
    
    
    private void Start()
    {
       
        animator = GetComponent<Animator>();       
        audioSource = GetComponent<AudioSource>();
      
      
        EventManager.Instance.OnFirstJumpScare += MonsterJumpScareMovement;
        EventManager.Instance.OnFirstJumpScare += MonsterJumpScareSound;
        EventManager.Instance.OnFirstJumpScare += MonsterAnimation;
    }

    private void Update()
    {
        if (isMonsterMoving)
        {
            Vector3 monsterToPlayer = playerTransform.position - transform.position;

            // Ignore changes in the y-coordinate
            monsterToPlayer.y = -1;

            // Move monster towards player at constant speed
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, monsterSpeed * Time.deltaTime);
          
        }
       
    }


    private void MonsterJumpScareSound()
    {
        audioSource.clip= monsterRage;
        audioSource.Play(); 
    }

    private void MonsterJumpScareMovement()
    {
       isMonsterMoving = true;
    }

    private void MonsterAnimation()
    {
        StartCoroutine(animationInterval());
    }


    IEnumerator animationInterval()
    {
        animator.Play("root|Anim_monster_scavenger_rage");
        yield return new WaitForSeconds(1.5f);
        animator.Play("root|Anim_monster_scavenger_walk");
    }


    //IEnumerator moveToPlayerRoutine()
    //{
    //    yield return new WaitForSeconds(1.5f);
        
            
        
    //}
}
