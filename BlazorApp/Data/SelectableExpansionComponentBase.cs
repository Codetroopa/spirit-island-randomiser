using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace SiRandomizer.Data
{    
    // Adds default visibility logic, which is based on the currently selected expansions.
    public abstract class SelectableExpansionComponentBase<T> : SelectableComponentBase<T>, IExpansionContent
        where T : SelectableComponentBase<T>
    {
        [JsonIgnore]
        public Expansion Expansion { get; set; }

        public SelectableExpansionComponentBase() {}

        public SelectableExpansionComponentBase(
            string name,
            OverallConfiguration config,
            IComponentCollection parentList,
            Expansion expansion) 
            : base(name, config, parentList)
        {
            Expansion = expansion;
        }

        public override bool IsVisible()
        {
            var visible = Expansion == null || Config.Expansions[Expansion.Name].Selected;
            // If this component is not visible then also ensure it is not selected.
            if(visible == false)
            {
                Selected = false;
            }
            return visible;
        }
    }
}