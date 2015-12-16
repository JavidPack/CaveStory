using Terraria.ModLoader;

namespace CaveStory
{
    class CaveStory : Mod
    {
        public override void SetModInfo(out string name, ref ModProperties properties)
        {
            name = "CaveStory";
            //  version = "v0.2";
            //   author = "Jopojelly";
            properties.Autoload = true;
            properties.AutoloadGores = true;
            properties.AutoloadSounds = true;

        }
    }
}
