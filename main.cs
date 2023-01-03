using UnityEngine;
using UnityEngine.Events;

namespace AnimatedWeapons
{
    public class AnimatedWeapons
    {
        public static void Main()
        {

            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Pistol"), // you can also do m1 garand or rifle.
                    NameOverride = "animated handgun",
                    NameToOrderByOverride = "!",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("pistol.png"),
                    AfterSpawn = (Instance) =>
                    {
                        ModAPI.KeepExtraObjects();

                        var MakarovSlide = Instance.transform.Find("Slide");
                        MakarovSlide.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("pistolslide.png");

                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("pistolCol.png", 10);
                        foreach (var c in Instance.GetComponents<Collider2D>())
                        {
                            GameObject.Destroy(c);
						}
                        Instance.FixColliders();
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Textures/Makarov.png");

                        var firearm = Instance.GetComponent<FirearmBehaviour>();
                        firearm.BulletsPerShot = 1;
                        firearm.barrelPosition = new Vector2(0.15f, 0.08f);
                        firearm.ShotSounds = new AudioClip[]
                        {
                              ModAPI.LoadSound(""),
                        };

                        Cartridge customCartridge = ModAPI.FindCartridge("9mm");
                        customCartridge.name = "";
                        customCartridge.Damage = 5f;
                        customCartridge.Recoil = 0.1f;
                        customCartridge.ImpactForce = 0.1f;
                        firearm.Cartridge = customCartridge;
		    }
                }
            );
        }
    }
}
         
