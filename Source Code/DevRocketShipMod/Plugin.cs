using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine;
using Utilla;
using System.ComponentModel;

namespace DevRocketShipMod
{
    //[Description("HauntedModMenu")] removed due to bugs
    [Description("HauntedModMenu")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [ModdedGamemode]
    public class Plugin : BaseUnityPlugin
    {

        //Mod programmed by Dev (dev.#9998)
        //Do not use in any other mod (Reusing code, models, sounds, etc. Or using in mod menus.)

        /*Important stuff*/
        static bool modActive = false; // is the mod active
        static bool inModdedLobby = false; // if the player is in a modded lobby

        /*Required GameObjects*/
        static GameObject RocketShip; // the rocket loaded from the bundle
        public static GameObject RealRocket; // the used rocket loaded from the bundle
        public static GameObject RocketFolder; // the folder containing all of the rockets

        /*Keybind*/
        static bool triggerButtonIn; // if the player is holding trigger
        static bool primaryButtonDown; // if the player is holding down B
        static bool secondaryButtonDown; // if the player is holding down A
        static bool editMode = false; // if the mod is editing rockets 
        static bool editModeToggle = false; // the toggle variable for editing

        /*Cooldowns*/
        static int RocketCooldown = 0; // cooldown for the mod
        static bool RocketCooldownDocumented = true; // cooldown toggle variable for the mod
        static int RocketCooldown2 = 0; // cooldown for placing rockets
        static bool RocketCooldownDocumented2 = true; // cooldown toggle variable for placing rockets

        /*Activation*/
        public static bool blastOff = false; // ready to blast off or not
        public static bool foundOutIfBlast = false; // if the rocket is blasting

        /*Tracking*/
        public static string findThisRocket; // the string used for finding a rocket to launch
        public static int currentRocket = -1; // current # of rockets -1

        void OnEnable()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
            if (inModdedLobby)
            {
                if (currentRocket == -1)
                {
                    modActive = this.enabled;
                    RocketFolder.gameObject.SetActive(true);
                }
                else
                if (!foundOutIfBlast)
                {
                    modActive = this.enabled;
                    RocketFolder.gameObject.SetActive(true);
                }
            }
        }

        void OnDisable()
        {
            Utilla.Events.GameInitialized -= OnGameInitialized;
            modActive = this.enabled;
            if (currentRocket == -1)
            {
                RocketFolder.gameObject.SetActive(false);
            }
            else
            if (!foundOutIfBlast)
            {
                RocketFolder.gameObject.SetActive(false);
            }
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            RocketFolder = new GameObject();
            RocketFolder.name = "DevRocketShipMod";

            Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("DevRocketShipMod.Assets.rocket");
            AssetBundle bundle = AssetBundle.LoadFromStream(str);
            RocketShip = bundle.LoadAsset<GameObject>("Ship");
            RealRocket = Instantiate(RocketShip);
            RealRocket.transform.SetParent(RocketFolder.transform);
            RealRocket.transform.localPosition = new Vector3(0f, 0f, 0f);
            RealRocket.transform.localScale = new Vector3(0.4524f, 0.4524f, 0.4524f);
            RealRocket.transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Ship(Clone)").transform.GetChild(0).gameObject.layer = 18;

        }

        void Update()
        {

            
            if (RocketCooldown == 0)
            {
                if (!RocketCooldownDocumented)
                {
                    RocketCooldownDocumented = true;
                    foundOutIfBlast = false;
                    blastOff = false;
                }
            }
            else
            {
                RocketCooldown--;
            }

            if (RocketCooldown2 == 0)
            {
                if (!RocketCooldownDocumented2)
                {
                    RocketCooldownDocumented2 = true;
                    
                }
            }
            else
            {
                RocketCooldown2--;
            }

            InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonDown);
            InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButtonDown);

            if (primaryButtonDown && !editModeToggle && modActive)
            {
                editModeToggle = true;
                editMode = !editMode;
            }
            else if (!primaryButtonDown && editModeToggle)
            {
                editModeToggle = false;
            }

