using RimWorld;
using System.Linq;
using Verse;

namespace CapitalismVsSocialism
{
    public class CapitalismLogic : GameComponent
    {
        public CapitalismLogic(Game game) : base(game) { }

        public override void StartedNewGame()
        {
            base.StartedNewGame();
            AssignRolesToColonists();
        }

        private void AssignRolesToColonists()
        {
            var colonists = PawnsFinder.AllMaps_FreeColonists;
            if (colonists.Any())
            {
                var entrepreneur = colonists.RandomElement();
                entrepreneur.story.traits.GainTrait(new Trait(TraitDef.Named("Entrepreneur")));

                foreach (var colonist in colonists)
                {
                    if (colonist != entrepreneur)
                    {
                        colonist.story.traits.GainTrait(new Trait(TraitDef.Named("Worker")));
                    }
                }
            }
        }
    }
}