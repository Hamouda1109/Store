using System.ComponentModel.DataAnnotations;

namespace Store.Data
{
    public abstract class BaseAbstractData
    {
        [Key]
        public int Id { get; set; }
    }
}
