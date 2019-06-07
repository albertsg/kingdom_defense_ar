using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;
using Text = UnityEngine.UI.Text;

public class PowerUpsInit : MonoBehaviour
{
    private GameObject fireball;
    private GameObject damage;
    private GameObject barrier;
    private GameObject trap;

    private Rigidbody gravity;

    private GameObject gameManager;
    private GameManagerBehavior gmb;

    private GameObject shootingObject;

    // Use this for initialization
    void Start()
    {
        fireball = GameObject.Find("ImageTargetPowerup/Fireball");
        damage = GameObject.Find("ImageTargetPowerup/Damage");
        barrier = GameObject.Find("ImageTargetPowerup/Barrier");
        trap = GameObject.Find("ImageTargetPowerup/Trap");

        gameManager = GameObject.Find("GameManager");
        gmb = gameManager.GetComponent<GameManagerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        displayParticleSystemInstantiation();
    }

    public void Fireball()
    {
        //Fireball mana = 700

        if (gmb.cur_mana >= 50)
        {
            GameObject parentTow = GameObject.Find("ImageTargetPowerup").gameObject;
            GameObject newobj;
            newobj = Instantiate(fireball, fireball.transform.position, fireball.transform.rotation) as GameObject;

            newobj.transform.SetParent(parentTow.transform, false); //False para mantener el tamaño
            newobj.transform.position = fireball.transform.position;

            Rigidbody newrb = newobj.GetComponent<Rigidbody>();
            newrb.useGravity = false;


            var pos = newobj.transform.position;
            pos.y += 1;
            newobj.transform.position = pos;

            //BoxCollider bc;
            SphereCollider sc;

            //bc = newobj.GetComponent<BoxCollider> ();
            sc = newobj.GetComponent<SphereCollider>();

            //bc.enabled = false;
            sc.enabled = false;

            newobj.name = "Fireball";


            GameObject parent = GameObject.Find("escenary").gameObject;
            fireball.transform.SetParent(parent.transform);
            gravity = fireball.GetComponent<Rigidbody>();

            gravity.useGravity = true;
            gravity.isKinematic = false;
            sc = fireball.GetComponent<SphereCollider>();
            //
            sc.enabled = false;

            Debug.Log("GRAVEDAD ACTIVADA");
            GameObject particleTryOut = Instantiate(Resources.Load("Prefabs/ETF_Fireball", typeof(GameObject))) as GameObject;
            particleTryOut.transform.position = fireball.transform.position;
            particleTryOut.transform.rotation = Quaternion.AngleAxis(90.0f, new Vector3(1, 0, 0));
            ParticleSystem particleSys = particleTryOut.GetComponent<ParticleSystem>();
            particleSys.Play();

            GameObject damageFireball = GameObject.Find("ETF_PowerUp_Light ");
            damageFireball.GetComponent<SphereCollider>().enabled = true;
            damageFireball.GetComponent<causeDamageFireball>().enabled = true;
            damageFireball.GetComponent<causeDamageFireball>().deactivateOn5seg();


            gmb.decreaseMana(50f);

            fireball = GameObject.Find("ImageTargetPowerup/Fireball");//Para actualizar la fireball a la que se hace referencia
        }
        else
        {
        }

    }

    public void Damage()
    {
        //Damage mana = 400;
        if (gmb.cur_mana >= 400)
        {
            GameObject parentTow = GameObject.Find("ImageTargetPowerup").gameObject;
            GameObject newobj;
            newobj = Instantiate(damage, damage.transform.position, damage.transform.rotation) as GameObject;

            newobj.transform.SetParent(parentTow.transform, false); //False para mantener el tamaño
            newobj.transform.position = damage.transform.position;

            Rigidbody newrb = newobj.GetComponent<Rigidbody>();
            newrb.useGravity = false;


            var pos = newobj.transform.position;
            pos.y += 1;
            newobj.transform.position = pos;

            BoxCollider bc;
            //SphereCollider sc;

            bc = newobj.GetComponent<BoxCollider>();
            //sc = newobj.GetComponent<SphereCollider> ();

            bc.enabled = false;
            //sc.enabled = false;

            newobj.name = "Damage";


            GameObject parent = GameObject.Find("escenary").gameObject;
            damage.transform.SetParent(parent.transform);
            gravity = damage.GetComponent<Rigidbody>();

            MeshRenderer meshRendererDamage = barrier.GetComponent<MeshRenderer>();
            meshRendererDamage.enabled = true;

            gravity.useGravity = true;
            bc.enabled = true; //Para que se quede en el escenario 
            gravity.isKinematic = false;

            Debug.Log("GRAVEDAD ACTIVADA");

            gmb.decreaseMana(400f);

            damage = GameObject.Find("ImageTargetPowerup/Damage");//Para actualizar el damage al que se hace referencia
        }
        else
        {
        }

    }

