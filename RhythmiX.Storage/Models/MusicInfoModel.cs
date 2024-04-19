namespace RhythmiX.Storage.Models
{
    public class MusicInfoModel
    {
        public string VocalInstrumental { get; set; }
        public string? Lang { get; set; }
        public string? Gender { get; set; }
        public string? AcousticElectric { get; set; }
        public string Speed { get; set; }
        public TagModel Tags { get; set; }
    }
}
