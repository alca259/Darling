namespace Darling;

internal struct AppConstants
{
    public struct ImageElements
    {
        private const string FolderContent = "Content";
        private const string FolderElements = "Elements";
        public static readonly string ButtonBannerOk = Path.Combine(FolderContent, FolderElements, "button_banner_allcollected.jpg");
        public static readonly string ButtonBannerPubli = Path.Combine(FolderContent, FolderElements, "banner_close.jpg");
        public static readonly string ButtonGetAll = Path.Combine(FolderContent, FolderElements, "button_getall.jpg");
        public static readonly string ButtonGetDiamond = Path.Combine(FolderContent, FolderElements, "button_getdiamond.jpg");
        public static readonly string ButtonGetMap = Path.Combine(FolderContent, FolderElements, "button_map.jpg");
        public static readonly string ButtonGetMapGo = Path.Combine(FolderContent, FolderElements, "button_map_go.jpg");
        public static readonly string ButtonGetMapNext = Path.Combine(FolderContent, FolderElements, "button_map_next.jpg");
        public static readonly string ButtonGetMapOcupped = Path.Combine(FolderContent, FolderElements, "beds_ocupped.jpg");
        public static readonly string ButtonGetMapOcuppedSpecial1 = Path.Combine(FolderContent, FolderElements, "beds_ocupped_special_1.jpg");
    }
}