    public void Barrier()
    {
        //Barrier mana = 200
        if (gmb.cur_mana >= 200)
        {
            GameObject parentTow = GameObject.Find("ImageTargetPowerup").gameObject;
            GameObject newobj;
            newobj = Instantiate(barrier, barrier.transform.position, barrier.transform.rotation) as GameObject;

            newobj.transform.SetParent(parentTow.transform, false); //False para mantener el tamaño
            newobj.transform.position = barrier.transform.position;

            Rigidbody newrb = newobj.GetComponent<Rigidbody>();
            newrb.useGravity = false;

            var pos = newobj.transform.position;
            pos.y += 1;
            newobj.transform.position = pos;

            BoxCollider bc;
            //SphereCollider sc;

            bc = newobj.GetComponent<BoxCollider>();
            //sc = newobj.GetComponent<SphereCollider> ();

            bc.enabled = false;
            //sc.enabled = false;

            newobj.name = "Barrier";


            GameObject parent = GameObject.Find("escenary").gameObject;
            barrier.transform.SetParent(parent.transform);
            gravity = barrier.GetComponent<Rigidbody>();
            MeshRenderer meshRendererDamage = barrier.GetComponent<MeshRenderer>();
            meshRendererDamage.enabled = true;

            gravity.useGravity = true;
            gravity.isKinematic = false;


            BoxCollider oldbc = barrier.GetComponent<BoxCollider>();
            oldbc.enabled = true;
            Debug.Log("GRAVEDAD ACTIVADA");

            gmb.decreaseMana(200f);

            barrier = GameObject.Find("ImageTargetPowerup/Barrier");//Para actualizar la barrier a la que se hace referencia
        }
        else
        {

        }

    }


    public void Trap()
    {
        //Damage mana = 400;
        if (gmb.cur_mana >= 300)
        {
            GameObject parentTow = GameObject.Find("ImageTargetPowerup").gameObject;
            GameObject newobj;
            newobj = Instantiate(trap, trap.transform.position, trap.transform.rotation) as GameObject;

            newobj.transform.SetParent(parentTow.transform, false); //False para mantener el tamaño
            newobj.transform.position = trap.transform.position;

            Rigidbody newrb = newobj.GetComponent<Rigidbody>();
            newrb.useGravity = false;


            var pos = newobj.transform.position;
            pos.y += 1;
            newobj.transform.position = pos;

            BoxCollider bc;
            //SphereCollider sc;

            bc = newobj.GetComponent<BoxCollider>();
            //sc = newobj.GetComponent<SphereCollider> ();

            bc.enabled = false;
            //sc.enabled = false;

            newobj.name = "Trap";


            GameObject parent = GameObject.Find("escenary").gameObject;
            trap.transform.SetParent(parent.transform);
            gravity = trap.GetComponent<Rigidbody>();
            MeshRenderer meshRendererDamage = barrier.GetComponent<MeshRenderer>();
            meshRendererDamage.enabled = true;

            gravity.useGravity = true;
            bc.enabled = true; //Para que se quede en el escenario 
            gravity.isKinematic = false;

            Debug.Log("GRAVEDAD ACTIVADA");

            gmb.decreaseMana(300f);

            trap = GameObject.Find("ImageTargetPowerup/Trap");//Para actualizar el damage al que se hace referencia
        }
        else
        {
        }

    }


    public void Arrows()
    {
        Debug.Log("Arrows was selected");
        //ESTE POWERUP ES DIFERENTE
        shootingObject = GameObject.FindGameObjectWithTag("shootingObjectTag");
        Gun gunScript = shootingObject.GetComponent<Gun>();
        gunScript.showUIArrowsPowerUp();
        gunScript.enableShooting = true;
    }


    private void displayParticleSystemInstantiation()
    {
        GameObject rayPosOrigin = GameObject.Find("RayOriginPow");
        Ray ray = new Ray(rayPosOrigin.transform.position, Vector3.down);
        RaycastHit hit;

        GameObject particleSystem = GameObject.Find("particleSystemPU");
        particleSystemBehaviour particleSystemBehaviour = particleSystem.transform.GetChild(0).GetComponent<particleSystemBehaviour>();
        particleSystem.transform.position = rayPosOrigin.transform.position;
        particleSystemBehaviour.startParticleSystem();
        /*
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            particleSystem.transform.position = hit.transform.position;
            //particleSystemBehaviour particleSystemBehaviour = particleSystem.transform.GetChild(1).GetComponent<particleSystemBehaviour>();
            particleSystemBehaviour.startParticleSystem();
        }
        */
    }


}
    


