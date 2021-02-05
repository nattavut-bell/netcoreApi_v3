using NetCoreAPI_v3.Validations;

namespace NetCoreAPI_v3.DTOs
{
    public class RoleDtoAdd
    {
        [FirstLetterUpperCase]
        public string RoleName { get; set; }
    }
}