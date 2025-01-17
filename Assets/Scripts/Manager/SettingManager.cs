namespace Setting
{
    using System;
    using DataManager.MasterData;
    using DataManager.UserData;

    public class SettingManager : BaseDataManager<UserSetting>
    {
        public Action OnDataLoadedCompleted;

        public SettingManager(MasterDataManager masterDataManager) : base(masterDataManager)
        {

        }

        protected override void OnDataLoaded()
        {
            base.OnDataLoaded();
            OnDataLoadedCompleted?.Invoke();
        }

        public bool GetMusicState()
        {
            return Data.MusicEnable;
        }
        
        public void SetMusicState(bool isEnable)
        {
            this.Data.MusicEnable = isEnable;
        }
        
        public bool GetSoundState()
        {
            return Data.SoundEnable;
        }
        
        public void SetSoundState(bool isEnable)
        {
            this.Data.SoundEnable = isEnable;
        }
    }

}