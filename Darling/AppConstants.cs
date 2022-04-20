namespace Darling;

internal struct AppConstants
{
    public struct Options
    {
        public const string Language = "es-ES";
        public const string Version = "1.0.0";
        public const string Name = "Darling";
    }

    public struct ProcessData
    {
        public const string ProcessName = "MySingingMonsters";
    }

    public struct ImageProcessing
    {
        public const double ImageThreshold = 0.65;
        public const string ImageFileName = "AlcaTempFile.jpg";
    }
    
    public struct ImageElements
    {
        private const string FolderContent = "Content";
        private const string FolderElements = "Elements";
        public static readonly string ButtonGetAll = Path.Combine(FolderContent, FolderElements, "button_getall.jpg");
        public static readonly string ButtonGetDiamond = Path.Combine(FolderContent, FolderElements, "button_getdiamond.jpg");
        public static readonly string ButtonGetMap = Path.Combine(FolderContent, FolderElements, "button_map.jpg");
        public static readonly string ButtonGetMapGo = Path.Combine(FolderContent, FolderElements, "button_map_go.jpg");
        public static readonly string ButtonGetMapNext = Path.Combine(FolderContent, FolderElements, "button_map_next.jpg");
    }
}