            if (!modActive)
            {
                editModeToggle = true;
                editMode = false;
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket0"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket0"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket0"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket0"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket3"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket3"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket3"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket3"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket4"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket4"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket4"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket4"));
                }
                currentRocket = -1;
            }

            if (secondaryButtonDown && modActive && !editMode)
            {
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket0"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket0"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket0"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket0"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket3"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket3"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket3"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket3"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket4"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket4"));
                }
                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket4"))
                {
                    GameObject.Destroy(GameObject.Find("DevRocketShipMod/CoolUniqueRocket4"));
                }
                currentRocket = -1;
            }

            if (!editMode)
            {
                RealRocket.gameObject.SetActive(false);
                RealRocket.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                RealRocket.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
            }

            if (!foundOutIfBlast && editMode)
            {
                triggerButtonIn = false;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out triggerButtonIn);
                
                    #pragma warning disable IDE0018 // Inline variable declaration
                    RaycastHit hitInfo;
                    Physics.Raycast(GorillaLocomotion.Player.Instance.rightHandTransform.position - GorillaLocomotion.Player.Instance.rightHandTransform.up, -GorillaLocomotion.Player.Instance.rightHandTransform.up, out hitInfo);
                    RealRocket.transform.localPosition = hitInfo.point + new Vector3(0f, -0.004f, 0f);
                RealRocket.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                RealRocket.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
                    RealRocket.gameObject.SetActive(true);
                    if (triggerButtonIn)
                    {
                        if (RocketCooldown2 == 0)
                        {
                            RocketCooldown2 = 60;
                            RocketCooldownDocumented2 = false;
                            if (currentRocket < 4)
                            {
                                GameObject ClonedRocket = GameObject.Instantiate(RealRocket);
                                currentRocket++;
                                ClonedRocket.transform.SetParent(RocketFolder.transform);
                            if (currentRocket == 2) // dupe check
                            {
                                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"))
                                {
                                    ClonedRocket.name = "CoolUniqueRocket" + currentRocket.ToString();
                                }
                                else
                                {
                                    ClonedRocket.name = "CoolUniqueRocket1";
                                }
                            }
                            else
                            if (currentRocket == 3) // dupe check
                            {
                                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket1") && GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"))
                                {
                                    ClonedRocket.name = "CoolUniqueRocket" + currentRocket.ToString();
                                }
                                else
                                {
                                    if ((GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"))) { }
                                    else
                                    {
                                        ClonedRocket.name = "CoolUniqueRocket2";
                                    }
                                    if ((GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"))) { } else
                                    {
                                        ClonedRocket.name = "CoolUniqueRocket1";
                                    }
                                }
                            }
                            
                            else

                            if (currentRocket == 4) // dupe check
                            {
                                if (GameObject.Find("DevRocketShipMod/CoolUniqueRocket1") && GameObject.Find("DevRocketShipMod/CoolUniqueRocket2") && GameObject.Find("DevRocketShipMod/CoolUniqueRocket3"))
                                {
                                    ClonedRocket.name = "CoolUniqueRocket" + currentRocket.ToString();
                                }
                                else
                                {
                                    if ((GameObject.Find("DevRocketShipMod/CoolUniqueRocket3"))) { }
                                    else
                                    {
                                        ClonedRocket.name = "CoolUniqueRocket3";
                                    }
                                    if ((GameObject.Find("DevRocketShipMod/CoolUniqueRocket2"))) { }
                                    else
                                    {
                                        ClonedRocket.name = "CoolUniqueRocket2";
                                    }
                                    if ((GameObject.Find("DevRocketShipMod/CoolUniqueRocket1"))) { }
                                    else
                                    {
                                        ClonedRocket.name = "CoolUniqueRocket1";
                                    }
                                }
                            }

                            else
                            {
                                ClonedRocket.name = "CoolUniqueRocket" + currentRocket.ToString();
                            }
                                ClonedRocket.transform.localPosition = hitInfo.point;
                                ClonedRocket.transform.localScale = new Vector3(0.4524f, 0.4524f, 0.4524f);
                            ClonedRocket.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                            ClonedRocket.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
                            ClonedRocket.gameObject.AddComponent<RocketDespawn>();
                                ClonedRocket.transform.GetChild(0).gameObject.layer = 18;
                                ClonedRocket.transform.GetChild(1).gameObject.SetActive(true);
                                ClonedRocket.transform.GetChild(1).transform.GetChild(0).gameObject.AddComponent<RocketTrigger>();
                                ClonedRocket.transform.GetChild(1).transform.GetChild(1).gameObject.AddComponent<RocketTrigger>();
                                ClonedRocket.transform.GetChild(1).transform.GetChild(2).gameObject.AddComponent<RocketTrigger>();
                                ClonedRocket.transform.GetChild(1).transform.GetChild(3).gameObject.AddComponent<RocketTrigger>();
                            }
                        }
                }
            }

            if (blastOff)
            {
                if (!foundOutIfBlast)
                {
                    foundOutIfBlast = true;
                    GameObject ThisUsedRocket = GameObject.Find(findThisRocket.ToString());
                    if (ThisUsedRocket == null) { }
                    else
                    {
                        GameObject.Find("Player/GorillaPlayer/TurnParent/LeftHand Controller/").SetActive(true);
                        ThisUsedRocket.gameObject.AddComponent<Rigidbody>();
                        Rigidbody RocketRigidbody = ThisUsedRocket.gameObject.GetComponent<Rigidbody>();
                        RocketRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                        RocketRigidbody.AddForce(new Vector3(0f, 3500f, 0f), ForceMode.Acceleration);
                        ThisUsedRocket.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 3500f, 0f), ForceMode.Acceleration);
                        Rigidbody PlayerRigidbody = GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>();
                        PlayerRigidbody.velocity = new Vector3(0f, PlayerRigidbody.velocity.y, 0f);
                        RocketCooldown = 185;
                        RocketCooldownDocumented = false;
                    }
                }
            }

            

        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            inModdedLobby = true;
            modActive = this.enabled;
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            inModdedLobby = false;
            modActive = false;
        }
    }
} // https://www.youtube.com/watch?v=uMszu_VgMfY&ab_channel=AgtfCZ