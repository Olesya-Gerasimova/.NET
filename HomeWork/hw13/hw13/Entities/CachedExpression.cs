using System.ComponentModel.DataAnnotations;

namespace hw13.Entities
{
    public class CachedExpression
    {
        [Key]
        public string Expression { get; set; }
        public double Result { get; set; }
    }
}