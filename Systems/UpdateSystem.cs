using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishingRogue
{
    class UpdateSystem
    {  
        public void Update(World world)
        {
            foreach (Entity entity in world.entities)
            {
                foreach (Component component in entity.components)
                {
                    component.Update();
                }
            }
        }
    }
}
