
namespace Lexicon.Data.DTO
{
    public class MattersByClientsDTO
    {
        public int ClientId { get; set; }
        public List<MatterDto> Matters { get; set; }
    }
    public class MattersByClientsListDTO
    {
        public int ClientId { get; set; }
        public List<MattersByClientsDTO> MattersList { get; set; }
    }
}
