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
                    OriginalItem = ModAPI.FindSpawnable("Pistol"), //can be switched out for «rifle»
                    NameOverride = "pistol",
                    DescriptionOverride = "",
                    CategoryOverride = ModAPI.FindCategory("Firearms"),
                    ThumbnailOverride = ModAPI.LoadSprite("thumbnail.png"),
                    AfterSpawn = (Instance) =>
                    {
                        ModAPI.KeepExtraObjects();
                        var ColtSlide = Instance.transform.Find("Slide");
                        ColtSlide.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("slide.png",);

                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("gun.png",); //for this do not include the sprite for the slide just the base gun.
                        Instance.GetComponent<FirearmBehaviour>().barrelPosition = new Vector2(0.2f, 0.086f);
                        foreach (var c in Instance.GetComponents<Collider2D>())
                        {
                            GameObject.Destroy(c);
						}
                        Instance.FixColliders();
                        Instance.GetComponent<FirearmBehaviour>().BulletsPerShot = 1;

                        var firearm = Instance.GetComponent<FirearmBehaviour>();

                        firearm.ShotSounds = new AudioClip[]
                        {
                ModAPI.LoadSound(""), //import mp3 or wav files here.
                        };

                        Cartridge customCartridge = ModAPI.FindCartridge("9.9x19mm");
                        customCartridge.name = "gun";
                        customCartridge.Damage = 4f;
                        customCartridge.Recoil = 0.1f;
                        customCartridge.ImpactForce = 0.2f;
                        firearm.Cartridge = customCartridge;
		    }
                }
            );
        }
    }
}
         
