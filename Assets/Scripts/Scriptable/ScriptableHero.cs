using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero",menuName="Scriptable/newHero")]
public class ScriptableHero : ScriptableObject
{
    public  float attack = 0.02f;
    public  float healamount = 0.005f;
    public  bool iscorrect = false;
    public  bool darkpersist = false;
    public  float defend;
    public  int coinnumber;
    public float HP;
    public float EnemyHP;
    // Start is called before the first frame update

}
