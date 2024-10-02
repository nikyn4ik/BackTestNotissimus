using Microsoft.EntityFrameworkCore;

namespace BackTestNotissimus.Models
{
    public class Mouse
    {
        public int Id { get; set; }
        public string Coordinates { get; set; }

        public Mouse()
        {
            Coordinates = string.Empty; 
        }
    }
}
