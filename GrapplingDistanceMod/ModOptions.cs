using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nautilus.Json;
using Nautilus.Options.Attributes;

namespace Samjocal.GrapplingDistanceMod
{
    [Menu("Grappling Distance Mod")]
    public class ModOptions : ConfigFile
    {
        [Slider("Grappling Distance", 35.0f, 140.0f, DefaultValue = 35.0f, Format = "{0:F2}")]
        public float MaxDistance = 35.0f;
    }
}
