using MHalas.BGM.Base.Enum;

namespace MHalas.BGM.Base.Extensions
{
    public static class SourceExtensions
    {
        public static string SourceToString(this ESource source)
        {
            switch (source)
            {
                case ESource.WebService:
                    return l10n.Resource.WebService;
                case ESource.WWW:
                    return l10n.Resource.WWW;
                default:
                    return string.Empty;
            }
        }
    }
}
