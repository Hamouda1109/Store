namespace Store.DTOs.ErrorDTOs
{
    public class ErrorsDTO
    {
        public bool IsValid { get; set; }
        public IList<ErrorDTO> Errors { get; set; } = new List<ErrorDTO>();
    }
}
