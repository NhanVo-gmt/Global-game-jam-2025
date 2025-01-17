namespace Game
{
    using Blueprints;

    public class Upgrade
    {
        public UpgradeRecord UpgradeRecord;

        public bool HasUpgrade()
        {
            return UpgradeRecord != null;
        }
    }
}