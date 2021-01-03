using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour
{
    public ParticleSystem particleSystem; //死亡特效
    private bool hasDied; // 確認角色是否死亡
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.name.Equals("trst"))
        {
            this.transform.parent = collision.transform; // 使鳥隨著平台移動
        }
        if (ShouldDieFromCollsion(collision)) // 確認鳥是否死亡
        {
            Die();
        }
    }


    bool ShouldDieFromCollsion(Collision2D collision)
    {
        if (hasDied) //防止怪物多次死亡
        {
            return false;
        }
        test bird = collision.gameObject.GetComponent<test>(); // orange為玩家操控的球
        if (bird)
        {
            return true;
        }
        if (collision.contacts[0].normal.y < -0.5) //木箱落下角度大於45度可使怪物死亡
        {
            return true;
        }
        return false;
    }

    void Die() //操控怪物死亡
    {
        hasDied = true;
        particleSystem.Play(); //啟動死亡特效
        StartCoroutine(threemin()); //使鳥延遲0.1秒後死亡

    }

    IEnumerator threemin()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }

    public override bool Equals(object obj)
    {
        return obj is Monster monster &&
               base.Equals(obj) &&
               EqualityComparer<ParticleSystem>.Default.Equals(particleSystem, monster.particleSystem);
    }


}
